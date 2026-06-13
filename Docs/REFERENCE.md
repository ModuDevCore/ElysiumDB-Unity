# API Reference

Here are described all **public** classes, interfaces, enumerations, and other types available for use by developers.

---

## Guide

<details>
<summary>DefaultExtensionGroupAttribute</summary>

## Parent
[ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute](#ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute)

### Fields
- [ExtensionGroup](#ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute.ExtensionGroup)

### Methods
- [DefaultExtensionGroupAttribute](#ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute.DefaultExtensionGroupAttribute)

</details>

<details>
<summary>ExtensionProcessOrderAttribute</summary>

## Parent
[ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute](#ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute)

### Properties
- [Group](#ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute.Group)
- [Order](#ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute.Order)

### Methods
- [ExtensionProcessOrderAttribute](#ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute.ExtensionProcessOrderAttribute)

</details>

<details>
<summary>RequireExtensionAttribute</summary>

## Parent
[ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute](#ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute)

### Fields
- [ExtensionType](#ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute.ExtensionType)
- [AutoCreate](#ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute.AutoCreate)

### Methods
- [RequireExtensionAttribute](#ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute.RequireExtensionAttribute)

</details>

<details>
<summary>DBMeta</summary>

## Parent
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

</details>

<details>
<summary>ElysiumDatabase</summary>

## Parent
[ModuDevCore.ElysiumDB.Core.ElysiumDatabase](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase)

### Fields / Indexer
- [Instance](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Instance)
- [Connections](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Connections)
- [Settings](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Settings)
- [this[string]](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Item)

### Methods
- [New](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.New)
- [Dispose](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Dispose)
- [ConnectDB](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.ConnectDB)
- [GetExtension](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.GetExtension)
- [HasExtension](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.HasExtension)
- [TryGetExtension](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.TryGetExtension)
- [AddExtension](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.AddExtension)
- [RemoveExtension](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.RemoveExtension)
- [GetRequiresExtensions](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.GetRequiresExtensions)
- [ProcessRequiredExtensions](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.ProcessRequiredExtensions)
- [Log / LogWarning / LogError](#ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Log)

</details>

<details>
<summary>DBExtensionBase</summary>

## Parent
[ModuDevCore.ElysiumDB.Extension.DBExtensionBase](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase)

### Fields
- [enabled](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.enabled)
- [extensionGroup](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionGroup)
- [extensionId](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionId)
- [extensionName](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionName)

### Methods
- [Process](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Process)
- [OnInitialize](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnInitialize)
- [OnDispose](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnDispose)
- [GetExtension / GetExtensions](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtension)
- [HasExtension](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.HasExtension)
- [AddExtension / RemoveExtension](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.AddExtension)
- [Log](#ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Log)

</details>

<details>
<summary>ExtensionDrawer</summary>

## Parent
[ModuDevCore.ElysiumDB.Editor.ExtensionDrawer](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer)

### Methods
- [OnGUI](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.OnGUI)
- [OnExtensionGUI](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.OnExtensionGUI)
- [GetPropertyHeight](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetPropertyHeight)
- [DrawDefaultExtension](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.DrawDefaultExtension)
- [GetChildrenHeight](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetChildrenHeight)

</details>

---

## Classes

<a id="ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute"></a>
## ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute

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
<thead>
<tr>
<td>
<h4>About Field</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute.ExtensionGroup"></a>
<tr>
<td width="70%">

<h5>ExtensionGroup</h5>

```csharp
public string ExtensionGroup;
```

Name of the default group (e.g. `"Auth"`, `"Core"`, `"UI"`). Used when creating the extension via `AddExtension`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

## Methods

<table>
<thead>
<tr>
<td>
<h4>About Method</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Attributes.DefaultExtensionGroupAttribute.DefaultExtensionGroupAttribute"></a>
<tr>
<td width="70%">

<h5>DefaultExtensionGroupAttribute</h5>

```csharp
public DefaultExtensionGroupAttribute(
    string extensionGroup
);
```

Constructor. Sets the `ExtensionGroup` value.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

---

<a id="ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute"></a>
## ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute

### Opportunities
* Allows controlling the initialization/disposal order of extensions within the same group.
* Used in `ElysiumDatabase.RunExtensionsProcess` for sorting via `OrderBy`.
* Ensures stable ordering (then by index in the list).
* Useful for dependent extensions (e.g. Auth should initialize before others that depend on it).

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

Controls the execution order of extensions inside a specific group during `Initialize` / `Dispose`.

## Properties

<table>
<thead>
<tr>
<td>
<h4>About Property</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute.Group"></a>
<tr>
<td width="70%">

<h5>Group</h5>

```csharp
public string Group { get; }
```

Name of the group to which the ordering applies. Defaults to `"Default"`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute.Order"></a>
<tr>
<td width="70%">

<h5>Order</h5>

```csharp
public int Order { get; }
```

Order within the group (lower value = earlier initialization). Defaults to `0`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

## Methods

<table>
<thead>
<tr>
<td>
<h4>About Method</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Attributes.ExtensionProcessOrderAttribute.ExtensionProcessOrderAttribute"></a>
<tr>
<td width="70%">

<h5>ExtensionProcessOrderAttribute</h5>

```csharp
public ExtensionProcessOrderAttribute(
    string group,
    int order = 0
);
```

Constructor. If `group` is `null`, it is replaced with `"Default"`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

---

<a id="ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute"></a>
## ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute

### Opportunities
* Declaratively describes dependencies between extensions.
* Automatically creates required extensions (`AutoCreate = true`) in `ProcessRequiredExtensions`.
* Blocks deletion of an extension if other extensions depend on it (checked in `ShowContextMenuExtension`).
* Supports `AllowMultiple = true` so one extension can require several others.

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

Declares that the attributed extension requires another extension to function.

## Fields

<table>
<thead>
<tr>
<td>
<h4>About Field</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute.ExtensionType"></a>
<tr>
<td width="70%">

<h5>ExtensionType</h5>

```csharp
public Type ExtensionType;
```

Type of the required extension (must inherit from `DBExtensionBase`).
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute.AutoCreate"></a>
<tr>
<td width="70%">

<h5>AutoCreate</h5>

```csharp
public bool AutoCreate;
```

If `true`, the required extension is automatically created if it is missing. Defaults to `true`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

## Methods

<table>
<thead>
<tr>
<td>
<h4>About Method</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute.RequireExtensionAttribute"></a>
<tr>
<td width="70%">

<h5>RequireExtensionAttribute</h5>

```csharp
public RequireExtensionAttribute(
    Type extensionType,
    bool autoCreate = true
);
```

Dependency constructor.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

---

<a id="ModuDevCore.ElysiumDB.Core.DBMeta"></a>
## ModuDevCore.ElysiumDB.Core.DBMeta

### Opportunities
* Wrapper around `IDbConnection` (SQLite) with convenient query and mapping methods.
* Automatic query logging with `[Caller*]` attributes + filtering via `logIgnorePatterns` in settings.
* Universal `MapReaderToObject<T>` with support for `PascalCase` / `camelCase` and nullable types.
* Supports `QueryFirst`, `QueryList`, `QueryValue`, `QueryDictionary`, `QueryColumn`.
* Implements `IDisposable` for safe connection cleanup.
* Accessed via `ElysiumDatabase["path/to/db"]` or `ElysiumDatabase.Connections`.

### Declaration

```csharp
public class DBMeta : IDisposable
{
    public IDbConnection connection;

    // public methods...
}
```

## Fields

<table>
<thead>
<tr>
<td>
<h4>About Field</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.connection"></a>
<tr>
<td width="70%">

<h5>connection</h5>

```csharp
public IDbConnection connection;
```

Active database connection (usually `SqliteConnectionNative` from the underlying provider).
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

## Methods

<table>
<thead>
<tr>
<td>
<h4>About Method</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.Dispose"></a>
<tr>
<td width="70%">

<h5>Dispose</h5>

```csharp
public void Dispose();
```

Closes and disposes the underlying database connection.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.Query"></a>
<tr>
<td width="70%">

<h5>Query</h5>

```csharp
public IDataReader Query(
    string cmd,
    int linesToRead = 0,
    [CallerMemberName] string callerMethod = "",
    [CallerFilePath] string callerFile = "",
    [CallerLineNumber] int callerLine = 0
);
```

Executes SQL command and returns `IDataReader`. Automatically logs the query (unless filtered by `logIgnorePatterns`).
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.QueryFirst"></a>
<tr>
<td width="70%">

<h5>QueryFirst&lt;T&gt;</h5>

```csharp
public T QueryFirst<T>(
    string cmd,
    int linesToRead = 0,
    ...
) where T : new();
```

Returns the first row mapped to a new instance of `T`. Uses `MapReaderToObject`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.QueryList"></a>
<tr>
<td width="70%">

<h5>QueryList&lt;T&gt;</h5>

```csharp
public List<T> QueryList<T>(
    string cmd,
    ...
) where T : new();
```

Returns all rows mapped as `List<T>`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.QueryColumn"></a>
<tr>
<td width="70%">

<h5>QueryColumn&lt;T&gt;</h5>

```csharp
public List<T> QueryColumn<T>(
    string cmd
);
```

Returns all values from the first column as `List<T>`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.QueryValue"></a>
<tr>
<td width="70%">

<h5>QueryValue&lt;T&gt;</h5>

```csharp
public T QueryValue<T>(
    string cmd,
    ...
);
```

Returns a single scalar value (e.g. `COUNT(*)`, `MAX(id)`).
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.QueryDictionary"></a>
<tr>
<td width="70%">

<h5>QueryDictionary&lt;TKey, TValue&gt;</h5>

```csharp
public Dictionary<TKey, TValue> QueryDictionary<TKey, TValue>(
    string cmd,
    ...
);
```

Returns a dictionary built from the first two columns of the result set.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.Execute"></a>
<tr>
<td width="70%">

<h5>Execute</h5>

```csharp
public void Execute(
    string cmd
);
```

Executes a non-query command (`INSERT`, `UPDATE`, `DELETE`, `CREATE TABLE`, etc.).
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.DBMeta.Exists"></a>
<tr>
<td width="70%">

<h5>Exists</h5>

```csharp
public bool Exists(
    string cmd
);
```

Returns `true` if the query returns at least one row.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

---

<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase"></a>
## ModuDevCore.ElysiumDB.Core.ElysiumDatabase

### Opportunities
* Central singleton for managing multiple SQLite databases and the extension system.
* Powerful extension model with grouping, initialization ordering, declarative dependencies (`RequireExtensionAttribute`), and auto-creation.
* Convenient static helpers: `GetExtension<T>`, `AddExtension<T>`, `RemoveExtension<T>`, `HasExtension<T>`.
* Automatic processing of required extensions on startup via `ProcessRequiredExtensions`.
* Cross-platform support (Android StreamingAssets copying, persistent data path).
* Custom logging with filters and queue.
* Global configuration via `ElysiumDBSettings` ScriptableObject.

### Declaration

```csharp
public class ElysiumDatabase : IDisposable
{
    public static ElysiumDatabase Instance;
    public Dictionary<string, DBMeta> Connections = new();
    public static ElysiumDBSettings Settings { get; }

    public DBMeta this[string database] { get; }

    public static void New();
    public void Dispose();
    // ... other public members
}
```

## Fields / Indexer

<table>
<thead>
<tr>
<td>
<h4>About Field / Indexer</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Instance"></a>
<tr>
<td width="70%">

<h5>Instance</h5>

```csharp
public static ElysiumDatabase Instance;
```

Global singleton instance. Set automatically in `New()`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Connections"></a>
<tr>
<td width="70%">

<h5>Connections</h5>

```csharp
public Dictionary<string, DBMeta> Connections = new Dictionary<string, DBMeta>();
```

All active database connections keyed by their relative path.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Settings"></a>
<tr>
<td width="70%">

<h5>Settings</h5>

```csharp
public static ElysiumDBSettings Settings => Resources.Load<ElysiumDBSettings>("ElysiumDB Settings");
```

Global settings ScriptableObject (contains `dbPaths`, `extensions`, `logIgnorePatterns`, `showLogs`).
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Item"></a>
<tr>
<td width="70%">

<h5>this[string database]</h5>

```csharp
public DBMeta this[string database] { get => Connections[database]; }
```

Quick access to `DBMeta` for a specific database path.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

## Methods

<table>
<thead>
<tr>
<td>
<h4>About Method</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.New"></a>
<tr>
<td width="70%">

<h5>New</h5>

```csharp
public static void New();
```

Initializes the singleton, clears old connections, processes required extensions, connects all databases from settings, and initializes all enabled extensions.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Dispose"></a>
<tr>
<td width="70%">

<h5>Dispose</h5>

```csharp
public void Dispose();
```

Closes all connections, disposes all extensions, and clears the singleton instance.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.ConnectDB"></a>
<tr>
<td width="70%">

<h5>ConnectDB</h5>

```csharp
public void ConnectDB(
    string path
);
```

Copies database from StreamingAssets (Android) if needed and opens a connection. Adds it to `Connections`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.GetExtension"></a>
<tr>
<td width="70%">

<h5>GetExtension&lt;T&gt; / GetExtension</h5>

```csharp
public static T GetExtension<T>() where T : class;

public static object GetExtension(
    Type type
);
```

Returns the first registered extension of the specified type (or `null` if not found).
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.HasExtension"></a>
<tr>
<td width="70%">

<h5>HasExtension&lt;T&gt;</h5>

```csharp
public static bool HasExtension<T>() where T : class;
```

Returns `true` if an extension of type `T` is currently registered.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.TryGetExtension"></a>
<tr>
<td width="70%">

<h5>TryGetExtension&lt;T&gt;</h5>

```csharp
public static bool TryGetExtension<T>(
    out T extension
) where T : class;
```

Tries to get the extension and returns success status.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.AddExtension"></a>
<tr>
<td width="70%">

<h5>AddExtension</h5>

```csharp
public static object AddExtension(
    Type type
);

public static T AddExtension<T>()
    where T : DBExtensionBase, new();
```

Creates a new extension instance, applies `DefaultExtensionGroupAttribute` if present, calls `Initialize`, and registers it in `Settings.extensions`. Saves the asset.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.RemoveExtension"></a>
<tr>
<td width="70%">

<h5>RemoveExtension</h5>

```csharp
public static bool RemoveExtension(
    Type type
);

public static bool RemoveExtension<T>()
    where T : DBExtensionBase;
```

Calls `Dispose` on the extension, removes it from the list, and saves `Settings`. Returns `true` if removed.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.GetRequiresExtensions"></a>
<tr>
<td width="70%">

<h5>GetRequiresExtensions</h5>

```csharp
public static List<Type> GetRequiresExtensions(
    Type type
);
```

Returns list of extension types that depend on the given type (via `RequireExtensionAttribute`). Used to prevent unsafe deletion.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.ProcessRequiredExtensions"></a>
<tr>
<td width="70%">

<h5>ProcessRequiredExtensions</h5>

```csharp
public static void ProcessRequiredExtensions();
```

Scans all registered extensions for `RequireExtensionAttribute` and auto-creates missing dependencies (when `AutoCreate = true`).
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.ElysiumDatabase.Log"></a>
<tr>
<td width="70%">

<h5>Log / LogWarning / LogError</h5>

```csharp
public static void Log(
    object message
);

public static void LogWarning(
    object message
);

public static void LogError(
    object message
);
```

Centralized logging that respects `Settings.showLogs` and `logIgnorePatterns`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

---

<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase"></a>
## ModuDevCore.ElysiumDB.Extension.DBExtensionBase

### Opportunities
* Base class for all custom ElysiumDB extensions.
* Provides convenient wrapper methods (`GetExtension<T>`, `AddExtension<T>`, `HasExtension<T>`, `Log`) that delegate to `ElysiumDatabase`.
* Supports `enabled` flag, `extensionGroup` (for hierarchical organization), and auto-generated `extensionId`.
* Lifecycle: override `OnInitialize` / `OnDispose`. The `Process(ExtensionEvent)` method is called by the core.
* All extensions are stored with `[SerializeReference]` allowing polymorphism in the inspector.

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

    // helper methods...
}
```

## Fields

<table>
<thead>
<tr>
<td>
<h4>About Field</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.enabled"></a>
<tr>
<td width="70%">

<h5>enabled</h5>

```csharp
[HideInInspector] public bool enabled = true;
```

If `false`, `OnInitialize` will be skipped during startup / addition.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionGroup"></a>
<tr>
<td width="70%">

<h5>extensionGroup</h5>

```csharp
[HideInInspector] public string extensionGroup = "";
```

Group path supporting nesting, e.g. `"Auth/Google/Firebase"`. Used by `DBExtensionDrawer` for tree view.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionId"></a>
<tr>
<td width="70%">

<h5>extensionId</h5>

```csharp
[HideInInspector] public int extensionId = -1;
```

Unique identifier generated automatically by `DBPostprocessor`. Do not set manually.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionName"></a>
<tr>
<td width="70%">

<h5>extensionName</h5>

```csharp
public string extensionName => this.GetType().Name;
```

Returns the simple type name (used in logs and UI headers).
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

## Methods

<table>
<thead>
<tr>
<td>
<h4>About Method</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Process"></a>
<tr>
<td width="70%">

<h5>Process</h5>

```csharp
public void Process(
    ExtensionEvent ev,
    ElysiumDatabase elysium = null
);
```

Internal dispatcher. Calls `OnInitialize` or `OnDispose` depending on `ev`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnInitialize"></a>
<tr>
<td width="70%">

<h5>OnInitialize</h5>

```csharp
protected virtual void OnInitialize(
    ElysiumDatabase elysium
) {}
```

Override this method to perform initialization logic (open connections, subscribe to events, etc.).
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnDispose"></a>
<tr>
<td width="70%">

<h5>OnDispose</h5>

```csharp
protected virtual void OnDispose() {}
```

Override to clean up resources when the extension is removed or the database system is disposed.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtension"></a>
<tr>
<td width="70%">

<h5>GetExtension&lt;T&gt; / GetExtensions&lt;T&gt; / HasExtension&lt;T&gt;</h5>

```csharp
public T GetExtension<T>() where T : class;

public List<T> GetExtensions<T>() where T : class;

public bool HasExtension<T>() where T : class;
```

Convenience wrappers around `ElysiumDatabase` static methods.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.AddExtension"></a>
<tr>
<td width="70%">

<h5>AddExtension&lt;T&gt; / RemoveExtension&lt;T&gt;</h5>

```csharp
public T AddExtension<T>()
    where T : DBExtensionBase, new();

public bool RemoveExtension<T>()
    where T : DBExtensionBase;
```

Convenience wrappers to add/remove other extensions from within an extension.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Log"></a>
<tr>
<td width="70%">

<h5>Log</h5>

```csharp
public void Log(
    object message
);
```

Logs with `[ExtensionName]` prefix using `ElysiumDatabase.Log`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

---

<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer"></a>
## ModuDevCore.ElysiumDB.Editor.ExtensionDrawer

### Opportunities
* Abstract base `PropertyDrawer` for creating custom inspectors for extensions that derive from `DBExtensionBase`.
* Provides `DrawDefaultExtension` helper for recursive drawing of all `[SerializeReference]` child fields.
* `GetChildrenHeight` calculates proper inspector height for complex nested objects.
* Access to `ElysiumDatabase` and settings directly from the drawer.
* Inherit from this class and override `OnExtensionGUI` to create rich custom UIs for your own extensions (similar to `AuthElysiumDBDrawer`).

### Declaration

```csharp
public abstract class ExtensionDrawer : PropertyDrawer
{
    protected ElysiumDBSettings Settings => ElysiumDatabase.Settings;
    public object target = null;

    public sealed override void OnGUI(Rect position, SerializedProperty property, GUIContent label);
    protected virtual void OnExtensionGUI(Rect position, SerializedProperty property, GUIContent label);
    // helper methods...
}
```

## Methods

<table>
<thead>
<tr>
<td>
<h4>About Method</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.OnGUI"></a>
<tr>
<td width="70%">

<h5>OnGUI</h5>

```csharp
public sealed override void OnGUI(
    Rect position,
    SerializedProperty property,
    GUIContent label
);
```

Sealed entry point. Sets `target = property.boxedValue` and forwards to `OnExtensionGUI`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.OnExtensionGUI"></a>
<tr>
<td width="70%">

<h5>OnExtensionGUI</h5>

```csharp
protected virtual void OnExtensionGUI(
    Rect position,
    SerializedProperty property,
    GUIContent label
);
```

Override this method to implement your custom inspector GUI for the extension.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetPropertyHeight"></a>
<tr>
<td width="70%">

<h5>GetPropertyHeight</h5>

```csharp
public override float GetPropertyHeight(
    SerializedProperty property,
    GUIContent label
);
```

Calculates total height including children via `GetChildrenHeight`.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.DrawDefaultExtension"></a>
<tr>
<td width="70%">

<h5>DrawDefaultExtension</h5>

```csharp
public void DrawDefaultExtension(
    Rect position,
    SerializedProperty property
);
```

Draws all visible serialized child fields (useful for `[SerializeReference]` objects).
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetChildrenHeight"></a>
<tr>
<td width="70%">

<h5>GetChildrenHeight</h5>

```csharp
public float GetChildrenHeight(
    SerializedProperty property
);
```

Recursively calculates the height required to draw all child properties.
</td>
<td width="30%">
<img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="100%" alt="Example" />
</td>
</tr>
</tbody>
</table>

---