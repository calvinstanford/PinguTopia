using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Unity.Services.Wire.Internal
{
    interface ISubscriptionRepository
    {
        event Action<int> SubscriptionCountChanged;
        bool IsAlreadySubscribed(Subscription sub);
        bool IsRecovering(Subscription sub);

        void OnSubscriptionComplete(Subscription sub, Reply res);
        Subscription GetSub(Subscription sub);
        Subscription GetSub(string channel);

        IEnumerable<KeyValuePair<string, Subscription>> GetAll();
        void RemoveSub(Subscription sub);

        void OnSocketClosed();
        void RecoverSubscriptions(Reply reply);
        bool IsEmpty { get; }
    }

    class ConcurrentDictSubscriptionRepository : ISubscriptionRepository
    {
        public ConcurrentDictionary<string, Subscription> Subscriptions;

        public bool IsEmpty => Subscriptions.IsEmpty;

        public event Action<int> SubscriptionCountChanged;

        public ConcurrentDictSubscriptionRepository()
        {
            Subscriptions = new ConcurrentDictionary<string, Subscription>();
        }

        public bool IsAlreadySubscribed(string alias)
        {
            return GetSub(alias)?.IsConnected ?? false;
        }

        public bool IsAlreadySubscribed(Subscription sub)
        {
            return IsAlreadySubscribed(sub.Channel);
        }

        public bool IsRecovering(Subscription sub)
        {
            if (String.IsNullOrEmpty(sub.Channel))
            {
                return false;
            }
            return Subscriptions.ContainsKey(sub.Channel) && sub.IsConnected == false;
        }

        public void OnSubscriptionComplete(Subscription sub, Reply res)
        {
            if (res.HasError())
            {
                Logger.LogError($"An error occured during subscription to {sub.Channel}: {res.error.message}");
                return;
            }

            if (res.result.offset != sub.Offset)
            {
                try
                {
                    sub.OnMessageReceived(res);
                    sub.Offset = res.result.offset;
                }
                catch (Exception e)
                {
                    Logger.LogException(e);
                }
            }

            var recovering = IsRecovering(sub);
            sub.OnConnectivityChangeReceived(true);

            if (!recovering)
            {
                Subscriptions.TryAdd(sub.Channel, sub);
                SubscriptionCountChanged?.Invoke(Subscriptions.Count);
            }
        }

        public Subscription GetSub(string channel)
        {
            if (String.IsNullOrEmpty(channel))
            {
                return null;
            }

            if (Subscriptions.ContainsKey(channel))
            {
                Subscriptions.TryGetValue(channel, out var sub);
                return sub;
            }

            return null;
        }

        public Subscription GetSub(Subscription sub)
        {
            return GetSub(sub.Channel);
        }

        public void RemoveSub(Subscription sub)
        {
            if (String.IsNullOrEmpty(sub.Channel))
            {
                return;
            }
            if (Subscriptions.ContainsKey(sub.Channel))
            {
                Subscriptions.TryRemove(sub.Channel, out _);
                sub.OnUnsubscriptionComplete();
                SubscriptionCountChanged?.Invoke(Subscriptions.Count);
            }
        }

        public void OnSocketClosed()
        {
            foreach (var iterator in Subscriptions)
            {
                iterator.Value.OnConnectivityChangeReceived(false);
            }
        }

        public void RecoverSubscriptions(Reply reply)
        {
            var res = reply.result.ToConnectionResult();
            if (res.subs?.Count > 0)
            {
                foreach (var subIterator in res.subs)
                {
                    var sub = GetSub(subIterator.Key);
                    var subreply = new Reply(0, null, new Result()
                    {
                        channel = subIterator.Key,
                        publications = subIterator.Value.publications,
                        offset = subIterator.Value.offset
                    });
                    OnSubscriptionComplete(sub, subreply);
                }
            }
        }

        public IEnumerable<KeyValuePair<string, Subscription>> GetAll()
        {
            return Subscriptions.ToArray();
        }
    }
}
