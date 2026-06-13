# ElysiumDB — Technical Documentation (Internal)

> This file is intended for developers. It contains **ALL** classes, structures, interfaces, enumerations, and auxiliary types from the project (snapshot.md).  
> Public API — see `REFERENCE.md` (only public types intended for end users).

---

## Guide (Navigation)

<details>
<summary>ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute</summary>

### Parent
[ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute](#ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute)

### Fields
- [ExtensionGroup](#ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute.ExtensionGroup)

### Methods
- [DefaultExtensionGroupAttribute](#ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute.DefaultExtensionGroupAttribute)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute</summary>

### Parent
[ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute](#ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute)

### Properties
- [Group](#ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute.Group)
- [Order](#ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute.Order)

### Methods
- [ExtensionProcessOrderAttribute](#ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute.ExtensionProcessOrderAttribute)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute</summary>

### Parent
[ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute](#ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute)

### Fields
- [ExtensionType](#ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute.ExtensionType)
- [AutoCreate](#ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute.AutoCreate)

### Methods
- [RequireExtensionAttribute](#ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute.RequireExtensionAttribute)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Core.DBMeta</summary>

### Parent
[ModuDevCore.ElysiumDB.Core.DBMeta](#ModuDevCore.ElysiumDB.Core.DBMeta)

### Fields
- [connection](#ModuDevCore.ElysiumDB.Core.DBMeta.connection)

### Methods
- [Dispose](#ModuDevCore.ElysiumDB.Core.DBMeta.Dispose)
- [Query](#ModuDevCore.ElysiumDB.Core.DBMeta.Query)
- [QueryFirst](#ModuDevCore.ElysiumDB.Core.DBMeta.QueryFirst)
- [QueryList](#ModuDevCore.ElysiumDB.Core.DBMeta.QueryList)
- [QueryColumn](#ModuDevCore.ElysiumDB.Core.DBMeta.QueryColumn)
- [QueryValue](#ModuDevCore.ElysiumDB.Core.DBMeta.QueryValue)
- [QueryDictionary](#ModuDevCore.ElysiumDB.Core.DBMeta.QueryDictionary)
- [Execute](#ModuDevCore.ElysiumDB.Core.DBMeta.Execute)
- [Exists](#ModuDevCore.ElysiumDB.Core.DBMeta.Exists)
- [MapReaderToObject](#ModuDevCore.ElysiumDB.Core.DBMeta.MapReaderToObject) (private)
- [ShouldIgnoreLog](#ModuDevCore.ElysiumDB.Core.DBMeta.ShouldIgnoreLog) (private)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Core.ElysiumDatabase</summary>

### Parent
[ModuDevCore.ElysiumDB.Core.ElysiumDatabase](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase)

### Fields / Properties
- [Instance](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Instance)
- [Connections](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Connections)
- [Settings](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Settings)
- [IsOffline](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.IsOffline)
- [PlatformDataPath](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.PlatformDataPath)
- [this[string]](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Item)

### Methods (static + instance)
- [New](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.New)
- [Dispose](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Dispose)
- [ConnectDB](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.ConnectDB)
- [DetachDB](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.DetachDB)
- [Log / LogWarning / LogError](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Log)
- [GetExtension<T> / GetExtensions<T>](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.GetExtension)
- [HasExtension<T>](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.HasExtension)
- [TryGetExtension<T>](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.TryGetExtension)
- [AddExtension<T> / AddExtension](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.AddExtension)
- [RemoveExtension<T> / RemoveExtension](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.RemoveExtension)
- [GetRequiresExtensions](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.GetRequiresExtensions)
- [ProcessRequiredExtensions](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.ProcessRequiredExtensions)
- [RunExtensionsProcess](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.RunExtensionsProcess) (private)
- [SafeProcess](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.SafeProcess) (private)
- [LoadFileBytes / EnsureFileExists](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.LoadFileBytes) (private)
- [OpenSettings](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.OpenSettings)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings</summary>

### Parent
[ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings)

### Fields
- [logIgnorePatterns](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.logIgnorePatterns)
- [dbPaths](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.dbPaths)
- [extensions](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.extensions)
- [showLogs](#ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showLogs)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor</summary>

### Parent
[ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor)

### Methods
- [OnInspectorGUI](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.OnInspectorGUI)
- [DrawStatus](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawStatus)
- [DrawElysiumDBInfo](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawElysiumDBInfo)
- [DrawExtensions](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawExtensions)
- [ShowOpenMenu / OpenFile](#ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.ShowOpenMenu)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Extension.DBExtensionBase</summary>

### Parent
[ModuDevCore.ElysiumDB.Extension.DBExtensionBase](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase)

### Fields
- [enabled](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.enabled)
- [extensionGroup](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionGroup)
- [extensionId](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionId)
- [extensionName](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionName)

### Methods
- [Process](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Process)
- [GetExtension<T> / GetExtensions<T>](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtension)
- [HasExtension<T>](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.HasExtension)
- [AddExtension<T> / RemoveExtension<T>](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.AddExtension)
- [OnInitialize / OnDispose](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnInitialize)
- [Log](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Log)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Editor.ExtensionDrawer</summary>

### Parent
[ModuDevCore.ElysiumDB.Editor.ExtensionDrawer](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer)

### Methods
- [OnGUI / OnExtensionGUI](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.OnGUI)
- [GetPropertyHeight / GetExtensionHeight](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetPropertyHeight)
- [DrawDefaultExtension](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.DrawDefaultExtension)
- [GetChildrenHeight](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetChildrenHeight)
- [GetExtension<T> / ...](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetExtension) (helper)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.CustomList</summary>

### Parent
[ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.CustomList](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.CustomList)

### Methods
- [Draw](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.CustomList.Draw)
- [DrawTextField](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.CustomList.DrawTextField)
- [CleanupUnused](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.CustomList.CleanupUnused)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionBaseDrawer</summary>

### Parent
[ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionBaseDrawer](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionBaseDrawer)

### Methods
- [OnExtensionGUI](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionBaseDrawer.OnExtensionGUI)
- [GetExtensionHeight](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionBaseDrawer.GetExtensionHeight)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer (static)</summary>

### Parent
[ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer)

### Nested Types
- [IInspectorElement](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.IInspectorElement)
- [PropertyGroup](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.PropertyGroup)
- [PropertyExtension](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.PropertyExtension)
- [SerializedPropertyExtensions](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.SerializedPropertyExtensions)
- [GroupPathDropdown](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.GroupPathDropdown)

### Key Static Methods
- [DrawExtensionsList](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.DrawExtensionsList)
- [ValidateGroups](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.ValidateGroups)
- [DrawInspectorElements](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.DrawInspectorElements)
- [DrawHeader](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.DrawHeader)
- [ShowContextMenuExtension / ShowContextMenuGroup](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.ShowContextMenuExtension)
- [GetClassIcon](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.GetClassIcon)
- [GenerateNewGroupName](#ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.GenerateNewGroupName)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor</summary>

### Parent
[ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor](#ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor)

### Methods
- [OnPostprocessAllAssets](#ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.OnPostprocessAllAssets)
- [SafetyFix / SafetyFixExtensions](#ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.SafetyFixExtensions)
- [EnsureFolders](#ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.EnsureFolders)
- [FindSettings](#ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.FindSettings)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Extension.AuthElysiumDB</summary>

### Parent
[ModuDevCore.ElysiumDB.Extension.AuthElysiumDB](#ModuDevCore.ElysiumDB.Extension.AuthElysiumDB)

### Fields / Properties
- [cacheFileName](#ModuDevCore.ElysiumDB.Extension.AuthElysiumDB.cacheFileName)
- [IsAuthenticated](#ModuDevCore.ElysiumDB.Extension.AuthElysiumDB.IsAuthenticated)

### Methods
- [OnInitialize / OnDispose](#ModuDevCore.ElysiumDB.Extension.AuthElysiumDB.OnInitialize)
- [Auth](#ModuDevCore.ElysiumDB.Extension.AuthElysiumDB.Auth)
- [SignOut](#ModuDevCore.ElysiumDB.Extension.AuthElysiumDB.SignOut)
- [GetCredentials](#ModuDevCore.ElysiumDB.Extension.AuthElysiumDB.GetCredentials)
- [NotifyAuthTokenUpdated](#ModuDevCore.ElysiumDB.Extension.AuthElysiumDB.NotifyAuthTokenUpdated)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Extension.AuthElysiumDBDrawer</summary>

### Parent
[ModuDevCore.ElysiumDB.Extension.AuthElysiumDBDrawer](#ModuDevCore.ElysiumDB.Extension.AuthElysiumDBDrawer)

### Methods
- [OnGUI](#ModuDevCore.ElysiumDB.Extension.AuthElysiumDBDrawer.OnGUI)
- [GetPropertyHeight](#ModuDevCore.ElysiumDB.Extension.AuthElysiumDBDrawer.GetPropertyHeight)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Extension.IAuthElysiumReceiver</summary>

### Parent
[ModuDevCore.ElysiumDB.Extension.IAuthElysiumReceiver](#ModuDevCore.ElysiumDB.Extension.IAuthElysiumReceiver)

### Methods
- [OnAuthTokenUpdated](#ModuDevCore.ElysiumDB.Extension.IAuthElysiumReceiver.OnAuthTokenUpdated)
- [OnAuthLoggedOut](#ModuDevCore.ElysiumDB.Extension.IAuthElysiumReceiver.OnAuthLoggedOut)

</details>

<details>
<summary>ModuDevCore.ElysiumDB.Internal.Data.ExtensionEvent</summary>

### Parent
[ModuDevCore.ElysiumDB.Internal.Data.ExtensionEvent](#ModuDevCore.ElysiumDB.Internal.Data.ExtensionEvent)

### Values
- [Initialize](#ModuDevCore.ElysiumDB.Internal.Data.ExtensionEvent.Initialize)
- [Dispose](#ModuDevCore.ElysiumDB.Internal.Data.ExtensionEvent.Dispose)

</details>

---

# Detailed Declarations

---

<a id="ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute"></a>
## ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute)

### Opportunities
* Allows declaratively specifying the default group for an extension when it is added via `ElysiumDatabase.AddExtension`.
* Simplifies extension organization in the editor (grouping in `DBExtensionDrawer`).
* Supports inheritance (`Inherited = true`).
* Used inside `ElysiumDatabase.AddExtension` to automatically set `extensionGroup`.

### Declaration

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public sealed class DefaultExtensionGroupAttribute : Attribute
{
    public string ExtensionGroup;

    public DefaultExtensionGroupAttribute(string extensionGroup);
}
```

Attribute for specifying the default extension group. Applied to classes that inherit from `DBExtensionBase`.

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute.ExtensionGroup"></a>
<td><code>ExtensionGroup</code></td>
<td>

```csharp
public string ExtensionGroup;
```

</td>
<td>Name of the default group (e.g. "Auth", "Core", "UI"). Used when creating the extension.</td>
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
<a id="ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute.DefaultExtensionGroupAttribute"></a>
<td><code>DefaultExtensionGroupAttribute</code></td>
<td>

```csharp
public DefaultExtensionGroupAttribute(string extensionGroup);
```

</td>
<td>Constructor. Sets `ExtensionGroup`.</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute"></a>
## ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute)

### Opportunities
* Allows controlling the initialization/disposal order of extensions within the same group.
* Used in `ElysiumDatabase.RunExtensionsProcess` for sorting via `OrderBy`.
* Ensures stable ordering (then by index in the list).
* Useful for dependent extensions (e.g. Auth should initialize before others).

### Declaration

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class ExtensionProcessOrderAttribute : Attribute
{
    public string Group { get; }
    public int Order { get; }

    public ExtensionProcessOrderAttribute(string group, int order = 0);
}
```

### Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute.Group"></a>
<td><code>Group</code></td>
<td>

```csharp
public string Group { get; }
```

</td>
<td>Name of the group to which the ordering applies. Defaults to `"Default"`.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute.Order"></a>
<td><code>Order</code></td>
<td>

```csharp
public int Order { get; }
```

</td>
<td>Order within the group (lower = earlier). Defaults to 0.</td>
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
<a id="ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute.ExtensionProcessOrderAttribute"></a>
<td><code>ExtensionProcessOrderAttribute</code></td>
<td>

```csharp
public ExtensionProcessOrderAttribute(string group, int order = 0);
```

</td>
<td>Constructor. If `group` is `null`, it is replaced with `"Default"`.</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute"></a>
## ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute)

### Opportunities
* Declaratively describes dependencies between extensions.
* Automatically creates required extensions (`AutoCreate = true`) in `ProcessRequiredExtensions`.
* Blocks deletion of an extension if other extensions depend on it (`GetRequiresExtensions` + check in `ShowContextMenuExtension`).
* Supports `AllowMultiple = true`.

### Declaration

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public sealed class RequireExtensionAttribute : Attribute
{
    public Type ExtensionType;
    public bool AutoCreate;

    public RequireExtensionAttribute(Type extensionType, bool autoCreate = true);
}
```

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute.ExtensionType"></a>
<td><code>ExtensionType</code></td>
<td>

```csharp
public Type ExtensionType;
```

</td>
<td>Type of the required extension (must inherit from `DBExtensionBase`).</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute.AutoCreate"></a>
<td><code>AutoCreate</code></td>
<td>

```csharp
public bool AutoCreate;
```

</td>
<td>If `true`, the extension is automatically created if missing. Defaults to `true`.</td>
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
<a id="ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute.RequireExtensionAttribute"></a>
<td><code>RequireExtensionAttribute</code></td>
<td>

```csharp
public RequireExtensionAttribute(Type extensionType, bool autoCreate = true);
```

</td>
<td>Dependency constructor.</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Core.DBMeta"></a>
## ModuDevCore.ElysiumDB.Core.DBMeta
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Core.DBMeta)

### Opportunities
* Wrapper around `IDbConnection` (SQLite) with convenient query and mapping methods.
* Automatic query logging with Caller attributes + filtering via `logIgnorePatterns`.
* Universal `MapReaderToObject<T>` with support for `PascalCase`/`camelCase` and nullable types.
* Supports `QueryFirst`, `QueryList`, `QueryValue`, `QueryDictionary`, `QueryColumn`.
* Implements `IDisposable` for safe connection cleanup.

### Declaration

```csharp
public class DBMeta : IDisposable
{
    public IDbConnection connection;

    // ... methods ...
}
```

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.connection"></a>
<td><code>connection</code></td>
<td>

```csharp
public IDbConnection connection;
```

</td>
<td>Active database connection (usually `SqliteConnectionNative`).</td>
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
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.Dispose"></a>
<td><code>Dispose</code></td>
<td>

```csharp
public void Dispose();
```

</td>
<td>Closes and disposes the connection.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.Query"></a>
<td><code>Query</code></td>
<td>

```csharp
public IDataReader Query(
    string cmd,
    int linesToRead = 0,
    [CallerMemberName] string callerMethod = "",
    [CallerFilePath] string callerFile = "",
    [CallerLineNumber] int callerLine = 0
);
```

</td>
<td>Executes SQL and returns an `IDataReader`. Logs the query (unless ignored).</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.QueryFirst"></a>
<td><code>QueryFirst&lt;T&gt;</code></td>
<td>

```csharp
public T QueryFirst<T>(string cmd, int linesToRead = 0, ...) where T : new();
```

</td>
<td>Returns the first result mapped to an object of type `T`.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.QueryList"></a>
<td><code>QueryList&lt;T&gt;</code></td>
<td>

```csharp
public List<T> QueryList<T>(string cmd, ...) where T : new();
```

</td>
<td>Returns a list of objects of type `T`.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.QueryColumn"></a>
<td><code>QueryColumn&lt;T&gt;</code></td>
<td>

```csharp
public List<T> QueryColumn<T>(string cmd);
```

</td>
<td>Returns values from the first column as `List<T>`.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.QueryValue"></a>
<td><code>QueryValue&lt;T&gt;</code></td>
<td>

```csharp
public T QueryValue<T>(string cmd, ...);
```

</td>
<td>Returns a scalar value.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.QueryDictionary"></a>
<td><code>QueryDictionary&lt;TKey, TValue&gt;</code></td>
<td>

```csharp
public Dictionary<TKey, TValue> QueryDictionary<TKey, TValue>(string cmd, ...);
```

</td>
<td>Returns a dictionary from two columns.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.Execute"></a>
<td><code>Execute</code></td>
<td>

```csharp
public void Execute(string cmd);
```

</td>
<td>Executes a non-query command (`INSERT`, `UPDATE`, `DELETE`, etc.).</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.Exists"></a>
<td><code>Exists</code></td>
<td>

```csharp
public bool Exists(string cmd);
```

</td>
<td>Checks whether at least one row exists.</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase"></a>
## ModuDevCore.ElysiumDB.Core.ElysiumDatabase
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Core.ElysiumDatabase)

### Opportunities
* Central singleton for managing multiple SQLite databases and extensions.
* Powerful extension system with grouping, initialization ordering, dependencies, and auto-creation.
* Convenient static methods: `GetExtension<T>`, `AddExtension<T>`, `RemoveExtension<T>`.
* Automatic processing of required extensions on startup.
* Android + StreamingAssets support (database copying).
* Custom logging system with queue and filters.
* Integration with `ElysiumDBSettings` (ScriptableObject).

### Declaration

```csharp
public class ElysiumDatabase : IDisposable
{
    public static ElysiumDatabase Instance;
    public Dictionary<string, DBMeta> Connections = new();
    // ... many static methods for working with extensions
}
```

## Fields / Indexer

<table>
<tr>
<th>Member</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Instance"></a>
<td><code>Instance</code></td>
<td>

```csharp
public static ElysiumDatabase Instance;
```

</td>
<td>Global instance (set in `New()`).</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Connections"></a>
<td><code>Connections</code></td>
<td>

```csharp
public Dictionary<string, DBMeta> Connections = new Dictionary<string, DBMeta>();
```

</td>
<td>Connections keyed by database path.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Item"></a>
<td><code>this[string database]</code></td>
<td>

```csharp
public DBMeta this[string database] { get => Connections[database]; }
```

</td>
<td>Quick access to `DBMeta` by path name.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Settings"></a>
<td><code>Settings</code></td>
<td>

```csharp
public static ElysiumDBSettings Settings => Resources.Load<ElysiumDBSettings>("ElysiumDB Settings");
```

</td>
<td>Global settings (ScriptableObject).</td>
</tr>
</table>

## Key Methods (selected)

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.New"></a>
<td><code>New</code></td>
<td>

```csharp
public void New();
```

</td>
<td>Initialization: clears old connections, runs `Initialize` on all extensions, connects all databases from settings.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Dispose"></a>
<td><code>Dispose</code></td>
<td>

```csharp
public void Dispose();
```

</td>
<td>Closes all connections + calls `Dispose` on extensions + clears `Instance`.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.ConnectDB"></a>
<td><code>ConnectDB</code></td>
<td>

```csharp
public void ConnectDB(string path);
```

</td>
<td>Copies the database from StreamingAssets (on Android) and opens the connection.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.AddExtension"></a>
<td><code>AddExtension</code></td>
<td>

```csharp
public static object AddExtension(Type type);
public static T AddExtension<T>() where T : DBExtensionBase, new();
```

</td>
<td>Creates the extension, applies `DefaultExtensionGroupAttribute`, calls `Initialize`, and adds it to `Settings.extensions`.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.RemoveExtension"></a>
<td><code>RemoveExtension</code></td>
<td>

```csharp
public static bool RemoveExtension(Type type);
```

</td>
<td>Calls `Dispose`, removes from the list, and saves the asset.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.GetExtension"></a>
<td><code>GetExtension&lt;T&gt;</code></td>
<td>

```csharp
public static T GetExtension<T>() where T : class;
public static object GetExtension(Type type);
```

</td>
<td>Returns the first extension of the specified type (or `null`).</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.ProcessRequiredExtensions"></a>
<td><code>ProcessRequiredExtensions</code></td>
<td>

```csharp
public static void ProcessRequiredExtensions();
```

</td>
<td>Processes all `RequireExtensionAttribute` attributes and creates missing extensions.</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings"></a>
## ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings

### Opportunities
* `ScriptableObject` for storing database paths, log ignore patterns, and the list of extensions (`[SerializeReference]`).
* Supports hot reload and editing in the inspector via a custom editor.
* Central storage location for the entire ElysiumDB system configuration.

### Declaration

```csharp
public class ElysiumDBSettings : ScriptableObject
{
    public List<string> logIgnorePatterns = new List<string>();
    public List<string> dbPaths = new List<string>();
    [SerializeReference]
    public List<DBExtensionBase> extensions = new();
    public bool showLogs = true;
}
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
<td>Patterns that are ignored in `DBMeta.Query` logs.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.dbPaths"></a>
<td><code>dbPaths</code></td>
<td>

```csharp
public List<string> dbPaths = new List<string>();
```

</td>
<td>Relative paths to SQLite files (relative to StreamingAssets).</td>
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
<td>List of all active extensions (polymorphic serializable storage).</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showLogs"></a>
<td><code>showLogs</code></td>
<td>

```csharp
public bool showLogs = true;
```

</td>
<td>Global flag for showing LiteSQL logs.</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor"></a>
## ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor

### Opportunities
* Full custom inspector for `ElysiumDBSettings`.
* Uses `CustomList` for editing database path lists and log filters.
* Shows initialization status, internet connection, database paths with connect/disconnect capability.
* Integrates with `DBExtensionDrawer` for powerful extension management UI (groups, drag & drop, context menus).
* Buttons to open source and runtime databases.

### Declaration

```csharp
[CustomEditor(typeof(ElysiumDBSettings))]
public class ElysiumDBSettingsEditor : UnityEditor.Editor
{
    public CustomList listLogsFilter;
    public CustomList listOfPathDB;

    public override void OnInspectorGUI();
    // ... helper drawing methods
}
```

## Methods (key)

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
public override void OnInspectorGUI();
```

</td>
<td>Main inspector drawing method. Initializes `CustomList`, draws filters, paths, info, and extensions.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawElysiumDBInfo"></a>
<td><code>DrawElysiumDBInfo</code></td>
<td>

```csharp
void DrawElysiumDBInfo();
```

</td>
<td>"ElysiumDB Info" block: initialization status, internet, persistent/streaming paths, database connection management.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawExtensions"></a>
<td><code>DrawExtensions</code></td>
<td>

```csharp
void DrawExtensions();
```

</td>
<td>Draws the list of extensions via `DBExtensionDrawer.DrawExtensionsList`.</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase"></a>
## ModuDevCore.ElysiumDB.Extension.DBExtensionBase
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Core.DBExtensionBase)

### Opportunities
* Base class for all ElysiumDB extensions.
* Provides convenient wrapper methods over `ElysiumDatabase` (`GetExtension`, `AddExtension`, etc.).
* Supports `enabled`, `extensionGroup`, `extensionId` (for internal identification).
* Lifecycle via `Process(ExtensionEvent)` → `OnInitialize` / `OnDispose`.
* Logging with `[ExtensionName]` prefix.

### Declaration

```csharp
[Serializable]
public class DBExtensionBase
{
    [HideInInspector] public bool enabled = true;
    [HideInInspector] public string extensionGroup = "";
    [HideInInspector] public int extensionId = -1;
    public string extensionName => this.GetType().Name;

    public void Process(ExtensionEvent ev, ElysiumDatabase elysium = null);
    protected virtual void OnInitialize(ElysiumDatabase elysium) {}
    protected virtual void OnDispose() {}
    // ... helper methods
}
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
[HideInInspector] public bool enabled = true;
```

</td>
<td>Whether the extension is enabled. If `false`, `Initialize` is skipped.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionGroup"></a>
<td><code>extensionGroup</code></td>
<td>

```csharp
[HideInInspector] public string extensionGroup = "";
```

</td>
<td>Group path (e.g. `"Auth/Google"`). Used by `DBExtensionDrawer` for hierarchy.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionId"></a>
<td><code>extensionId</code></td>
<td>

```csharp
[HideInInspector] public int extensionId = -1;
```

</td>
<td>Unique ID within the project (generated in `DBPostprocessor.SafetyFixExtensions`).</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionName"></a>
<td><code>extensionName</code></td>
<td>

```csharp
public string extensionName => this.GetType().Name;
```

</td>
<td>Type name (for logs and UI).</td>
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
public void Process(ExtensionEvent ev, ElysiumDatabase elysium = null);
```

</td>
<td>Internal dispatcher. Calls `OnInitialize` / `OnDispose`.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnInitialize"></a>
<td><code>OnInitialize</code></td>
<td>

```csharp
protected virtual void OnInitialize(ElysiumDatabase elysium) {}
```

</td>
<td>Override in derived classes for initialization logic.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Log"></a>
<td><code>Log</code></td>
<td>

```csharp
public void Log(object message);
```

</td>
<td>`Debug.Log($"[{extensionName}] " + message)`</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer"></a>
## ModuDevCore.ElysiumDB.Editor.ExtensionDrawer
[REFERENCE.md](./REFERENCE.md#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer)

### Opportunities
* Abstract base `PropertyDrawer` for all extension drawers.
* Provides `DrawDefaultExtension` and `GetChildrenHeight` for recursive drawing of `[SerializeReference]` fields.
* Direct access to `ElysiumDatabase` and its extension management methods from within the drawer.
* Unifies work with `target` (boxedValue).

### Declaration

```csharp
public abstract class ExtensionDrawer : PropertyDrawer
{
    protected ElysiumDBSettings Settings => ElysiumDatabase.Settings;
    public object target = null;

    public sealed override void OnGUI(Rect position, SerializedProperty property, GUIContent label);
    protected virtual void OnExtensionGUI(Rect position, SerializedProperty property, GUIContent label);
    // ... helpers
}
```

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.OnGUI"></a>
<td><code>OnGUI</code></td>
<td>

```csharp
public sealed override void OnGUI(Rect position, SerializedProperty property, GUIContent label);
```

</td>
<td>Sets `target = property.boxedValue` and calls `OnExtensionGUI`.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.DrawDefaultExtension"></a>
<td><code>DrawDefaultExtension</code></td>
<td>

```csharp
public void DrawDefaultExtension(Rect position, SerializedProperty property);
```

</td>
<td>Draws all visible child properties (for `[SerializeReference]` objects).</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetChildrenHeight"></a>
<td><code>GetChildrenHeight</code></td>
<td>

```csharp
public float GetChildrenHeight(SerializedProperty property);
```

</td>
<td>Calculates the height of all children for `GetPropertyHeight`.</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.CustomList"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.CustomList

### Opportunities
* Enhanced string list editor with inline `IMGUITextFieldPro`.
* Supports up/down arrow navigation, auto-focus, and auto-adding a new row on input.
* "X" button for deletion and placeholder text support.
* Automatic cleanup of unused `IMGUITextFieldPro` instances (optimization).

### Declaration

```csharp
public class CustomList
{
    private SerializedProperty _list;
    private string _label;
    private string _placeholder;
    private Dictionary<string, IMGUITextFieldPro> tfps = new();

    public CustomList(SerializedProperty list, string label, SerializedObject serializedObject, string placeholder = "");
    public void Draw();
}
```

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.CustomList.Draw"></a>
<td><code>Draw</code></td>
<td>

```csharp
public void Draw();
```

</td>
<td>Draws the entire list + input field for a new entry. Handles navigation keys.</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionBaseDrawer"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionBaseDrawer

### Opportunities
* Base `CustomPropertyDrawer` for `DBExtensionBase` (and all derived types).
* Simply calls `DrawDefaultExtension` — allows displaying all `[SerializeReference]` fields.

### Declaration

```csharp
[CustomPropertyDrawer(typeof(DBExtensionBase), true)]
public class DBExtensionBaseDrawer : ExtensionDrawer
{
    protected override void OnExtensionGUI(Rect position, SerializedProperty property, GUIContent label);
}
```

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer (static)

### Opportunities
* **The most complex and important editor component.** A fully custom hierarchical extension management system.
* Supports **groups** with arbitrary nesting (`extensionGroup = "Auth/Google/Firebase"`).
* Drag & drop between groups, context menus (Move to Group, Create Group, Move Up/Down, Delete with dependency checks).
* Custom `IMGUITextFieldPro` for editing group names directly in the header.
* Smart validation and path migration when renaming groups.
* Script icons, collapse/expand state, enabled toggle.
* Automatic generation of unique `extensionId` in the postprocessor.

### Declaration

```csharp
public static class DBExtensionDrawer
{
    private static readonly Dictionary<string, bool> _expandedStates = new(StringComparer.Ordinal);
    private static readonly Dictionary<Type, Texture2D> _iconCache = new();
    public static List<IInspectorElement> inspectorElements = new List<IInspectorElement>();

    public static void DrawExtensionsList(SerializedProperty property, Type baseType);
    public static void ValidateGroups(SerializedProperty property);
    // ... many private drawing and group handling methods
}
```

### Nested Types / Inner Classes

<table>
<tr>
<th>Class / Interface</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.IInspectorElement"></a>
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
<td>Marker interface for inspector elements (group or extension).</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.PropertyGroup"></a>
<td><code>PropertyGroup</code></td>
<td>

```csharp
public class PropertyGroup : IInspectorElement
{
    public string GroupName { get; set; }
    public List<IInspectorElement> Elements = new List<IInspectorElement>();
    public void DeleteGroup();
    public void MigrateToNewGroupName(string newName);
}
```

</td>
<td>Represents a group in the hierarchy. Can recursively delete itself and update paths for all children.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.PropertyExtension"></a>
<td><code>PropertyExtension</code></td>
<td>

```csharp
public class PropertyExtension : IInspectorElement
{
    public SerializedProperty SerializedProperty { get; set; }
}
```

</td>
<td>Wrapper around a single extension in the list.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.Auxilary.DBExtensionDrawer.GroupPathDropdown"></a>
<td><code>GroupPathDropdown</code></td>
<td>

```csharp
public class GroupPathDropdown : AdvancedDropdown { ... }
```

</td>
<td>`AdvancedDropdown` for group selection (kept for future use; not actively used in current version).</td>
</tr>
</table>

## Key Static Methods

- `DrawExtensionsList` — main entry point.
- `ValidateGroups` — builds the hierarchy of `PropertyGroup` + `PropertyExtension` from `extensionGroup` paths.
- `DrawHeader` — draws a nice header with foldout, enabled toggle, menu button (⋮), and icon.
- `ShowContextMenuExtension` / `ShowContextMenuGroup` — powerful context menus with `RequireExtensionAttribute` checks.
- `GetClassIcon` — caches MonoScript icons.
- `GenerateNewGroupName` — generates "New Group 2", "New Group 3", etc.

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor

### Opportunities
* `AssetPostprocessor` that automatically watches for changes in the `ElysiumDB` folder.
* Guarantees the existence of `Assets/ElysiumDB/Resources/ElysiumDB Settings.asset`.
* Moves settings to the canonical path when necessary.
* `SafetyFixExtensions` removes `null` extensions, calls `ProcessRequiredExtensions`, and generates unique `extensionId` values (prevents duplicates).

### Declaration

```csharp
public class DBPostprocessor : AssetPostprocessor
{
    private const string AssetPath = "Assets/ElysiumDB/Resources/ElysiumDB Settings.asset";

    static void OnPostprocessAllAssets(...);
    public static void SafetyFixExtensions();
}
```

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
public static void SafetyFixExtensions();
```

</td>
<td>Cleans up nulls, runs required extensions, and assigns unique `extensionId` values.</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Extension.AuthElysiumDB"></a>
## ModuDevCore.ElysiumDB.Extension.AuthElysiumDB

### Opportunities
* Example implementation of `DBExtensionBase` — JWT / credentials-based authentication system.
* Stores credentials in `PlayerPrefs` (simple session cache).
* Notifies all `IAuthElysiumReceiver` implementations when the token changes.
* Integrates with `AuthElysiumDBDrawer` for nice display in the inspector.

### Declaration

```csharp
public class AuthElysiumDB : DBExtensionBase
{
    public string cacheFileName = "elysium_session.cache";
    public bool IsAuthenticated { get; private set; }

    protected override void OnInitialize(ElysiumDatabase elysium);
    public void Auth(string credentials);
    public void SignOut();
    public string GetCredentials();
}
```

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.AuthElysiumDB.Auth"></a>
<td><code>Auth</code></td>
<td>

```csharp
public void Auth(string credentials);
```

</td>
<td>Saves credentials to PlayerPrefs and notifies receivers.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.AuthElysiumDB.GetCredentials"></a>
<td><code>GetCredentials</code></td>
<td>

```csharp
public string GetCredentials();
```

</td>
<td>Returns current credentials from PlayerPrefs.</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Extension.AuthElysiumDBDrawer"></a>
## ModuDevCore.ElysiumDB.Extension.AuthElysiumDBDrawer

### Opportunities
* Custom `PropertyDrawer` for `AuthElysiumDB`.
* Shows `IsAuthenticated` status, foldout with credentials, Refresh / Clear Session buttons.
* Demonstrates the pattern for creating specialized drawers for extensions.

### Declaration

```csharp
[CustomPropertyDrawer(typeof(AuthElysiumDB))]
public class AuthElysiumDBDrawer : PropertyDrawer
{
    bool showCredentials = false;
    public float height = 0;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label);
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label);
}
```

---

<a id="ModuDevCore.ElysiumDB.Extension.IAuthElysiumReceiver"></a>
## ModuDevCore.ElysiumDB.Extension.IAuthElysiumReceiver

### Opportunities
* Observer interface for reacting to auth token changes.
* Allows other extensions to subscribe to authentication events without tight coupling.

### Declaration

```csharp
public interface IAuthElysiumReceiver
{
    void OnAuthTokenUpdated(string newJwt);
    void OnAuthLoggedOut();
}
```

---

<a id="ModuDevCore.ElysiumDB.Internal.Data.ExtensionEvent"></a>
## ModuDevCore.ElysiumDB.Internal.Data.ExtensionEvent

### Opportunities
* Simple enumeration of the extension lifecycle.
* Used in `DBExtensionBase.Process` and `ElysiumDatabase.RunExtensionsProcess`.

### Declaration

```csharp
public enum ExtensionEvent
{
    Initialize = 0,
    Dispose = 1
}
```

## Enum Values

<table>
<tr>
<th>Value</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Internal.Data.ExtensionEvent.Initialize"></a>
<td><code>Initialize</code></td>
<td>Called during `ElysiumDatabase.New()` and when an extension is added.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Internal.Data.ExtensionEvent.Dispose"></a>
<td><code>Dispose</code></td>
<td>Called during `ElysiumDatabase.Dispose()` and when an extension is removed.</td>
</tr>
</table>

---

## Additional Notes for Developers

1. **Extension Groups** — a powerful feature. The `extensionGroup` path supports arbitrary nesting (e.g. `Core/Auth/Google`).
2. **extensionId** — generated automatically in `DBPostprocessor`. Never set it manually.
3. **SerializeReference** — all extensions are stored via `[SerializeReference]`. This enables polymorphism in the inspector.
4. **IMGUITextFieldPro** — custom text editor with full keyboard support, selection, caret, and placeholder (used in `CustomList` and group headers).
5. **Deletion Safety** — `ShowContextMenuExtension` checks `GetRequiresExtensions` and blocks deletion if dependent extensions exist.
6. **Logging** — use `ElysiumDatabase.Log(...)` instead of `Debug.Log` inside extensions.

---