# Technical documentation

This is a technical documentation, a brief description is provided in REFERENCE, with public classes and examples. Public and private classes are provided for internal development, but they can be used (at your own risk).

## Guide

<details>
<summary>AfterExtensionAttribute</summary>

## Parent
[ModuDevCore.ElysiumDB.AfterExtensionAttribute](#ModuDevCore.ElysiumDB.AfterExtensionAttribute)

### Property
- [ExtensionType](#ModuDevCore.ElysiumDB.AfterExtensionAttribute.ExtensionType)

</details>

<details>
<summary>DefaultExtensionGroupAttribute</summary>

## Parent
[ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute](#ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute)

### Fields
- [ExtensionGroup](#ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute.ExtensionGroup)

</details>

<details>
<summary>ExtensionProcessOrderAttribute</summary>

## Parent
[ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute](#ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute)

### Property
- [Group](#ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute.Group)
- [Order](#ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute.Order)

</details>

<details>
<summary>RequireExtensionAttribute</summary>

## Parent
[ModuDevCore.ElysiumDB.RequireExtensionAttribute](#ModuDevCore.ElysiumDB.RequireExtensionAttribute)

### Fields
- [ExtensionType](#ModuDevCore.ElysiumDB.RequireExtensionAttribute.ExtensionType)
- [AutoCreate](#ModuDevCore.ElysiumDB.RequireExtensionAttribute.AutoCreate)

</details>

<details>
<summary>ElysiumStage</summary>

## Parent
[ModuDevCore.ElysiumDB.Core.Data.ElysiumStage](#ModuDevCore.ElysiumDB.Core.Data.ElysiumStage)

### Enummerators
- [ElysiumStage](#ModuDevCore.ElysiumDB.Core.Data.ElysiumStage.ElysiumStage)

</details>

<details>
<summary>ExtensionEvent</summary>

## Parent
[ModuDevCore.ElysiumDB.Core.Data.ExtensionEvent](#ModuDevCore.ElysiumDB.Core.Data.ExtensionEvent)

### Enummerators
- [ExtensionEvent](#ModuDevCore.ElysiumDB.Core.Data.ExtensionEvent.ExtensionEvent)

</details>

<details>
<summary>DBMeta</summary>

## Parent
[ModuDevCore.ElysiumDB.DBMeta](#ModuDevCore.ElysiumDB.DBMeta)

### Fields
- [connection](#ModuDevCore.ElysiumDB.DBMeta.connection)

### Property
- [SqliteConnectionStringBuilder](#ModuDevCore.ElysiumDB.DBMeta.SqliteConnectionStringBuilder)

### Methods
- [Dispose](#ModuDevCore.ElysiumDB.DBMeta.Dispose)
- [Query](#ModuDevCore.ElysiumDB.DBMeta.Query)
- [QueryFirst](#ModuDevCore.ElysiumDB.DBMeta.QueryFirst)
- [QueryList](#ModuDevCore.ElysiumDB.DBMeta.QueryList)
- [QueryColumn](#ModuDevCore.ElysiumDB.DBMeta.QueryColumn)
- [QueryValue](#ModuDevCore.ElysiumDB.DBMeta.QueryValue)
- [QueryDictionary](#ModuDevCore.ElysiumDB.DBMeta.QueryDictionary)
- [Execute](#ModuDevCore.ElysiumDB.DBMeta.Execute)
- [Exists](#ModuDevCore.ElysiumDB.DBMeta.Exists)
- [MapReaderToObject](#ModuDevCore.ElysiumDB.DBMeta.MapReaderToObject)

</details>

<details>
<summary>ElysiumDatabase</summary>

## Parent
[ModuDevCore.ElysiumDB.ElysiumDatabase](#ModuDevCore.ElysiumDB.ElysiumDatabase)

### Fields
- [Instance](#ModuDevCore.ElysiumDB.ElysiumDatabase.Instance)
- [Connections](#ModuDevCore.ElysiumDB.ElysiumDatabase.Connections)

### Property
- [Settings](#ModuDevCore.ElysiumDB.ElysiumDatabase.Settings)
- [IsOffline](#ModuDevCore.ElysiumDB.ElysiumDatabase.IsOffline)
- [PlatformDataPath](#ModuDevCore.ElysiumDB.ElysiumDatabase.PlatformDataPath)
- [this[string database]](#ModuDevCore.ElysiumDB.ElysiumDatabase.Item)

### Methods
- [Log / LogWarning / LogError](#ModuDevCore.ElysiumDB.ElysiumDatabase.Log)
- [Suspend](#ModuDevCore.ElysiumDB.ElysiumDatabase.Suspend)
- [Resume](#ModuDevCore.ElysiumDB.ElysiumDatabase.Resume)
- [GetExtension\<T\>](#ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensionGeneric)
- [GetExtensions\<T\>](#ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensionsGeneric)
- [HasExtension\<T\>](#ModuDevCore.ElysiumDB.ElysiumDatabase.HasExtensionGeneric)
- [TryGetExtension\<T\>](#ModuDevCore.ElysiumDB.ElysiumDatabase.TryGetExtensionGeneric)
- [AddExtension\<T\>](#ModuDevCore.ElysiumDB.ElysiumDatabase.AddExtensionGeneric)
- [RemoveExtension\<T\>](#ModuDevCore.ElysiumDB.ElysiumDatabase.RemoveExtensionGeneric)
- [GetExtension(Type)](#ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtension)
- [GetExtensions(Type)](#ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensions)
- [HasExtension(Type)](#ModuDevCore.ElysiumDB.ElysiumDatabase.HasExtension)
- [TryGetExtension(Type, out object)](#ModuDevCore.ElysiumDB.ElysiumDatabase.TryGetExtension)
- [AddExtension(Type)](#ModuDevCore.ElysiumDB.ElysiumDatabase.AddExtension)
- [RemoveExtension(Type)](#ModuDevCore.ElysiumDB.ElysiumDatabase.RemoveExtension)
- [GetRequiresExtensions](#ModuDevCore.ElysiumDB.ElysiumDatabase.GetRequiresExtensions)
- [ProcessRequiredExtensions](#ModuDevCore.ElysiumDB.ElysiumDatabase.ProcessRequiredExtensions)
- [New](#ModuDevCore.ElysiumDB.ElysiumDatabase.New)
- [DetachDB](#ModuDevCore.ElysiumDB.ElysiumDatabase.DetachDB)
- [ConnectDB](#ModuDevCore.ElysiumDB.ElysiumDatabase.ConnectDB)
- [CreateSQLiteDatabase](#ModuDevCore.ElysiumDB.ElysiumDatabase.CreateSQLiteDatabase)
- [OpenSettings](#ModuDevCore.ElysiumDB.ElysiumDatabase.OpenSettings)
- [Dispose](#ModuDevCore.ElysiumDB.ElysiumDatabase.Dispose)

### Enummerators
None

### Nested Classes
None

</details>

<details>
<summary>ElysiumDBSettings</summary>

## Parent
[ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings)

### Fields
- [logIgnorePatterns](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.logIgnorePatterns)
- [dbPaths](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.dbPaths)
- [extensions](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.extensions)
- [showLogs](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showLogs)
- [showSqlLogs](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showSqlLogs)
- [showCoreLogs](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showCoreLogs)
- [showDefaultLogs](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showDefaultLogs)
- [showExtensionProccesingLogs](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showExtensionProccesingLogs)

</details>

<details>
<summary>ElysiumDBSettingsEditor</summary>

## Parent
[ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor)

### Fields
- [elysiumDBSettings](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.elysiumDBSettings)
- [listLogsFilter](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.listLogsFilter)
- [listOfPathDB](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.listOfPathDB)

### Methods
- [OnInspectorGUI](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.OnInspectorGUI)
- [DrawLogToggle](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawLogToggle)
- [DrawStatus](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawStatus)
- [DrawElysiumDBInfo](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawElysiumDBInfo)
- [DrawExtensions](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawExtensions)
- [ShowOpenMenu](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.ShowOpenMenu)
- [OpenFile](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.OpenFile)

</details>

<details>
<summary>DBExtensionBase</summary>

## Parent
[ModuDevCore.ElysiumDB.Extension.DBExtensionBase](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase)

### Fields
- [enabled](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.enabled)
- [extensionGroup](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionGroup)
- [extensionId](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionId)

### Property
- [extensionName](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionName)

### Methods
- [Process](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Process)
- [GetExtension\<T\>](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtensionGeneric)
- [GetExtensions\<T\>](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtensionsGeneric)
- [TryGetExtensions\<T\>](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.TryGetExtensions)
- [HasExtension\<T\>](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.HasExtension)
- [AddExtension\<T\>](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.AddExtension)
- [RemoveExtension\<T\>](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.RemoveExtension)
- [OnInitialize](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnInitialize)
- [OnDispose](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnDispose)
- [Log](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Log)

</details>

<details>
<summary>ExtensionDrawer</summary>

## Parent
[ModuDevCore.ElysiumDB.Editor.ExtensionDrawer](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer)

### Property
- [Settings](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.Settings)

### Fields
- [target](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.target)

### Methods
- [GetExtension\<T\>](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetExtensionGeneric)
- [GetExtensions\<T\>](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetExtensionsGeneric)
- [TryGetExtensions\<T\>](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.TryGetExtensions)
- [HasExtension\<T\>](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.HasExtension)
- [AddExtension\<T\>](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.AddExtension)
- [RemoveExtension\<T\>](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.RemoveExtension)
- [OnGUI](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.OnGUI)
- [OnExtensionGUI](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.OnExtensionGUI)
- [GetPropertyHeight](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetPropertyHeight)
- [GetExtensionHeight](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetExtensionHeight)
- [DrawDefaultExtension](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.DrawDefaultExtension)
- [GetChildrenHeight](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetChildrenHeight)

</details>

<details>
<summary>DBExtensionBaseDrawer</summary>

## Parent
[ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer](#ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer)

### Methods
- [OnExtensionGUI](#ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer.OnExtensionGUI)
- [GetExtensionHeight](#ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer.GetExtensionHeight)

</details>

<details>
<summary>CustomList</summary>

## Parent
[ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList)

### Methods
- [CustomList (constructor)](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList.ctor)
- [Draw](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList.Draw)

</details>

<details>
<summary>DBExtensionDrawer / IInspectorElement / PropertyGroup / PropertyExtension / GroupPathDropdown</summary>

## Parent
[ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer](#ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer)

### Nested Classes / Types
- [IInspectorElement](#ModuDevCore.ElysiumDB.Editor.Internal.IInspectorElement)
- [PropertyGroup](#ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup)
- [PropertyExtension](#ModuDevCore.ElysiumDB.Editor.Internal.PropertyExtension)
- [SerializedPropertyExtensions](#ModuDevCore.ElysiumDB.Editor.Internal.SerializedPropertyExtensions)
- [GroupPathDropdown](#ModuDevCore.ElysiumDB.Editor.Internal.GroupPathDropdown)

### Methods
- [ValidateGroups](#ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.ValidateGroups)
- [TryGetGroup](#ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.TryGetGroup)
- [GenerateNewGroupName](#ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.GenerateNewGroupName)
- [DrawExtensionsList](#ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.DrawExtensionsList)
- [ShowContextMenuGroup](#ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.ShowContextMenuGroup)
- [ShowContextMenuExtension](#ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.ShowContextMenuExtension)

</details>

<details>
<summary>IMGUITextFieldPro</summary>

## Parent
[ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro)

### Fields
- [text](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.text)
- [caret / select](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.caret)
- [hasFocus](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.hasFocus)
- [placeholder](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.placeholder)
- [drawBackground](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.drawBackground)

### Methods
- [Draw](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.Draw)
- [Focus](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.Focus)
- [SetSelection](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.SetSelection)
- [SelectAll](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.SelectAll)
- [ClearSelection](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.ClearSelection)
- [GetSelectedText](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.GetSelectedText)
- [HasSelection](#ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.HasSelection)

</details>

<details>
<summary>DBPostprocessor</summary>

## Parent
[ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor](#ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor)

### Methods
- [SafetyFixExtensions](#ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.SafetyFixExtensions)

</details>

<details>
<summary>AuthElysiumDB / ElysiumAuthCredentials / IAuthElysiumReceiver</summary>

## Parent
[AuthElysiumDB](#AuthElysiumDB)

### Nested Classes / Types
- [ElysiumAuthCredentials](#ElysiumAuthCredentials)
- [IAuthElysiumReceiver](#IAuthElysiumReceiver)

### Property
- [IsAuthenticated](#AuthElysiumDB.IsAuthenticated)

### Fields
- [authTable](#AuthElysiumDB.authTable)

### Methods
- [Auth](#AuthElysiumDB.Auth)
- [SignOut](#AuthElysiumDB.SignOut)
- [GetCredentials](#AuthElysiumDB.GetCredentials)
- [OnDispose](#AuthElysiumDB.OnDispose)

</details>

<details>
<summary>AuthElysiumDBDrawer</summary>

## Parent
[AuthElysiumDBDrawer](#AuthElysiumDBDrawer)

### Methods
- [OnGUI](#AuthElysiumDBDrawer.OnGUI)
- [GetPropertyHeight](#AuthElysiumDBDrawer.GetPropertyHeight)

</details>

<details>
<summary>DBLogger</summary>

## Parent
[ModuDevCore.ElysiumDB.Internal.DBLogger](#ModuDevCore.ElysiumDB.Internal.DBLogger)

### Enummerators
- [ContextLevel](#ModuDevCore.ElysiumDB.Internal.DBLogger.ContextLevel)

### Methods
- [Log](#ModuDevCore.ElysiumDB.Internal.DBLogger.Log)
- [LogContext](#ModuDevCore.ElysiumDB.Internal.DBLogger.LogContext)
- [DefaultExtensionNamePrefixColor](#ModuDevCore.ElysiumDB.Internal.DBLogger.DefaultExtensionNamePrefixColor)

</details>

---

<a id="ModuDevCore.ElysiumDB.AfterExtensionAttribute"></a>
## ModuDevCore.ElysiumDB.AfterExtensionAttribute
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.AfterExtensionAttribute)

### Opportunities

* Lets you specify that an extension must be initialized/processed only after processing of another extension of the specified type has completed.
* Supports multiple usage (`AllowMultiple = true`), i.e. several dependencies can be declared.
* Inherited by derived classes (`Inherited = true`).

### Declaration

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public sealed class AfterExtensionAttribute : Attribute
```

The attribute is applied to a class derived from `DBExtensionBase` to define its processing order relative to another extension — processing of the marked class is deferred until processing of `ExtensionType` completes within the current `ExtensionEvent`.

## Fields
None

## Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.AfterExtensionAttribute.ExtensionType"></a>
<td><code>ExtensionType</code></td>
<td>

```csharp
public Type ExtensionType { get; }
```

</td>
<td>The extension type (`DBExtensionBase`) after whose processing the marked extension may be processed.</td>
</tr>
</table>

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<td><code>AfterExtensionAttribute</code> (constructor)</td>
<td>

```csharp
public AfterExtensionAttribute(Type extensionType)
```

</td>
<td>Creates the attribute specifying the predecessor extension type.</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute"></a>
## ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute)

### Opportunities

* Sets the default group (an inspector path) into which the extension will be placed when created (including auto-creation via `RequireExtensionAttribute`).
* Can be applied to a class only once (`AllowMultiple = false`).

### Declaration

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public sealed class DefaultExtensionGroupAttribute : Attribute
```

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute.ExtensionGroup"></a>
<td><code>ExtensionGroup</code></td>
<td>

```csharp
public string ExtensionGroup;
```

</td>
<td>Group path (e.g. `"Auth/Sub"`) assigned to the extension's `extensionGroup` field when it is created.</td>
</tr>
</table>

## Properties
None

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<td><code>DefaultExtensionGroupAttribute</code> (constructor)</td>
<td>

```csharp
public DefaultExtensionGroupAttribute(string extensionGroup)
```

</td>
<td>Creates the attribute with the specified default group.</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute"></a>
## ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute)

### Opportunities

* Defines a sorting group (`Group`) and a numeric priority (`Order`) used to control extension processing order inside `ElysiumDatabase.RunExtensionsProcess`.
* Not sealed (`class`, not `sealed`) — can be inherited for extended ordering logic.

### Declaration

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class ExtensionProcessOrderAttribute : Attribute
```

## Fields
None

## Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute.Group"></a>
<td><code>Group</code></td>
<td>

```csharp
public string Group { get; }
```

</td>
<td>Sorting group name. Defaults to `"Default"` when not specified.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute.Order"></a>
<td><code>Order</code></td>
<td>

```csharp
public int Order { get; }
```

</td>
<td>Numeric processing priority within the group (ascending order).</td>
</tr>
</table>

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<td><code>ExtensionProcessOrderAttribute</code> (constructor)</td>
<td>

```csharp
public ExtensionProcessOrderAttribute(
    string group,
    int order = 0
)
```

</td>
<td>Creates the attribute with the specified group and sorting priority.</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.RequireExtensionAttribute"></a>
## ModuDevCore.ElysiumDB.RequireExtensionAttribute
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.RequireExtensionAttribute)

### Opportunities

* Declares a dependency on another extension (`ExtensionType`).
* If `AutoCreate == true`, the dependency will be automatically created via `ElysiumDatabase.ProcessRequiredExtensions`.
* If `AutoCreate == false`, adding an extension without an already existing dependency raises an `InvalidOperationException`.
* Supports multiple usage.

### Declaration

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public sealed class RequireExtensionAttribute : Attribute
```

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.RequireExtensionAttribute.ExtensionType"></a>
<td><code>ExtensionType</code></td>
<td>

```csharp
public Type ExtensionType;
```

</td>
<td>The type of the required extension.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.RequireExtensionAttribute.AutoCreate"></a>
<td><code>AutoCreate</code></td>
<td>

```csharp
public bool AutoCreate;
```

</td>
<td>Determines whether the required extension should be automatically created if it is missing.</td>
</tr>
</table>

## Properties
None

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<td><code>RequireExtensionAttribute</code> (constructor)</td>
<td>

```csharp
public RequireExtensionAttribute(
    Type extensionType,
    bool autoCreate = true
)
```

</td>
<td>Creates the dependency attribute specifying the type and the auto-create flag.</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Core.Data.ElysiumStage"></a>
## ModuDevCore.ElysiumDB.Core.Data.ElysiumStage
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Core.Data.ElysiumStage)

### Opportunities

* Describes the `ElysiumDatabase` lifecycle from initialization to disposal.
* Used in the `ElysiumDatabase.OnStageChanged` event to track the system's current state.

### Declaration

```csharp
public enum ElysiumStage
```

## Fields
None

## Properties
None

## Methods
None

## Enum

<table>
<tr>
<th>Enum</th>
<th>Values</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Data.ElysiumStage.ElysiumStage"></a>
<td><code>ElysiumStage</code></td>
<td>

```csharp
public enum ElysiumStage
{
    None,
    Initializing,
    DatabasesConnecting,
    DatabasesConnected,
    ExtensionsInitializing,
    ExtensionInitialized,
    Ready,
    Disposing,
    Disposed
}
```

</td>
<td>
<code>None</code> — initial state.<br/>
<code>Initializing</code> — database initialization has started.<br/>
<code>DatabasesConnecting</code> / <code>DatabasesConnected</code> — stages of connecting to SQLite databases.<br/>
<code>ExtensionsInitializing</code> / <code>ExtensionInitialized</code> — stages of extension processing during initialization.<br/>
<code>Ready</code> — the system is fully ready to use.<br/>
<code>Disposing</code> / <code>Disposed</code> — stages of disposal.
</td>
</tr>
</table>

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Core.Data.ExtensionEvent"></a>
## ModuDevCore.ElysiumDB.Core.Data.ExtensionEvent
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Core.Data.ExtensionEvent)

### Opportunities

* Defines the type of extension processing event: initialization or disposal.
* Used in `DBExtensionBase.Process` and in the internal queues of `ElysiumDatabase`.

### Declaration

```csharp
public enum ExtensionEvent
```

## Fields
None

## Properties
None

## Methods
None

## Enum

<table>
<tr>
<th>Enum</th>
<th>Values</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Data.ExtensionEvent.ExtensionEvent"></a>
<td><code>ExtensionEvent</code></td>
<td>

```csharp
public enum ExtensionEvent {
    Initialize = 0,
    Dispose = 1
}
```

</td>
<td>
<code>Initialize</code> — extension initialization event.<br/>
<code>Dispose</code> — extension disposal event (processed in reverse order relative to initialization).
</td>
</tr>
</table>

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.DBMeta"></a>
## ModuDevCore.ElysiumDB.DBMeta
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.DBMeta)

### Opportunities

* A wrapper around `IDbConnection` (SQLite) with a set of helper query methods (`Query`, `QueryFirst`, `QueryList`, `QueryColumn`, `QueryValue`, `QueryDictionary`, `Execute`, `Exists`).
* Automatically logs every SQL query through `DBLogger`, including the calling method, file, and line (`CallerMemberName`/`CallerFilePath`/`CallerLineNumber`).
* Supports mapping query results onto POCO objects via reflection (`MapReaderToObject`).
* Implements `IDisposable` for proper connection closing.

### Declaration

```csharp
public class DBMeta : IDisposable
```

Represents a single database (SQLite) connection inside `ElysiumDatabase.Connections`.

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.connection"></a>
<td><code>connection</code></td>
<td>

```csharp
public IDbConnection connection;
```

</td>
<td>The active database connection.</td>
</tr>
</table>

## Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.SqliteConnectionStringBuilder"></a>
<td><code>SqliteConnectionStringBuilder</code></td>
<td>

```csharp
public SqliteConnectionStringBuilder SqliteConnectionStringBuilder { get; }
```

</td>
<td>Returns a connection string builder parsed from the current `connection.ConnectionString`.</td>
</tr>
</table>

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.Dispose"></a>
<td><code>Dispose</code></td>
<td>

```csharp
public void Dispose()
```

</td>
<td>Closes and releases the database connection.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.Query"></a>
<td><code>Query</code></td>
<td>

```csharp
public IDataReader Query(
    string cmd,
    int linesToRead = 0,
    (string name, object value)[] parameters = null
)
```

</td>
<td>Executes an SQL query and returns an `IDataReader`. If <code>linesToRead</code> > 0, immediately skips that many rows. Logs the query along with the caller information.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.QueryFirst"></a>
<td><code>QueryFirst&lt;T&gt;</code></td>
<td>

```csharp
public T QueryFirst<T>(
    string cmd,
    int linesToRead = 0,
    (string name, object value)[] parameters = null
) where T : new()
```

</td>
<td>Executes a query and returns the first result row mapped onto an object of type <code>T</code>, or <code>default</code> if there are no rows.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.QueryList"></a>
<td><code>QueryList&lt;T&gt;</code></td>
<td>

```csharp
public List<T> QueryList<T>(
    string cmd,
    int linesToRead = 0,
    (string name, object value)[] parameters = null
) where T : new()
```

</td>
<td>Executes a query and returns a list of all result rows mapped onto objects of type <code>T</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.QueryColumn"></a>
<td><code>QueryColumn&lt;T&gt;</code></td>
<td>

```csharp
public List<T> QueryColumn<T>(string cmd)
```

</td>
<td>Executes a query and returns a list of the first column's values, converted to type <code>T</code> (<code>NULL</code> values are skipped).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.QueryValue"></a>
<td><code>QueryValue&lt;T&gt;</code></td>
<td>

```csharp
public T QueryValue<T>(
    string cmd,
    (string name, object value)[] parameters = null
)
```

</td>
<td>Executes a query and returns a single value (first column of the first row), converted to type <code>T</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.QueryDictionary"></a>
<td><code>QueryDictionary&lt;TKey, TValue&gt;</code></td>
<td>

```csharp
public Dictionary<TKey, TValue> QueryDictionary<TKey, TValue>(
    string cmd,
    (string name, object value)[] parameters = null
)
```

</td>
<td>Executes a query and returns a dictionary where the key comes from the first column and the value from the second.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.Execute"></a>
<td><code>Execute</code></td>
<td>

```csharp
public void Execute(
    string cmd,
    (string name, object value)[] parameters = null
)
```

</td>
<td>Executes an SQL command without returning a result (`ExecuteNonQuery`), with parameters and logging.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.Exists"></a>
<td><code>Exists</code></td>
<td>

```csharp
public bool Exists(
    string cmd,
    (string name, object value)[] parameters = null
)
```

</td>
<td>Executes a query and returns <code>true</code> if at least one result row exists.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.MapReaderToObject"></a>
<td><code>MapReaderToObject&lt;T&gt;</code> (private)</td>
<td>

```csharp
private static T MapReaderToObject<T>(IDataReader reader)
    where T : new()
```

</td>
<td>Maps the current `IDataReader` row onto the properties of an object of type <code>T</code> by column name (case-insensitive), converting types via <code>Convert.ChangeType</code>. Errors while setting individual properties are ignored.</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.ElysiumDatabase"></a>
## ModuDevCore.ElysiumDB.ElysiumDatabase
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.ElysiumDatabase)

### Opportunities

* The central class of the system: manages SQLite database connections (`Connections`) and the entire extension (`DBExtensionBase`) lifecycle.
* Supports an extension system with dependencies (`RequireExtensionAttribute`), processing order (`ExtensionProcessOrderAttribute`), and deferred processing (`AfterExtensionAttribute`).
* Provides static access to the current instance (`Instance`) and settings (`Settings`, a `ElysiumDBSettings` ScriptableObject).
* Allows connecting to existing databases from `StreamingAssets` (`ConnectDB`) or creating new ones (`CreateSQLiteDatabase`).
* Raises the `OnStageChanged` event to track lifecycle stages (see `ElysiumStage`).
* Supports suspending/resuming processing of a specific extension event (`Suspend`/`Resume`).
* Implements `IDisposable` and a finalizer for resource cleanup.

### Declaration

```csharp
public class ElysiumDatabase : IDisposable
```

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Instance"></a>
<td><code>Instance</code></td>
<td>

```csharp
public static ElysiumDatabase Instance;
```

</td>
<td>The currently active database instance (set when <code>New()</code> is called, cleared on <code>Dispose()</code>).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Connections"></a>
<td><code>Connections</code></td>
<td>

```csharp
public Dictionary<string, DBMeta> Connections = new Dictionary<string, DBMeta>();
```

</td>
<td>Dictionary of active database connections keyed by relative path.</td>
</tr>
</table>

## Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Settings"></a>
<td><code>Settings</code></td>
<td>

```csharp
public static ElysiumDBSettings Settings { get; }
```

</td>
<td>Loads and returns `ElysiumDBSettings` via <code>Resources.Load</code> under the name "ElysiumDB Settings".</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.IsOffline"></a>
<td><code>IsOffline</code></td>
<td>

```csharp
public static bool IsOffline { get; }
```

</td>
<td>Returns <code>true</code> when <code>Application.internetReachability</code> equals <code>NotReachable</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.PlatformDataPath"></a>
<td><code>PlatformDataPath</code></td>
<td>

```csharp
public static string PlatformDataPath { get; }
```

</td>
<td>Returns the application data path: on Android — <code>/data/data/{identifier}</code>, on other platforms — <code>Application.persistentDataPath</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Item"></a>
<td><code>this[string database]</code></td>
<td>

```csharp
public DBMeta this[string database] { get; }
```

</td>
<td>An indexer providing access to a connection by database path (wraps <code>Connections[database]</code>).</td>
</tr>
</table>

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Log"></a>
<td><code>Log</code> / <code>LogWarning</code> / <code>LogError</code></td>
<td>

```csharp
public static void Log(string message)
public static void LogWarning(string message)
public static void LogError(string message)
```

</td>
<td>Enqueue a message into the internal log queue of the current instance (`Instance`), if one exists.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Suspend"></a>
<td><code>Suspend</code></td>
<td>

```csharp
public void Suspend(ExtensionEvent extensionEvent)
```

</td>
<td>Suspends further processing of the extension queue for the specified event.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Resume"></a>
<td><code>Resume</code></td>
<td>

```csharp
public void Resume(ExtensionEvent extensionEvent)
```

</td>
<td>Lifts the suspension and continues processing the extension queue for the specified event.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensionGeneric"></a>
<td><code>GetExtension&lt;T&gt;</code></td>
<td>

```csharp
public static T GetExtension<T>() where T : class
```

</td>
<td>Returns the first extension implementing/inheriting type <code>T</code>, or <code>null</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensionsGeneric"></a>
<td><code>GetExtensions&lt;T&gt;</code></td>
<td>

```csharp
public static T[] GetExtensions<T>() where T : class
```

</td>
<td>Returns an array of all extensions convertible to type <code>T</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.HasExtensionGeneric"></a>
<td><code>HasExtension&lt;T&gt;</code></td>
<td>

```csharp
public static bool HasExtension<T>() where T : class
```

</td>
<td>Checks whether at least one extension of type <code>T</code> exists.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.TryGetExtensionGeneric"></a>
<td><code>TryGetExtension&lt;T&gt;</code></td>
<td>

```csharp
public static bool TryGetExtension<T>(out T extension) where T : class
```

</td>
<td>Attempts to obtain an extension of type <code>T</code>; returns <code>true</code> on success.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.AddExtensionGeneric"></a>
<td><code>AddExtension&lt;T&gt;</code></td>
<td>

```csharp
public static T AddExtension<T>() where T : DBExtensionBase, new()
```

</td>
<td>Creates and adds a new extension of type <code>T</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.RemoveExtensionGeneric"></a>
<td><code>RemoveExtension&lt;T&gt;</code></td>
<td>

```csharp
public static bool RemoveExtension<T>() where T : DBExtensionBase
```

</td>
<td>Removes the first extension of type <code>T</code>, provided no other extension depends on it.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtension"></a>
<td><code>GetExtension(Type)</code></td>
<td>

```csharp
public static object GetExtension(Type type)
```

</td>
<td>Returns the first extension of the given type, or <code>null</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensions"></a>
<td><code>GetExtensions(Type)</code></td>
<td>

```csharp
public static object[] GetExtensions(Type type)
```

</td>
<td>Returns all extensions convertible to the given type; logs a warning if none are found.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.HasExtension"></a>
<td><code>HasExtension(Type)</code></td>
<td>

```csharp
public static bool HasExtension(Type type)
```

</td>
<td>Checks whether at least one extension of the given type exists.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.TryGetExtension"></a>
<td><code>TryGetExtension(Type, out object)</code></td>
<td>

```csharp
public static bool TryGetExtension(Type type, out object extension)
```

</td>
<td>Attempts to obtain the first extension of the given type.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.AddExtension"></a>
<td><code>AddExtension(Type)</code></td>
<td>

```csharp
public static object AddExtension(Type type)
```

</td>
<td>Creates an instance of the extension of the given type, verifies mandatory dependencies (`RequireExtensionAttribute` with `AutoCreate = false`), applies the default group, adds it to the settings list, and, if the system is already initialized, immediately processes the <code>Initialize</code> event. Throws an exception if the type does not inherit `DBExtensionBase` or a required dependency is missing.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.RemoveExtension"></a>
<td><code>RemoveExtension(Type)</code></td>
<td>

```csharp
public static bool RemoveExtension(Type type)
```

</td>
<td>Removes the extension of the given type, first checking that it is not the sole instance other extensions depend on. Invokes the `Dispose` processing of the removed extension.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetRequiresExtensions"></a>
<td><code>GetRequiresExtensions</code></td>
<td>

```csharp
public static List<Type> GetRequiresExtensions(Type extensionType)
```

</td>
<td>Returns the list of extension types that declare a dependency (`RequireExtensionAttribute`) on the given type.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.ProcessRequiredExtensions"></a>
<td><code>ProcessRequiredExtensions</code></td>
<td>

```csharp
public static void ProcessRequiredExtensions()
```

</td>
<td>Iterates over all current extensions and, for each missing mandatory dependency, either automatically creates it (if <code>AutoCreate = true</code>) or logs an error.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.New"></a>
<td><code>New</code></td>
<td>

```csharp
public void New()
```

</td>
<td>Initializes the system: closes old connections, connects all databases from <code>Settings.dbPaths</code>, runs extension processing for the <code>Initialize</code> event, and sets <code>Instance</code> to the current instance.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.DetachDB"></a>
<td><code>DetachDB</code></td>
<td>

```csharp
public void DetachDB(string path)
```

</td>
<td>Closes and removes the database connection at the given path.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.ConnectDB"></a>
<td><code>ConnectDB</code></td>
<td>

```csharp
public void ConnectDB(string path)
```

</td>
<td>Copies the database file from `StreamingAssets` into the platform data directory (if it does not already exist) and opens an SQLite connection.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.CreateSQLiteDatabase"></a>
<td><code>CreateSQLiteDatabase</code></td>
<td>

```csharp
public void CreateSQLiteDatabase(string path)
public void CreateSQLiteDatabase(string path, bool platformDataPath)
public void CreateSQLiteDatabase(
    string path,
    string connectionString,
    bool platformDataPath = true
)
public void CreateSQLiteDatabase(
    string path,
    SqliteConnectionStringBuilder userBuilder,
    bool platformDataPath = true
)
```

</td>
<td>Creates a new SQLite database at the given path (creating directories as needed) and registers the connection in <code>Connections</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.OpenSettings"></a>
<td><code>OpenSettings</code></td>
<td>

```csharp
#if UNITY_EDITOR
[MenuItem("ElysiumDB/Settings")]
public static void OpenSettings()
#endif
```

</td>
<td>Unity Editor menu item to open the `ElysiumDBSettings` settings window.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Dispose"></a>
<td><code>Dispose</code></td>
<td>

```csharp
public void Dispose()
```

</td>
<td>Closes all connections, runs extension processing for the <code>Dispose</code> event (in reverse order), and clears <code>Instance</code> if it points to the current instance.</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings"></a>
## ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings)

### Opportunities

* A `ScriptableObject` asset storing ElysiumDB configuration: database paths, the list of extensions (`SerializeReference`), and logging settings.
* Loaded via `Resources.Load` under the name "ElysiumDB Settings".
* Automatically created and kept up to date by `DBPostprocessor`.

### Declaration

```csharp
public class ElysiumDBSettings : ScriptableObject
```

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.logIgnorePatterns"></a>
<td><code>logIgnorePatterns</code></td>
<td>

```csharp
public List<string> logIgnorePatterns = new List<string>();
```

</td>
<td>A list of substrings; any log message containing one of them is ignored by the logger (`DBLogger`).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.dbPaths"></a>
<td><code>dbPaths</code></td>
<td>

```csharp
public List<string> dbPaths = new List<string>();
```

</td>
<td>A list of relative database paths connected when <code>ElysiumDatabase.New()</code> is called.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.extensions"></a>
<td><code>extensions</code></td>
<td>

```csharp
[SerializeReference]
public List<DBExtensionBase> extensions = new();
```

</td>
<td>The list of registered extensions (polymorphic serialization via <code>SerializeReference</code>).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showLogs"></a>
<td><code>showLogs</code></td>
<td>

```csharp
public bool showLogs = true;
```

</td>
<td>Master toggle for displaying ElysiumDB logs.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showSqlLogs"></a>
<td><code>showSqlLogs</code></td>
<td>

```csharp
public bool showSqlLogs = true;
```

</td>
<td>Toggle for displaying SQL query logs.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showCoreLogs"></a>
<td><code>showCoreLogs</code></td>
<td>

```csharp
public bool showCoreLogs = true;
```

</td>
<td>Toggle for displaying core logs and database loader logs.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showDefaultLogs"></a>
<td><code>showDefaultLogs</code></td>
<td>

```csharp
public bool showDefaultLogs = true;
```

</td>
<td>Toggle for displaying default-level logs (`ContextLevel.Default`).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showExtensionProccesingLogs"></a>
<td><code>showExtensionProccesingLogs</code></td>
<td>

```csharp
public bool showExtensionProccesingLogs = true;
```

</td>
<td>Toggle for displaying extension-processing logs.</td>
</tr>
</table>

## Properties
None

## Methods
None

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor"></a>
## ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor

### Opportunities

* A custom `Editor` for `ElysiumDBSettings`: displays database path and log filter lists, log-level toggles, `ElysiumDatabase` initialization status, and the extension list.
* Allows initializing/disposing `ElysiumDatabase` directly from the inspector, connecting/disconnecting individual databases, copying paths, and opening database files.

### Declaration

```csharp
[CustomEditor(typeof(ElysiumDBSettings))]
public class ElysiumDBSettingsEditor : UnityEditor.Editor
```

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.elysiumDBSettings"></a>
<td><code>elysiumDBSettings</code></td>
<td>

```csharp
public ElysiumDBSettings elysiumDBSettings;
```

</td>
<td>Reference to the settings asset being edited.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.listLogsFilter"></a>
<td><code>listLogsFilter</code></td>
<td>

```csharp
public CustomList listLogsFilter;
```

</td>
<td>Editable list of log filters (see `CustomList`).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.listOfPathDB"></a>
<td><code>listOfPathDB</code></td>
<td>

```csharp
public CustomList listOfPathDB;
```

</td>
<td>Editable list of database paths.</td>
</tr>
</table>

## Properties
None

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.OnInspectorGUI"></a>
<td><code>OnInspectorGUI</code></td>
<td>

```csharp
public override void OnInspectorGUI()
```

</td>
<td>Draws the main inspector: lists, log toggles, ElysiumDB info, and the extensions list.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawLogToggle"></a>
<td><code>DrawLogToggle</code> (private)</td>
<td>

```csharp
private void DrawLogToggle(string title, string propertyName)
```

</td>
<td>Draws the toggle for a specific logging category.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawStatus"></a>
<td><code>DrawStatus</code></td>
<td>

```csharp
bool DrawStatus(
    string label,
    bool state,
    string trueText = "TRUE",
    string falseText = "FALSE"
)
```

</td>
<td>Draws a status row with a colored indicator and returns <code>true</code> if the row was clicked.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawElysiumDBInfo"></a>
<td><code>DrawElysiumDBInfo</code> (private)</td>
<td>

```csharp
void DrawElysiumDBInfo()
```

</td>
<td>Draws the info block: initialization status, internet availability, paths, and the list of connected/disconnected databases.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawExtensions"></a>
<td><code>DrawExtensions</code> (private)</td>
<td>

```csharp
void DrawExtensions()
```

</td>
<td>Draws the extensions block via `DBExtensionDrawer.DrawExtensionsList`.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.ShowOpenMenu"></a>
<td><code>ShowOpenMenu</code> (private)</td>
<td>

```csharp
void ShowOpenMenu(string sourcePath, string runtimePath)
```

</td>
<td>Shows a context menu for opening the source or runtime version of a database file.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.OpenFile"></a>
<td><code>OpenFile</code> (private)</td>
<td>

```csharp
void OpenFile(string path)
```

</td>
<td>Opens the file with the default external application via <code>Process.Start</code>.</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase"></a>
## ModuDevCore.ElysiumDB.Extension.DBExtensionBase
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Extension.DBExtensionBase)

### Opportunities

* The base class for all ElysiumDB extensions. Derived classes override `OnInitialize`/`OnDispose` to implement their own logic.
* Provides convenience wrappers for accessing other extensions (`GetExtension`, `GetExtensions`, `HasExtension`, `AddExtension`, `RemoveExtension`).
* Supports being enabled/disabled (`enabled`), belonging to an inspector group (`extensionGroup`), and a unique identifier (`extensionId`) automatically assigned by `DBPostprocessor.SafetyFixExtensions`.
* Marked `[Serializable]` for Unity serialization (used together with `SerializeReference` in `ElysiumDBSettings.extensions`).

### Declaration

```csharp
[Serializable]
public class DBExtensionBase
```

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.enabled"></a>
<td><code>enabled</code></td>
<td>

```csharp
[HideInInspector]
public bool enabled = true;
```

</td>
<td>Determines whether the extension is active (affects processing of the <code>Initialize</code> event).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionGroup"></a>
<td><code>extensionGroup</code></td>
<td>

```csharp
[HideInInspector]
public string extensionGroup = "";
```

</td>
<td>The extension's group path in the inspector (e.g. "Auth/Sub").</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionId"></a>
<td><code>extensionId</code></td>
<td>

```csharp
[HideInInspector]
public int extensionId = -1;
```

</td>
<td>Unique extension identifier, automatically assigned by `DBPostprocessor.SafetyFixExtensions`.</td>
</tr>
</table>

## Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionName"></a>
<td><code>extensionName</code></td>
<td>

```csharp
public string extensionName { get; }
```

</td>
<td>Returns the current extension's type name (`GetType().Name`).</td>
</tr>
</table>

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Process"></a>
<td><code>Process</code></td>
<td>

```csharp
public void Process(
    ExtensionEvent ev,
    ElysiumDatabase еlysium = null
)
```

</td>
<td>An internal method invoked by `ElysiumDatabase` to process an event: on <code>Initialize</code> (if <code>enabled == true</code>) it calls <code>OnInitialize</code>; on <code>Dispose</code> — <code>OnDispose</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtensionGeneric"></a>
<td><code>GetExtension&lt;T&gt;</code></td>
<td>

```csharp
public T GetExtension<T>() where T : class
```

</td>
<td>Wrapper over `ElysiumDatabase.GetExtension&lt;T&gt;`.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtensionsGeneric"></a>
<td><code>GetExtensions&lt;T&gt;</code></td>
<td>

```csharp
public T[] GetExtensions<T>() where T : class
```

</td>
<td>Wrapper over `ElysiumDatabase.GetExtensions&lt;T&gt;`.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.TryGetExtensions"></a>
<td><code>TryGetExtensions&lt;T&gt;</code></td>
<td>

```csharp
public bool TryGetExtensions<T>(out T[] extensions) where T : class
```

</td>
<td>Retrieves all extensions of type <code>T</code> and returns <code>true</code> if at least one was found.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.HasExtension"></a>
<td><code>HasExtension&lt;T&gt;</code></td>
<td>

```csharp
public bool HasExtension<T>() where T : class
```

</td>
<td>Wrapper over `ElysiumDatabase.HasExtension&lt;T&gt;`.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.AddExtension"></a>
<td><code>AddExtension&lt;T&gt;</code></td>
<td>

```csharp
public T AddExtension<T>() where T : DBExtensionBase, new()
```

</td>
<td>Wrapper over `ElysiumDatabase.AddExtension&lt;T&gt;`.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.RemoveExtension"></a>
<td><code>RemoveExtension&lt;T&gt;</code></td>
<td>

```csharp
public bool RemoveExtension<T>() where T : DBExtensionBase, new()
```

</td>
<td>Wrapper over `ElysiumDatabase.RemoveExtension&lt;T&gt;`.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnInitialize"></a>
<td><code>OnInitialize</code></td>
<td>

```csharp
protected virtual void OnInitialize(ElysiumDatabase elysium) {}
```

</td>
<td>Overridden by derived classes to implement extension initialization logic.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnDispose"></a>
<td><code>OnDispose</code></td>
<td>

```csharp
protected virtual void OnDispose() {}
```

</td>
<td>Overridden by derived classes to implement cleanup logic when the extension is disposed.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Log"></a>
<td><code>Log</code></td>
<td>

```csharp
public void Log(object message)
```

</td>
<td>Logs a message via `DBLogger.LogContext`, using the current extension's name as the context.</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer"></a>
## ModuDevCore.ElysiumDB.Editor.ExtensionDrawer
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer)

### Opportunities

* An abstract base `PropertyDrawer` for extensions (`DBExtensionBase`), providing access to `ElysiumDatabase.Settings`, `target` (the current property value), and helper methods for working with extensions.
* Provides sealed implementations of `OnGUI`/`GetPropertyHeight` that delegate the extension points `OnExtensionGUI`/`GetExtensionHeight` to derived classes.
* Contains utilities for drawing default fields (`DrawDefaultExtension`) and computing their total height (`GetChildrenHeight`).

### Declaration

```csharp
public abstract class ExtensionDrawer : PropertyDrawer
```

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.target"></a>
<td><code>target</code></td>
<td>

```csharp
public object target = null;
```

</td>
<td>The boxed value of the currently serialized extension property (set in `OnGUI`).</td>
</tr>
</table>

## Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.Settings"></a>
<td><code>Settings</code></td>
<td>

```csharp
protected ElysiumDBSettings Settings { get; }
```

</td>
<td>Wrapper over `ElysiumDatabase.Settings`.</td>
</tr>
</table>

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetExtensionGeneric"></a>
<td><code>GetExtension&lt;T&gt;</code></td>
<td>

```csharp
public T GetExtension<T>() where T : class
```

</td>
<td>Wrapper over `ElysiumDatabase.GetExtension&lt;T&gt;`.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetExtensionsGeneric"></a>
<td><code>GetExtensions&lt;T&gt;</code></td>
<td>

```csharp
public T[] GetExtensions<T>() where T : class
```

</td>
<td>Wrapper over `ElysiumDatabase.GetExtensions&lt;T&gt;`.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.TryGetExtensions"></a>
<td><code>TryGetExtensions&lt;T&gt;</code></td>
<td>

```csharp
public bool TryGetExtensions<T>(out T[] extensions) where T : class
```

</td>
<td>Retrieves all extensions of type <code>T</code>, returns <code>true</code> if at least one was found.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.HasExtension"></a>
<td><code>HasExtension&lt;T&gt;</code></td>
<td>

```csharp
public bool HasExtension<T>() where T : class
```

</td>
<td>Wrapper over `ElysiumDatabase.HasExtension&lt;T&gt;`.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.AddExtension"></a>
<td><code>AddExtension&lt;T&gt;</code></td>
<td>

```csharp
public T AddExtension<T>() where T : DBExtensionBase, new()
```

</td>
<td>Wrapper over `ElysiumDatabase.AddExtension&lt;T&gt;`.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.RemoveExtension"></a>
<td><code>RemoveExtension&lt;T&gt;</code></td>
<td>

```csharp
public bool RemoveExtension<T>() where T : DBExtensionBase, new()
```

</td>
<td>Wrapper over `ElysiumDatabase.RemoveExtension&lt;T&gt;`.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.OnGUI"></a>
<td><code>OnGUI</code></td>
<td>

```csharp
public sealed override void OnGUI(
    Rect position,
    SerializedProperty property,
    GUIContent label
)
```

</td>
<td>Sets `target` from `property.boxedValue` and delegates drawing to the `OnExtensionGUI` method.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.OnExtensionGUI"></a>
<td><code>OnExtensionGUI</code></td>
<td>

```csharp
protected virtual void OnExtensionGUI(
    Rect position,
    SerializedProperty property,
    GUIContent label
)
```

</td>
<td>Extension point for drawing a specific extension; overridden by derived classes.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetPropertyHeight"></a>
<td><code>GetPropertyHeight</code></td>
<td>

```csharp
public sealed override float GetPropertyHeight(
    SerializedProperty property,
    GUIContent label
)
```

</td>
<td>Delegates height computation to the `GetExtensionHeight` method.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetExtensionHeight"></a>
<td><code>GetExtensionHeight</code></td>
<td>

```csharp
protected virtual float GetExtensionHeight(
    SerializedProperty property,
    GUIContent label
)
```

</td>
<td>Extension point for computing draw height; returns 0 by default.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.DrawDefaultExtension"></a>
<td><code>DrawDefaultExtension</code></td>
<td>

```csharp
public void DrawDefaultExtension(
    Rect position,
    SerializedProperty property
)
```

</td>
<td>Draws all visible child properties of the extension sequentially (similar to the default inspector).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetChildrenHeight"></a>
<td><code>GetChildrenHeight</code></td>
<td>

```csharp
public float GetChildrenHeight(SerializedProperty property)
```

</td>
<td>Computes the total height of all visible child properties.</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer

### Opportunities

* The default `ExtensionDrawer` implementation for all `DBExtensionBase` derivatives that do not have their own custom drawer.
* Simply delegates drawing and height computation to the base class's default methods.

### Declaration

```csharp
[CustomPropertyDrawer(typeof(DBExtensionBase), true)]
public class DBExtensionBaseDrawer : ExtensionDrawer
```

## Fields
None

## Properties
None

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer.OnExtensionGUI"></a>
<td><code>OnExtensionGUI</code></td>
<td>

```csharp
protected override void OnExtensionGUI(
    Rect position,
    SerializedProperty property,
    GUIContent label
)
```

</td>
<td>Draws the extension's default fields via `DrawDefaultExtension`.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer.GetExtensionHeight"></a>
<td><code>GetExtensionHeight</code></td>
<td>

```csharp
protected override float GetExtensionHeight(
    SerializedProperty property,
    GUIContent label
)
```

</td>
<td>Returns the total height of child fields via `GetChildrenHeight`.</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList

### Opportunities

* A custom editable string list for a `SerializedProperty` (string array), supporting deletion by click/when a row becomes empty, keyboard navigation between elements with up/down arrows, and adding a new element through an input field.
* Uses `IMGUITextFieldPro` for input fields instead of the standard `EditorGUILayout.TextField`.

### Declaration

```csharp
public class CustomList
```

## Fields
None

## Properties
None

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList.ctor"></a>
<td><code>CustomList</code> (constructor)</td>
<td>

```csharp
public CustomList(
    SerializedProperty list,
    string label,
    SerializedObject serializedObject,
    string placeholder = ""
)
```

</td>
<td>Creates an editable list for the given array property, with a title and a placeholder for the new-element field.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList.Draw"></a>
<td><code>Draw</code></td>
<td>

```csharp
public void Draw()
```

</td>
<td>Draws the list of elements with editing fields, a delete button, and the field for adding a new element.</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer

### Opportunities

* A static class that draws the extension list in the `ElysiumDBSettings` inspector with support for nested groups (folders), context menus (delete, move up/down, move between groups), and a panel for adding new extensions.
* Parses the flat list of extensions into an `IInspectorElement` hierarchy (groups and elements) based on the string `extensionGroup` path (segments separated by `/`).
* Caches class icons, script GUIDs, and the expanded/collapsed state of groups/elements.

### Declaration

```csharp
public static class DBExtensionDrawer
```

## Fields
None

## Properties
None

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.TryGetGroup"></a>
<td><code>TryGetGroup</code></td>
<td>

```csharp
public static bool TryGetGroup(
    string groupName,
    out IInspectorElement group
)
```

</td>
<td>Looks up a root group by name among the current <code>inspectorElements</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.ValidateGroups"></a>
<td><code>ValidateGroups</code></td>
<td>

```csharp
public static void ValidateGroups(SerializedProperty property)
```

</td>
<td>Rebuilds the `inspectorElements` hierarchy (groups/extensions) from the current state of the extensions array and their <code>extensionGroup</code> field.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.GenerateNewGroupName"></a>
<td><code>GenerateNewGroupName</code></td>
<td>

```csharp
public static string GenerateNewGroupName(
    IEnumerable<IInspectorElement> elements
)
```

</td>
<td>Generates a unique new group name in the format <code>"New Group N"</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.DrawExtensionsList"></a>
<td><code>DrawExtensionsList</code></td>
<td>

```csharp
public static void DrawExtensionsList(
    SerializedProperty property,
    Type baseType
)
```

</td>
<td>Main entry point: validates groups, draws the element hierarchy, and draws the panel for adding new extensions (derived from <code>baseType</code>).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.ShowContextMenuGroup"></a>
<td><code>ShowContextMenuGroup</code></td>
<td>

```csharp
public static void ShowContextMenuGroup(
    SerializedProperty property,
    int currentIndex,
    int inspectorElementsIndex,
    List<IInspectorElement> elements,
    PropertyGroup propertyGroup
)
```

</td>
<td>Shows the group's context menu: delete, move up/down.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.ShowContextMenuExtension"></a>
<td><code>ShowContextMenuExtension</code></td>
<td>

```csharp
public static void ShowContextMenuExtension(
    SerializedProperty property,
    int currentIndex,
    SerializedProperty groupProp,
    Type targetType,
    int inspectorElementsIndex,
    List<IInspectorElement> elements
)
```

</td>
<td>Shows the extension's context menu: delete (with dependency checking), move up/down, move to another group or create a new group.</td>
</tr>
</table>

## Enum
None

## Nested Classes

<table>
<tr>
<th>Class</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.IInspectorElement"></a>
<td><code>IInspectorElement</code></td>
<td>

```csharp
public interface IInspectorElement
{
    bool IsGroup { get; }
    bool IsExtension { get; }
    int Index { get; set; }
}
```

</td>
<td>The common interface for elements in the extension inspector hierarchy (either a group or an extension).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup"></a>
<td><code>PropertyGroup</code></td>
<td>

```csharp
public class PropertyGroup : IInspectorElement
{
    public string GroupName;
    public int Index;
    public List<IInspectorElement> Elements;

    public void DeleteGroup();
    public void MigrateToNewGroupName(string newName);
}
```

</td>
<td>Represents a group (folder) in the extension hierarchy; supports deleting the group (shifting child elements up one level) and renaming with path migration for all nested elements.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyExtension"></a>
<td><code>PropertyExtension</code></td>
<td>

```csharp
public class PropertyExtension : IInspectorElement
{
    public int Index;
    public SerializedProperty SerializedProperty;
}
```

</td>
<td>Represents a single extension (leaf) in the inspector hierarchy.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.SerializedPropertyExtensions"></a>
<td><code>SerializedPropertyExtensions</code></td>
<td>

```csharp
public static class SerializedPropertyExtensions
{
    public static int IndexOf(
        this SerializedProperty arrayProperty,
        SerializedProperty elementToFind
    );
}
```

</td>
<td>An extension method for finding the index of an element inside a `SerializedProperty` array by matching its content.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GroupPathDropdown"></a>
<td><code>GroupPathDropdown</code></td>
<td>

```csharp
public class GroupPathDropdown : AdvancedDropdown
{
    public GroupPathDropdown(
        AdvancedDropdownState state,
        SerializedProperty property,
        SerializedProperty groupProp,
        List<(string path, PropertyGroup group)> allGroups
    );
}
```

</td>
<td>A helper `AdvancedDropdown` for selecting the target group (path) when moving an extension between groups, presented as a tree menu.</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro

### Opportunities

* A custom IMGUI text field implementation supporting a caret, mouse and keyboard text selection, copy/cut/paste (Ctrl+C/X/V), word deletion (Ctrl+Backspace/Delete), word navigation (Ctrl+Left/Right), a placeholder, and a styled background with an accent highlight on focus.
* Used as a replacement for the standard `EditorGUILayout.TextField` in `CustomList` and `DBExtensionDrawer` for more flexible behavior control.

### Declaration

```csharp
public class IMGUITextFieldPro
```

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.text"></a>
<td><code>text</code></td>
<td>

```csharp
public string text;
```

</td>
<td>The field's current text.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.caret"></a>
<td><code>caret</code> / <code>select</code></td>
<td>

```csharp
public int caret;
public int select;
```

</td>
<td>Caret position and selection-start position (the range between them is the selected text).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.hasFocus"></a>
<td><code>hasFocus</code></td>
<td>

```csharp
public bool hasFocus;
```

</td>
<td>Indicates whether the field is currently focused (compared against `GUIUtility.keyboardControl`).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.placeholder"></a>
<td><code>placeholder</code></td>
<td>

```csharp
public string placeholder;
```

</td>
<td>Placeholder text shown when the field is empty and not focused.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.drawBackground"></a>
<td><code>drawBackground</code></td>
<td>

```csharp
public bool drawBackground = true;
```

</td>
<td>Determines whether the field's styled background should be drawn.</td>
</tr>
</table>

## Properties
None

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.Draw"></a>
<td><code>Draw</code></td>
<td>

```csharp
public void Draw()
public void Draw(Rect rect)
```

</td>
<td>Draws the input field (automatically computing the `Rect` when called with no arguments), handling focus, keyboard, mouse, background, selection, text, and caret.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.Focus"></a>
<td><code>Focus</code></td>
<td>

```csharp
public void Focus()
```

</td>
<td>Programmatically focuses the field and moves the caret to the end of the text.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.SetSelection"></a>
<td><code>SetSelection</code></td>
<td>

```csharp
public void SetSelection(int start, int end)
```

</td>
<td>Sets the text selection range.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.SelectAll"></a>
<td><code>SelectAll</code></td>
<td>

```csharp
public void SelectAll()
```

</td>
<td>Selects all of the field's text.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.ClearSelection"></a>
<td><code>ClearSelection</code></td>
<td>

```csharp
public void ClearSelection()
```

</td>
<td>Clears the selection (sets <code>select = caret</code>).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.GetSelectedText"></a>
<td><code>GetSelectedText</code></td>
<td>

```csharp
public string GetSelectedText()
```

</td>
<td>Returns the currently selected text fragment.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.HasSelection"></a>
<td><code>HasSelection</code></td>
<td>

```csharp
public bool HasSelection()
```

</td>
<td>Returns <code>true</code> if there is an active text selection (<code>caret != select</code>).</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor

### Opportunities

* An `AssetPostprocessor` that automatically maintains the `ElysiumDBSettings` asset in a correct state: creates the required folders (`Assets/ElysiumDB`, `Assets/ElysiumDB/Resources`), creates the settings asset if it is missing, and moves it to the correct path if it was manually moved.
* Reacts only to changes affecting a path containing "ElysiumDB" (`IsRelevant`).
* Automatically fixes and assigns unique `extensionId` values for all extensions (`SafetyFixExtensions`), removing `null` entries and processing mandatory dependencies.

### Declaration

```csharp
public class DBPostprocessor : AssetPostprocessor
```

## Fields
None

## Properties
None

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.SafetyFixExtensions"></a>
<td><code>SafetyFixExtensions</code></td>
<td>

```csharp
public static void SafetyFixExtensions()
```

</td>
<td>Removes empty (`null`) extension entries, processes mandatory dependencies (`ProcessRequiredExtensions`), and reassigns unique positive <code>extensionId</code> values to extensions whose current identifier is duplicated, missing, or invalid.</td>
</tr>
</table>

The internal (private/static) methods `OnPostprocessAllAssets`, `IsRelevant`, `SafetyFix`, `EnsureFolders`, `FindSettings` implement the automatic initialization and synchronization of the settings asset and are not part of the public API.

## Enum
None

## Nested Classes
None

---

<a id="AuthElysiumDB"></a>
## AuthElysiumDB
[REFERENCE.md](./REFERENCE.md#AuthElysiumDB)

### Opportunities

* A ready-to-use authentication extension: stores the JWT token, expiry date, and user identifier in a dedicated SQLite table (`AuthSession`) within its own `AuthElysiumDB.db` database.
* On initialization, creates its database and table and restores a saved session, notifying subscribers (`IAuthElysiumReceiver`) of token changes and handing control to them to load user data.
* Extracts `exp` (expiration) and `sub` (user identifier) directly from the JWT payload without verifying the signature.
* On disposal, detaches its database if it was connected.

### Declaration

```csharp
public class AuthElysiumDB : DBExtensionBase
```

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="AuthElysiumDB.authTable"></a>
<td><code>authTable</code></td>
<td>

```csharp
public DBMeta authTable;
```

</td>
<td>Connection to the <code>AuthElysiumDB.db</code> database containing the authentication session table.</td>
</tr>
</table>

## Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="AuthElysiumDB.IsAuthenticated"></a>
<td><code>IsAuthenticated</code></td>
<td>

```csharp
public bool IsAuthenticated { get; private set; }
```

</td>
<td>Indicates whether there is an active authenticated session.</td>
</tr>
</table>

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="AuthElysiumDB.Auth"></a>
<td><code>Auth</code></td>
<td>

```csharp
public async Task Auth(string credentials)
```

</td>
<td>Inserts or updates the JWT token, expiry date, and user identifier in the <code>AuthSession</code> table, sets <code>IsAuthenticated = true</code>, notifies subscribers, and starts loading the user data.</td>
</tr>

<tr>
<a id="AuthElysiumDB.SignOut"></a>
<td><code>SignOut</code></td>
<td>

```csharp
public void SignOut()
```

</td>
<td>Deletes the session record from the table, resets <code>IsAuthenticated</code> to <code>false</code>, and notifies subscribers that the token was reset (<code>null</code>).</td>
</tr>

<tr>
<a id="AuthElysiumDB.GetCredentials"></a>
<td><code>GetCredentials</code></td>
<td>

```csharp
public ElysiumAuthCredentials GetCredentials()
```

</td>
<td>Returns the currently stored credentials (`jwt_token`, `user_id`) from the session table.</td>
</tr>

<tr>
<a id="AuthElysiumDB.OnDispose"></a>
<td><code>OnDispose</code></td>
<td>

```csharp
protected override void OnDispose()
```

</td>
<td>Detaches the <code>AuthElysiumDB.db</code> database if it was connected.</td>
</tr>
</table>

## Enum
None

## Nested Classes

<table>
<tr>
<th>Class</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ElysiumAuthCredentials"></a>
<td><code>ElysiumAuthCredentials</code></td>
<td>

```csharp
public class ElysiumAuthCredentials
{
    public string jwt_token { get; set; }
    public string user_id { get; set; }
}
```

</td>
<td>A POCO model used to map an `AuthSession` table row when reading credentials.</td>
</tr>

<tr>
<a id="IAuthElysiumReceiver"></a>
<td><code>IAuthElysiumReceiver</code></td>
<td>

```csharp
public interface IAuthElysiumReceiver
{
    void OnAuthTokenUpdated(string newJwt);
    void OnAuthLoggedOut();
    Task OnFetchAuthUserData(DBMeta authTable);
}
```

</td>
<td>An interface implemented by other extensions that need to react to authentication state changes: token updates, sign-outs, and loading user data after authorization.</td>
</tr>
</table>

---

<a id="AuthElysiumDBDrawer"></a>
## AuthElysiumDBDrawer

### Opportunities

* A custom `PropertyDrawer` for `AuthElysiumDB` that displays the authentication status, a collapsible credentials block, and "Refresh" and "Clear Session" buttons (with a confirmation dialog).
* Only works while an active `ElysiumDatabase.Instance` exists; otherwise it displays a warning.

### Declaration

```csharp
#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(AuthElysiumDB))]
public class AuthElysiumDBDrawer : PropertyDrawer
#endif
```

## Fields
None

## Properties
None

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="AuthElysiumDBDrawer.OnGUI"></a>
<td><code>OnGUI</code></td>
<td>

```csharp
public override void OnGUI(
    Rect position,
    SerializedProperty property,
    GUIContent label
)
```

</td>
<td>Draws the authentication status, a collapsible "Credentials" block, and session-management buttons (refresh/clear).</td>
</tr>

<tr>
<a id="AuthElysiumDBDrawer.GetPropertyHeight"></a>
<td><code>GetPropertyHeight</code></td>
<td>

```csharp
public override float GetPropertyHeight(
    SerializedProperty property,
    GUIContent label
)
```

</td>
<td>Computes the height needed to draw all child fields and additional UI elements.</td>
</tr>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Internal.DBLogger"></a>
## ModuDevCore.ElysiumDB.Internal.DBLogger
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Internal.DBLogger)

### Opportunities

* A centralized ElysiumDB logging system with support for context levels (`ContextLevel`) and filtering based on settings (`ElysiumDBSettings`): a master log toggle, per-category toggles (SQL, Core, ExtensionProccesing, Default), and substring-based filtering (`logIgnorePatterns`).
* Used by all ElysiumDB components (`DBMeta`, `ElysiumDatabase`, `DBExtensionBase`, extensions) for consistent log output with color formatting via rich text (`<color>`).

### Declaration

```csharp
public static class DBLogger
```

## Fields
None

## Properties
None

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Internal.DBLogger.Log"></a>
<td><code>Log</code></td>
<td>

```csharp
public static void Log(
    object message,
    ContextLevel contextLevel = ContextLevel.Default
)
```

</td>
<td>Outputs a message via <code>Debug.Log</code> if it is not filtered out by the current logging settings.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Internal.DBLogger.LogContext"></a>
<td><code>LogContext</code></td>
<td>

```csharp
public static void LogContext(
    string contextName,
    object message,
    ContextLevel contextLevel = ContextLevel.Default
)
```

</td>
<td>Outputs a message with a context prefix (e.g. the extension's name), colored purple by default.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Internal.DBLogger.DefaultExtensionNamePrefixColor"></a>
<td><code>DefaultExtensionNamePrefixColor</code></td>
<td>

```csharp
public static string DefaultExtensionNamePrefixColor(string prefix)
```

</td>
<td>Formats the prefix string into a rich-text color tag (<code>#9575CD</code>) used by <code>LogContext</code>.</td>
</tr>
</table>

## Enum

<table>
<tr>
<th>Enum</th>
<th>Values</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Internal.DBLogger.ContextLevel"></a>
<td><code>ContextLevel</code></td>
<td>

```csharp
public enum ContextLevel {
    Default,
    Core,
    Hidden,
    SQLQuery,
    DBLoader,
    ExtensionProccesing,
}
```

</td>
<td>
<code>Default</code> — regular logs (controlled by <code>showDefaultLogs</code>).<br/>
<code>Core</code> — core-level logs (controlled by <code>showCoreLogs</code>).<br/>
<code>Hidden</code> — logs that are always ignored (never output).<br/>
<code>SQLQuery</code> — SQL query logs (controlled by <code>showSqlLogs</code>).<br/>
<code>DBLoader</code> — database loading/connection logs (controlled by <code>showCoreLogs</code>).<br/>
<code>ExtensionProccesing</code> — extension processing logs (controlled by <code>showExtensionProccesingLogs</code>).
</td>
</tr>
</table>

## Nested Classes
    None