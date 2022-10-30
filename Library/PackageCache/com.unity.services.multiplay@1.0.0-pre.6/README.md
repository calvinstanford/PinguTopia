# Multiplay SDK

The Multiplay SDK provides various functionality to setup a dedicated game server using Multiplay.

The Multiplay SDK depends on the Operate Core SDK.

To use the SDK you must initialize the Operate Core SDK.

```csharp
using Unity.Services.Core;
using Unity.Services.Multiplay;
```

```csharp
try
{
    await UnityServices.Initialize();
}
catch (Exception e)
{
    Debug.Log(e);
}
```

You should then be able to access the Multiplay SDK using a singleton interface:

```csharp
await MultiplayService.Instance.ReadyServerForPlayersAsync();
```