# ExtensionProcessOrderAttribute

`ExtensionProcessOrderAttribute` specifies the execution order of an extension within a process group.

Unlike `AfterExtensionAttribute`, which defines relative ordering between extensions, `ExtensionProcessOrderAttribute` assigns an explicit numeric order.

This is useful when several extensions must always execute in a predictable sequence.

---

## Basic Usage

```csharp
using ModuDevCore.ElysiumDB.Attributes;

[ExtensionProcessOrder(nameof(PlayerExtension), 0)]
public class DatabaseExtension : DBExtensionBase
{
    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Log("Database initialized.");
    }

    protected override void OnDispose() { }
}
```

The lower the order value, the earlier the extension is processed.

---

## Multiple Extensions

```csharp
[ExtensionProcessOrder(nameof(GameInitialization), 0)]
public class DatabaseExtension : DBExtensionBase
{
}

[ExtensionProcessOrder(nameof(GameInitialization), 1)]
public class PlayerExtension : DBExtensionBase
{
}

[ExtensionProcessOrder(nameof(GameInitialization), 2)]
public class InventoryExtension : DBExtensionBase
{
}
```

Execution order:

```text
DatabaseExtension
        ↓
PlayerExtension
        ↓
InventoryExtension
```

---

## Process Groups

Extensions are ordered independently inside each process group.

```csharp
[ExtensionProcessOrder(nameof(DatabaseInitialization), 0)]
public class DatabaseExtension : DBExtensionBase
{
}

[ExtensionProcessOrder(nameof(DatabaseInitialization), 1)]
public class MigrationExtension : DBExtensionBase
{
}
```

Using separate groups allows unrelated initialization sequences to remain independent.

---

## Typical Use Case

Suppose one extension creates database tables, another loads player data, and a third initializes gameplay systems.

```text
Create Tables
        ↓
Load Player Data
        ↓
Initialize Gameplay
```

Using `ExtensionProcessOrderAttribute` guarantees that this sequence is always preserved.

---

## Notes

- Lower order values execute first.
- Extensions with different process groups are ordered independently.
- This attribute controls execution order only.
- It does not automatically register dependencies.
- For dependency management, use `RequireExtensionAttribute`.
- For relative ordering, use `AfterExtensionAttribute`.

---

> **See also**
>
> - [Create and Use Extensions](./CreateAndUseExtensions.md)
> - [AfterExtensionAttribute](./AfterExtensionAttribute.md)
> - [RequireExtensionAttribute](./RequireExtensionAttribute.md)
> - [Process Management](./ProcessManagement.md)
> - [ExtensionProcessOrderAttribute](../../REFERENCE.md#modudevcoreelysiumdbattributesextensionprocessorderattribute)