# RequireExtensionAttribute

`RequireExtensionAttribute` declares that an extension depends on another extension.

When an extension marked with this attribute is added to **ElysiumDB**, the required extension can be automatically added as well (depending on the attribute settings).

This helps prevent missing dependencies and simplifies project setup.

---

## Basic Usage

```csharp
using ModuDevCore.ElysiumDB.Attributes;

[RequireExtension(typeof(DatabaseExtension))]
public class PlayerExtension : DBExtensionBase
{
    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Log("PlayerExtension initialized.");
    }

    protected override void OnDispose() { }
}
```

When `PlayerExtension` is added, `DatabaseExtension` will also be required.

---

## Automatic Dependency Registration

Suppose the following extension exists:

```csharp
public class DatabaseExtension : DBExtensionBase
{
}
```

and another extension depends on it.

```csharp
[RequireExtension(typeof(DatabaseExtension))]
public class SaveExtension : DBExtensionBase
{
}
```

Adding **SaveExtension** through the ElysiumDB Settings window automatically ensures that **DatabaseExtension** is also available.

```text
Extensions

✓ DatabaseExtension
✓ SaveExtension
```

---

## Optional Dependencies

The second constructor parameter controls whether the dependency should be added automatically.

```csharp
[RequireExtension(typeof(DatabaseExtension), false)]
public class SaveExtension : DBExtensionBase
{
}
```

In this case, ElysiumDB will not automatically add the required extension.

Instead, the Editor may display a warning indicating that the dependency is missing.

---

## Multiple Dependencies

An extension can depend on multiple other extensions.

```csharp
[RequireExtension(typeof(DatabaseExtension))]
[RequireExtension(typeof(NetworkExtension))]
public class PlayerExtension : DBExtensionBase
{
}
```

All declared dependencies are evaluated independently.

---

## Typical Use Case

Imagine a save system that stores data in a database.

```text
DatabaseExtension
        │
        ▼
SaveExtension
        │
        ▼
GameplayExtension
```

The save system requires the database to exist before it can function correctly.

Instead of manually remembering to add both extensions, the dependency is declared once using `RequireExtensionAttribute`.

---

## Notes

- Declares dependencies between extensions.
- Helps prevent missing required modules.
- Multiple `RequireExtensionAttribute` attributes can be applied to the same extension.
- Does not control execution order.
- Use `AfterExtensionAttribute` or `ExtensionProcessOrderAttribute` to control initialization order.

---

> **See also**
>
> - [Create and Use Extensions](./CreateAndUseExtensions.md)
> - [AfterExtensionAttribute](./AfterExtensionAttribute.md)
> - [ExtensionProcessOrderAttribute](./ExtensionProcessOrderAttribute.md)
> - [DefaultExtensionGroupAttribute](./DefaultExtensionGroupAttribute.md)
> - [Process Management](../Database/ProcessManagement.md)
> - [RequireExtensionAttribute](../../REFERENCE.md#modudevcoreelysiumdbattributesrequireextensionattribute)