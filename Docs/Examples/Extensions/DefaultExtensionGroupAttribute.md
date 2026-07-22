# DefaultExtensionGroupAttribute

`DefaultExtensionGroupAttribute` specifies the default category in which an extension appears inside the **ElysiumDB Settings** window.

It helps organize large numbers of extensions into logical groups, making the Inspector easier to navigate.

---

## Basic Usage

```csharp
using ModuDevCore.ElysiumDB.Attributes;

[DefaultExtensionGroup("Gameplay")]
public class PlayerExtension : DBExtensionBase
{
    protected override void OnInitialize(ElysiumDatabase elysium)
    {
    }

    protected override void OnDispose()
    {
    }
}
```

The extension will appear under the **Gameplay** category when adding new extensions.

---

## Nested Groups

Groups can contain multiple levels by separating them with `/`.

```csharp
[DefaultExtensionGroup("Gameplay/Player")]
public class PlayerExtension : DBExtensionBase
{
}
```

This creates the following hierarchy:

```text
Gameplay
└── Player
    └── PlayerExtension
```

---

## Organizing Extensions

Using categories makes large projects much easier to maintain.

```csharp
[DefaultExtensionGroup("Database")]
public class DatabaseExtension : DBExtensionBase
{
}

[DefaultExtensionGroup("Gameplay")]
public class PlayerExtension : DBExtensionBase
{
}

[DefaultExtensionGroup("Gameplay")]
public class InventoryExtension : DBExtensionBase
{
}

[DefaultExtensionGroup("Networking")]
public class MultiplayerExtension : DBExtensionBase
{
}
```

The Add Extension menu may look like:

```text
Database
    DatabaseExtension

Gameplay
    PlayerExtension
    InventoryExtension

Networking
    MultiplayerExtension
```

---

## Recommended Convention

A common approach is grouping extensions by feature or subsystem.

Examples:

```text
Database
Gameplay
Gameplay/Player
Gameplay/Inventory
Networking
UI
Audio
Save System
Debug
Editor
```

Keeping extensions organized becomes especially useful in projects with dozens of modules.

---

## Notes

- `DefaultExtensionGroupAttribute` only affects the Editor interface.
- It does not change initialization order.
- It does not create dependencies between extensions.
- It can be combined with other extension attributes such as `RequireExtensionAttribute` or `ExtensionProcessOrderAttribute`.

---

> **See also**
>
> - [Create and Use Extensions](./CreateAndUseExtensions.md)
> - [RequireExtensionAttribute](./RequireExtensionAttribute.md)
> - [AfterExtensionAttribute](./AfterExtensionAttribute.md)
> - [ExtensionProcessOrderAttribute](./ExtensionProcessOrderAttribute.md)
> - [DefaultExtensionGroupAttribute](../../REFERENCE.md#modudevcoreelysiumdbattributesdefaultextensiongroupattribute)