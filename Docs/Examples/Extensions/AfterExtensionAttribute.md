# AfterExtensionAttribute

`AfterExtensionAttribute` specifies that an extension should be processed **after** another extension during the ElysiumDB lifecycle.

It is useful when one extension depends on another being initialized first, but a hard dependency through `RequireExtensionAttribute` is not necessary.

---

## Basic Usage

```csharp
using ModuDevCore.ElysiumDB.Attributes;

[AfterExtensionAttribute(typeof(DatabaseExtension))]
public class PlayerExtension : DBExtensionBase
{
    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Log("PlayerExtension initialized.");
    }

    protected override void OnDispose() { }
}
```

In this example, `PlayerExtension` will be processed after `DatabaseExtension`.

---

## Multiple Attributes

The attribute can be applied multiple times.

```csharp
[AfterExtensionAttribute(typeof(DatabaseExtension))]
[AfterExtensionAttribute(typeof(NetworkExtension))]
public class GameplayExtension : DBExtensionBase
{
}
```

This indicates that `GameplayExtension` should be processed after both extensions.

---

## Typical Use Case

Suppose one extension creates database tables while another loads player data.

```csharp
public class DatabaseExtension : DBExtensionBase
{
    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Log("Tables created.");
    }
}

[AfterExtensionAttribute(typeof(DatabaseExtension))]
public class PlayerDataExtension : DBExtensionBase
{
    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Log("Player data loaded.");
    }
}
```

The execution order becomes:

```
DatabaseExtension
        ↓
PlayerDataExtension
```

This guarantees that the database structure exists before loading player data.

---

## Notes

- `AfterExtensionAttribute` only affects processing order.
- It does **not** automatically add or register missing extensions.
- If another extension is required to exist, use `RequireExtensionAttribute` instead.
- Multiple `AfterExtensionAttribute` attributes can be applied to a single extension.

---

> **See also**
>
> - [RequireExtensionAttribute](./RequireExtensionAttribute.md)
> - [ExtensionProcessOrderAttribute](./ExtensionProcessOrderAttribute.md)
> - [Create and Use Extensions](./CreateAndUseExtensions.md)
> - [Process Management](./ProcessManagement.md)
> - [AfterExtensionAttribute](../../REFERENCE.md#modudevcoreelysiumdbattributesafterextensionattribute)