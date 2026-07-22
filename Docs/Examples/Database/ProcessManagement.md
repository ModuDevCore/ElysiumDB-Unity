# Process Management

ElysiumDB provides a process system that allows both the core library and extensions to coordinate their execution.

The process system is divided into two categories:

1. **Extension Processes**
   - Extension initialization (`OnInitialize`)
   - Extension disposal (`OnDispose`)
   - Custom extension execution order
   - Waiting for other extensions

2. **ElysiumDatabase Processes**
   - Connecting databases before initialization
   - Database initialization
   - Extension initialization
   - Suspending and resuming initialization (`Suspend` / `Resume`)
   - Logging
   - SQL query execution

## Monitor Initialization Stages

```csharp
using UnityEngine;
using ModuDevCore.ElysiumDB;

public class Example : MonoBehaviour
{
    private void Start()
    {
    	ElysiumDatabase elysiumDB = new ElysiumDatabase();
        ElysiumDatabase.Instance.OnStageChanged += OnStageChanged; // We add an event before the processes start to catch each one.
        elysiumDB.New(); // We start the processes.
    }

    private void OnStageChanged(ElysiumStage stage, object context)
    {
        Debug.Log($"Current stage: {stage}");
    }

    private void OnDestroy()
    {
        ElysiumDatabase.Instance.OnStageChanged -= OnStageChanged;
    }
}
```

---

## Suspend Extension Initialization

```csharp
public class RemoteConfigExtension : DBExtensionBase
{
    protected override async void OnInitialize(ElysiumDatabase elysium)
    {
        elysium.Suspend(ExtensionEvent.Initialize);

        await DownloadConfiguration();

        elysium.Resume(ExtensionEvent.Initialize);
    }
}
```

Use this when initialization must wait for an asynchronous task before other extensions continue processing. 

---

## React to a Specific Stage

```csharp
private void OnStageChanged(ElysiumStage stage, object context)
{
    if (stage == ElysiumStage.ExtensionInitialized)
    {
        Debug.Log("An extension has finished initializing.");
    }

    if (stage == ElysiumStage.Ready)
    {
        Debug.Log("ElysiumDB is ready.");
    }
}
```

---

## Pause Disposal

```csharp
public class SaveExtension : DBExtensionBase
{
    protected override async void OnDispose()
    {
        ElysiumDatabase.Instance.Suspend(ExtensionEvent.Dispose);

        await SavePlayerData();

        ElysiumDatabase.Instance.Resume(ExtensionEvent.Dispose);
    }
}
```

---

## Track Which Extension Is Being Processed

`context` contains the object associated with the current stage.

```csharp
private void OnStageChanged(ElysiumStage stage, object context)
{
    if (context is DBExtensionBase extension)
    {
        Debug.Log($"{stage}: {extension.extensionName}");
    }
}
```

---

> **See also**
>
> - [Creating and Using Extensions](../Extensions/CreateAndUseExtensions.md)
> - [AfterExtensionAttribute](../Extensions/AfterExtensionAttribute.md)
> - [RequireExtensionAttribute](../Extensions/RequireExtensionAttribute.md)
> - [ExtensionProcessOrderAttribute](../Extensions/ExtensionProcessOrderAttribute.md)
> - [DefaultExtensionGroupAttribute](../Extensions/DefaultExtensionGroupAttribute.md)
> - [CreateElysiumDatabase](../CreateElysiumDatabase.md)
> - [ElysiumDatabase](../../REFERENCE.md#modudevcoreelysiumdbelysiumdatabase)
> - [DBExtensionBase](../../REFERENCE.md#modudevcoreelysiumdbextensiondbextensionbase)
> - [ElysiumStage](../../REFERENCE.md#modudevcoreelysiumdbelysiumstage)
> - [ExtensionEvent](../../REFERENCE.md#modudevcoreelysiumdbextensionevent)