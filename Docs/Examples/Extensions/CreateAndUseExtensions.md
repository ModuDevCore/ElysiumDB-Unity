# Create and Use Extensions

Extensions are the primary way to extend ElysiumDB functionality.

Every extension inherits from `DBExtensionBase` and participates in the ElysiumDB lifecycle. Extensions can initialize systems, create database tables, register services, or perform any other startup logic.

---

## Creating Your First Extension

Create a new C# class that inherits from `DBExtensionBase`.

```csharp
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

public class PlayerExtension : DBExtensionBase
{
    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Log("PlayerExtension initialized.");
    }

    protected override void OnDispose()
    {
        Log("PlayerExtension disposed.");
    }
}
```

---

## Registering the Extension

Open:

```
ElysiumDB → Settings
```

Locate the **Extensions** list and click **Add**.

Select your extension from the popup.

After saving, the extension will automatically participate in every ElysiumDB initialization.

---

## Accessing Other Extensions

Extensions can communicate with each other using `GetExtension<T>()`.

```csharp
public class PlayerExtension : DBExtensionBase
{
    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        InventoryExtension inventory =
            GetExtension<InventoryExtension>();

        inventory.LoadInventory();
    }

    protected override void OnDispose() { }
}
```

If multiple extensions of the same type exist, use `GetExtensions<T>()`.

```csharp
IEnumerable<InventoryExtension> inventories =
    GetExtensions<InventoryExtension>();

foreach (InventoryExtension inventory in inventories)
{
    inventory.LoadInventory();
}
```

---

## Logging

`DBExtensionBase` provides a convenient logging method.

```csharp
protected override void OnInitialize(ElysiumDatabase elysium)
{
    Log("Extension initialized.");
}
```

---

## Creating Tables During Initialization

Extensions are a good place to prepare database structures.

```csharp
protected override void OnInitialize(ElysiumDatabase elysium)
{
    elysium["Players.db"].Execute(@"
        CREATE TABLE IF NOT EXISTS Player
        (
            Id INTEGER PRIMARY KEY,
            Name TEXT
        )");
}
```

---

## Accessing Database Connections

Every extension has access to the current `ElysiumDatabase` instance.

```csharp
protected override void OnInitialize(ElysiumDatabase elysium)
{
    DBMeta database = elysium["Players.db"];

    database.Execute(
        "INSERT INTO Player(Name) VALUES('Alex')");
}
```

---

## Lifecycle

Every extension participates in two main lifecycle methods.

```text
OnInitialize()
        │
        ▼
   Runtime
        │
        ▼
OnDispose()
```

`OnInitialize()` is called during ElysiumDB initialization.

`OnDispose()` is called when ElysiumDB is disposed.

---

## Organizing Extensions

As projects grow, extensions can become dependent on each other.

ElysiumDB provides several attributes to organize execution order and dependencies:

- `RequireExtensionAttribute`
- `AfterExtensionAttribute`
- `ExtensionProcessOrderAttribute`
- `DefaultExtensionGroupAttribute`

Each attribute is described in its own documentation page.

---

## Notes

- Every extension must inherit from `DBExtensionBase`.
- Extensions are automatically initialized after being added to the ElysiumDB Settings.
- Use `GetExtension<T>()` to access another extension.
- Use `GetExtensions<T>()` when multiple extensions of the same type may exist.
- Place initialization logic inside `OnInitialize()`.
- Release resources inside `OnDispose()`.

---

> **See also**
>
> - [RequireExtensionAttribute](./RequireExtensionAttribute.md)
> - [AfterExtensionAttribute](./AfterExtensionAttribute.md)
> - [ExtensionProcessOrderAttribute](./ExtensionProcessOrderAttribute.md)
> - [DefaultExtensionGroupAttribute](./DefaultExtensionGroupAttribute.md)
> - [Process Management](./ProcessManagement.md)
> - [DBExtensionBase](../../REFERENCE.md#modudevcoreelysiumdbextensiondbextensionbase)
> - [ElysiumDatabase](../../REFERENCE.md#modudevcoreelysiumdbelysiumdatabase)