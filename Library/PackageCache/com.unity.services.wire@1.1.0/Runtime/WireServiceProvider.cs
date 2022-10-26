using System.Collections.Generic;
using System.Threading.Tasks;

using Unity.Services.Authentication.Internal;
using Unity.Services.Core.Internal;
using Unity.Services.Core.Scheduler.Internal;
using Unity.Services.Core.Threading.Internal;
using Unity.Services.Core.Telemetry.Internal;
using UnityEngine;

namespace Unity.Services.Wire.Internal
{
    class WireServiceProvider : IInitializablePackage
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Register()
        {
            // Pass an instance of this class to Core
            var generatedPackageRegistry =
                CoreRegistry.Instance.RegisterPackage(new WireServiceProvider());
            // And specify what components it requires, or provides.
            generatedPackageRegistry
                .DependsOn<IAccessToken>()
                .DependsOn<IActionScheduler>()
                .DependsOn<IUnityThreadUtils>()
                .DependsOn<IMetricsFactory>()
                .ProvidesComponent<IWire>();
        }

        public Task Initialize(CoreRegistry registry)
        {
            var actionScheduler = registry.GetServiceComponent<IActionScheduler>();
            var threadUtils = registry.GetServiceComponent<IUnityThreadUtils>();

            // authentication
            var accessTokenWire = registry.GetServiceComponent<IAccessToken>();
            if (accessTokenWire != null)
            {
                // telemetry
                var metricsFactory = registry.GetServiceComponent<IMetricsFactory>();
                var metrics = metricsFactory.Create("com.unity.services.wire");
                metrics.SendSumMetric("wire_init", 1);

                Configuration configuration = new Configuration
                {
                    token = accessTokenWire,
#if WIRE_STAGING
                    address = "wss://wire-stg.unity3d.com/ws",
#elif WIRE_TEST
                    address = "wss://wire-test.unity3d.com/ws",
#else
                    address = "wss://wire.unity3d.com/ws",
#endif
                };
                var client = new Client(configuration, actionScheduler, metrics, threadUtils);
                registry.RegisterServiceComponent<IWire>(client);
                return Task.CompletedTask;
            }
            throw new MissingComponentException("IAccessToken component not initialized.");
        }
    }
}
