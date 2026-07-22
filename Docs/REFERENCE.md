# API Reference

Here are described all **public** classes, interfaces, enumerations, and other types available for use by developers.

---

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
- [New](#ModuDevCore.ElysiumDB.ElysiumDatabase.New)
- [DetachDB](#ModuDevCore.ElysiumDB.ElysiumDatabase.DetachDB)
- [ConnectDB](#ModuDevCore.ElysiumDB.ElysiumDatabase.ConnectDB)
- [CreateSQLiteDatabase](#ModuDevCore.ElysiumDB.ElysiumDatabase.CreateSQLiteDatabase)
- [Dispose](#ModuDevCore.ElysiumDB.ElysiumDatabase.Dispose)

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
- [DrawDefaultExtension](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.DrawDefaultExtension)
- [GetChildrenHeight](#ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetChildrenHeight)

</details>

<details>
<summary>AuthElysiumDB / ElysiumAuthCredentials / IAuthElysiumReceiver</summary>

## Parent
[AuthElysiumDB](#AuthElysiumDB)

### Nested Classes
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

</details>

## Classes

<a id="ModuDevCore.ElysiumDB.AfterExtensionAttribute"></a>
## ModuDevCore.ElysiumDB.AfterExtensionAttribute

### Opportunities

* Marks an extension as dependent on the processing order of another extension type.
* Supports multiple usages on the same class, so several predecessors can be declared.
* Inherited by derived extension classes.

### Declaration

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public sealed class AfterExtensionAttribute : Attribute
```

Apply this attribute to a class derived from `DBExtensionBase` to defer its processing until the specified extension type has finished processing the current event.

## Fields
None

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
<a id="ModuDevCore.ElysiumDB.AfterExtensionAttribute.ExtensionType"></a>
<tr>
<td width="70%">

<h5>ExtensionType</h5>

```csharp
public Type ExtensionType { get; }
```
The extension type after which the marked extension will be processed.
</td>
<td width="30%">

```csharp
var predecessor = typeof(AuthElysiumDB)
    .GetCustomAttribute<AfterExtensionAttribute>()
    ?.ExtensionType;
```
</td>
</tr>
<tbody>
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
<a id="ModuDevCore.ElysiumDB.AfterExtensionAttribute.ctor"></a>
<tr>
<td width="70%">

<h5>AfterExtensionAttribute (constructor)</h5>

```csharp
public AfterExtensionAttribute(Type extensionType)
```
Creates the attribute, specifying the extension type that must be processed first.
</td>
<td width="30%">

```csharp
[AfterExtension(typeof(AuthElysiumDB))]
public class MyExtension : DBExtensionBase
{
    // Processed only after AuthElysiumDB
    // has finished the current event.
}
```
</td>
</tr>
<tbody>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute"></a>
## ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute

### Opportunities

* Sets the default inspector group (folder path) an extension is placed into when it is created.
* Applies automatically to extensions created manually or auto-created via `RequireExtensionAttribute`.

### Declaration

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public sealed class DefaultExtensionGroupAttribute : Attribute
```

Apply this attribute to a `DBExtensionBase` derivative to control where it initially appears in the extensions list inspector.

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
<a id="ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute.ExtensionGroup"></a>
<tr>
<td width="70%">

<h5>ExtensionGroup</h5>

```csharp
public string ExtensionGroup;
```
The group path (e.g. `"Auth/Sub"`) assigned to the extension's `extensionGroup` field on creation.
</td>
<td width="30%">

```csharp
var group = typeof(AuthElysiumDB)
    .GetCustomAttribute<DefaultExtensionGroupAttribute>()
    ?.ExtensionGroup;
```
</td>
</tr>
<tbody>
</table>

## Properties
None

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
<a id="ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute.ctor"></a>
<tr>
<td width="70%">

<h5>DefaultExtensionGroupAttribute (constructor)</h5>

```csharp
public DefaultExtensionGroupAttribute(string extensionGroup)
```
Creates the attribute with the given default group.
</td>
<td width="30%">

```csharp
[DefaultExtensionGroup("Auth")]
public class AuthElysiumDB : DBExtensionBase
{
    // Placed under the "Auth" group
    // in the inspector by default.
}
```
</td>
</tr>
<tbody>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute"></a>
## ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute

### Opportunities

* Defines a sorting group and a numeric priority used to control the order in which extensions are processed.
* Can be inherited or extended for custom ordering rules.

### Declaration

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class ExtensionProcessOrderAttribute : Attribute
```

Apply this attribute to a `DBExtensionBase` derivative to control its relative processing order during initialization and disposal.

## Fields
None

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
<a id="ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute.Group"></a>
<tr>
<td width="70%">

<h5>Group</h5>

```csharp
public string Group { get; }
```
The sorting group name. Defaults to `"Default"` when not specified.
</td>
<td width="30%">

```csharp
var group = typeof(AuthElysiumDB)
    .GetCustomAttribute<ExtensionProcessOrderAttribute>()
    ?.Group;
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute.Order"></a>
<tr>
<td width="70%">

<h5>Order</h5>

```csharp
public int Order { get; }
```
The numeric priority within the group (ascending order).
</td>
<td width="30%">

```csharp
var order = typeof(AuthElysiumDB)
    .GetCustomAttribute<ExtensionProcessOrderAttribute>()
    ?.Order;
```
</td>
</tr>
<tbody>
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
<a id="ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute.ctor"></a>
<tr>
<td width="70%">

<h5>ExtensionProcessOrderAttribute (constructor)</h5>

```csharp
public ExtensionProcessOrderAttribute(
    string group,
    int order = 0
)
```
Creates the attribute with the given group and sorting priority.
</td>
<td width="30%">

```csharp
[ExtensionProcessOrder("Core", 0)]
public class AuthElysiumDB : DBExtensionBase
{
    // Processed first within the "Core" group.
}
```
</td>
</tr>
<tbody>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.RequireExtensionAttribute"></a>
## ModuDevCore.ElysiumDB.RequireExtensionAttribute

### Opportunities

* Declares a dependency on another extension type.
* Optionally auto-creates the required extension if it is missing.
* Supports multiple usages to declare several dependencies.

### Declaration

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public sealed class RequireExtensionAttribute : Attribute
```

Apply this attribute to a `DBExtensionBase` derivative that depends on another extension being present.

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
<a id="ModuDevCore.ElysiumDB.RequireExtensionAttribute.ExtensionType"></a>
<tr>
<td width="70%">

<h5>ExtensionType</h5>

```csharp
public Type ExtensionType;
```
The type of the required extension.
</td>
<td width="30%">

```csharp
var required = typeof(MyExtension)
    .GetCustomAttributes<RequireExtensionAttribute>()
    .Select(a => a.ExtensionType);
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.RequireExtensionAttribute.AutoCreate"></a>
<tr>
<td width="70%">

<h5>AutoCreate</h5>

```csharp
public bool AutoCreate;
```
Whether the required extension should be automatically created if it is missing.
</td>
<td width="30%">

```csharp
[RequireExtension(typeof(AuthElysiumDB), autoCreate: false)]
public class MyExtension : DBExtensionBase
{
    // Throws if AuthElysiumDB is not
    // already registered when this is added.
}
```
</td>
</tr>
<tbody>
</table>

## Properties
None

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
<a id="ModuDevCore.ElysiumDB.RequireExtensionAttribute.ctor"></a>
<tr>
<td width="70%">

<h5>RequireExtensionAttribute (constructor)</h5>

```csharp
public RequireExtensionAttribute(
    Type extensionType,
    bool autoCreate = true
)
```
Creates the dependency attribute, specifying the type and whether it should be auto-created.
</td>
<td width="30%">

```csharp
[RequireExtension(typeof(AuthElysiumDB))]
public class MyExtension : DBExtensionBase
{
    // AuthElysiumDB is auto-created
    // if it isn't registered yet.
}
```
</td>
</tr>
<tbody>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Core.Data.ElysiumStage"></a>
## ModuDevCore.ElysiumDB.Core.Data.ElysiumStage

### Opportunities

* Represents the lifecycle stages of `ElysiumDatabase`, from initialization to disposal.
* Reported through the `ElysiumDatabase.OnStageChanged` event so subscribers can track startup and shutdown progress.

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
<thead>
<tr>
<td>
<h4>About Enum</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Core.Data.ElysiumStage.ElysiumStage"></a>
<tr>
<td width="70%">

<h5>ElysiumStage</h5>

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
`None` — initial state. `Initializing` — startup has begun. `DatabasesConnecting` / `DatabasesConnected` — SQLite connection stages. `ExtensionsInitializing` / `ExtensionInitialized` — extension processing stages. `Ready` — the system is fully operational. `Disposing` / `Disposed` — shutdown stages.
</td>
<td width="30%">

```csharp
elysiumDatabase.OnStageChanged += (stage, context) =>
{
    if (stage == ElysiumStage.Ready)
        Debug.Log("ElysiumDB is ready");
};
```
</td>
</tr>
<tbody>
</table>

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Core.Data.ExtensionEvent"></a>
## ModuDevCore.ElysiumDB.Core.Data.ExtensionEvent

### Opportunities

* Identifies whether an extension is being initialized or disposed.
* Passed to `DBExtensionBase.Process` and used by `ElysiumDatabase.Suspend`/`Resume`.

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
<thead>
<tr>
<td>
<h4>About Enum</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Core.Data.ExtensionEvent.ExtensionEvent"></a>
<tr>
<td width="70%">

<h5>ExtensionEvent</h5>

```csharp
public enum ExtensionEvent {
    Initialize = 0,
    Dispose = 1
}
```
`Initialize` — extension initialization event. `Dispose` — extension disposal event, processed in reverse order relative to initialization.
</td>
<td width="30%">

```csharp
elysiumDatabase.Suspend(ExtensionEvent.Initialize);
// ... later
elysiumDatabase.Resume(ExtensionEvent.Initialize);
```
</td>
</tr>
<tbody>
</table>

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.DBMeta"></a>
## ModuDevCore.ElysiumDB.DBMeta

### Opportunities

* Wraps a single SQLite connection with convenient query helpers (`Query`, `QueryFirst`, `QueryList`, `QueryColumn`, `QueryValue`, `QueryDictionary`, `Execute`, `Exists`).
* Automatically maps query results onto your own POCO classes by matching column names to public properties.
* Every query and command is logged automatically for easier debugging.

### Declaration

```csharp
public class DBMeta : IDisposable
```

Obtained from `ElysiumDatabase.Connections` or `ElysiumDatabase.this[string]`; represents one connected database.

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
<a id="ModuDevCore.ElysiumDB.DBMeta.connection"></a>
<tr>
<td width="70%">

<h5>connection</h5>

```csharp
public IDbConnection connection;
```
The underlying open database connection.
</td>
<td width="30%">

```csharp
IDbConnection raw = db.connection;
```
</td>
</tr>
<tbody>
</table>

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
<a id="ModuDevCore.ElysiumDB.DBMeta.SqliteConnectionStringBuilder"></a>
<tr>
<td width="70%">

<h5>SqliteConnectionStringBuilder</h5>

```csharp
public SqliteConnectionStringBuilder SqliteConnectionStringBuilder { get; }
```
Returns a connection string builder parsed from the current connection's connection string.
</td>
<td width="30%">

```csharp
string dataSource = db.SqliteConnectionStringBuilder.DataSource;
```
</td>
</tr>
<tbody>
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
<a id="ModuDevCore.ElysiumDB.DBMeta.Dispose"></a>
<tr>
<td width="70%">

<h5>Dispose</h5>

```csharp
public void Dispose()
```
Closes and releases the database connection.
</td>
<td width="30%">

```csharp
db.Dispose();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.Query"></a>
<tr>
<td width="70%">

<h5>Query</h5>

```csharp
public IDataReader Query(
    string cmd,
    int linesToRead = 0,
    (string name, object value)[] parameters = null
)
```
Executes an SQL query and returns a raw `IDataReader`.
</td>
<td width="30%">

```csharp
using var reader = db.Query("SELECT * FROM Items");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.QueryFirst"></a>
<tr>
<td width="70%">

<h5>QueryFirst&lt;T&gt;</h5>

```csharp
public T QueryFirst<T>(
    string cmd,
    int linesToRead = 0,
    (string name, object value)[] parameters = null
) where T : new()
```
Executes a query and maps the first result row onto an object of type `T`.
</td>
<td width="30%">

```csharp
var item = db.QueryFirst<Item>(
    "SELECT * FROM Items WHERE id = @id",
    parameters: new (string, object)[] { ("@id", 1) });
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.QueryList"></a>
<tr>
<td width="70%">

<h5>QueryList&lt;T&gt;</h5>

```csharp
public List<T> QueryList<T>(
    string cmd,
    int linesToRead = 0,
    (string name, object value)[] parameters = null
) where T : new()
```
Executes a query and maps all result rows onto a list of objects of type `T`.
</td>
<td width="30%">

```csharp
var items = db.QueryList<Item>("SELECT * FROM Items");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.QueryColumn"></a>
<tr>
<td width="70%">

<h5>QueryColumn&lt;T&gt;</h5>

```csharp
public List<T> QueryColumn<T>(string cmd)
```
Executes a query and returns the values of the first column as a list of `T`.
</td>
<td width="30%">

```csharp
var ids = db.QueryColumn<int>("SELECT id FROM Items");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.QueryValue"></a>
<tr>
<td width="70%">

<h5>QueryValue&lt;T&gt;</h5>

```csharp
public T QueryValue<T>(
    string cmd,
    (string name, object value)[] parameters = null
)
```
Executes a query and returns a single value converted to type `T`.
</td>
<td width="30%">

```csharp
int count = db.QueryValue<int>("SELECT COUNT(*) FROM Items");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.QueryDictionary"></a>
<tr>
<td width="70%">

<h5>QueryDictionary&lt;TKey, TValue&gt;</h5>

```csharp
public Dictionary<TKey, TValue> QueryDictionary<TKey, TValue>(
    string cmd,
    (string name, object value)[] parameters = null
)
```
Executes a query and returns a dictionary built from the first two columns of the result.
</td>
<td width="30%">

```csharp
var map = db.QueryDictionary<int, string>(
    "SELECT id, name FROM Items");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.Execute"></a>
<tr>
<td width="70%">

<h5>Execute</h5>

```csharp
public void Execute(
    string cmd,
    (string name, object value)[] parameters = null
)
```
Executes an SQL command without returning a result.
</td>
<td width="30%">

```csharp
db.Execute(
    "DELETE FROM Items WHERE id = @id",
    new (string, object)[] { ("@id", 1) });
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.Exists"></a>
<tr>
<td width="70%">

<h5>Exists</h5>

```csharp
public bool Exists(
    string cmd,
    (string name, object value)[] parameters = null
)
```
Executes a query and returns `true` if it produced at least one row.
</td>
<td width="30%">

```csharp
bool hasItem = db.Exists(
    "SELECT 1 FROM Items WHERE id = @id",
    new (string, object)[] { ("@id", 1) });
```
</td>
</tr>
<tbody>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.ElysiumDatabase"></a>
## ModuDevCore.ElysiumDB.ElysiumDatabase

### Opportunities

* Central entry point of the plugin: manages database connections and the full extension lifecycle.
* Lets you connect existing SQLite databases from `StreamingAssets` or create brand-new ones at runtime.
* Provides static helpers to get, add, and remove extensions by type from anywhere in your code.
* Exposes the `OnStageChanged` event so your code can react to startup/shutdown progress.

### Declaration

```csharp
public class ElysiumDatabase : IDisposable
```

The main class you interact with to start ElysiumDB, access connected databases, and manage extensions.

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
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Instance"></a>
<tr>
<td width="70%">

<h5>Instance</h5>

```csharp
public static ElysiumDatabase Instance;
```
The currently active `ElysiumDatabase` instance, set after calling `New()`.
</td>
<td width="30%">

```csharp
var db = ElysiumDatabase.Instance;
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Connections"></a>
<tr>
<td width="70%">

<h5>Connections</h5>

```csharp
public Dictionary<string, DBMeta> Connections = new Dictionary<string, DBMeta>();
```
All active database connections keyed by their relative path.
</td>
<td width="30%">

```csharp
DBMeta db = ElysiumDatabase.Instance.Connections["MyDB.db"];
```
</td>
</tr>
<tbody>
</table>

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
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Settings"></a>
<tr>
<td width="70%">

<h5>Settings</h5>

```csharp
public static ElysiumDBSettings Settings { get; }
```
Loads and returns the `ElysiumDBSettings` asset.
</td>
<td width="30%">

```csharp
var paths = ElysiumDatabase.Settings.dbPaths;
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.IsOffline"></a>
<tr>
<td width="70%">

<h5>IsOffline</h5>

```csharp
public static bool IsOffline { get; }
```
Returns `true` when there is no internet connectivity.
</td>
<td width="30%">

```csharp
if (ElysiumDatabase.IsOffline)
    Debug.LogWarning("No internet connection");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.PlatformDataPath"></a>
<tr>
<td width="70%">

<h5>PlatformDataPath</h5>

```csharp
public static string PlatformDataPath { get; }
```
Returns the platform-specific application data directory used to store runtime database files.
</td>
<td width="30%">

```csharp
string path = ElysiumDatabase.PlatformDataPath;
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Item"></a>
<tr>
<td width="70%">

<h5>this[string database]</h5>

```csharp
public DBMeta this[string database] { get; }
```
Indexer providing quick access to a connected database by its path.
</td>
<td width="30%">

```csharp
DBMeta db = ElysiumDatabase.Instance["MyDB.db"];
```
</td>
</tr>
<tbody>
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
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Log"></a>
<tr>
<td width="70%">

<h5>Log / LogWarning / LogError</h5>

```csharp
public static void Log(string message)
public static void LogWarning(string message)
public static void LogError(string message)
```
Queues a message for the current instance's internal log.
</td>
<td width="30%">

```csharp
ElysiumDatabase.Log("Hello from ElysiumDB");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Suspend"></a>
<tr>
<td width="70%">

<h5>Suspend</h5>

```csharp
public void Suspend(ExtensionEvent extensionEvent)
```
Pauses further processing of the extension queue for the given event.
</td>
<td width="30%">

```csharp
db.Suspend(ExtensionEvent.Initialize);
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Resume"></a>
<tr>
<td width="70%">

<h5>Resume</h5>

```csharp
public void Resume(ExtensionEvent extensionEvent)
```
Resumes processing of the extension queue for the given event.
</td>
<td width="30%">

```csharp
db.Resume(ExtensionEvent.Initialize);
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensionGeneric"></a>
<tr>
<td width="70%">

<h5>GetExtension&lt;T&gt;</h5>

```csharp
public static T GetExtension<T>() where T : class
```
Returns the first extension implementing/inheriting type `T`, or `null`.
</td>
<td width="30%">

```csharp
var auth = ElysiumDatabase.GetExtension<AuthElysiumDB>();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensionsGeneric"></a>
<tr>
<td width="70%">

<h5>GetExtensions&lt;T&gt;</h5>

```csharp
public static T[] GetExtensions<T>() where T : class
```
Returns all extensions convertible to type `T`.
</td>
<td width="30%">

```csharp
var receivers = ElysiumDatabase.GetExtensions<IAuthElysiumReceiver>();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.HasExtensionGeneric"></a>
<tr>
<td width="70%">

<h5>HasExtension&lt;T&gt;</h5>

```csharp
public static bool HasExtension<T>() where T : class
```
Checks whether at least one extension of type `T` exists.
</td>
<td width="30%">

```csharp
if (ElysiumDatabase.HasExtension<AuthElysiumDB>())
    Debug.Log("Auth extension present");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.TryGetExtensionGeneric"></a>
<tr>
<td width="70%">

<h5>TryGetExtension&lt;T&gt;</h5>

```csharp
public static bool TryGetExtension<T>(out T extension) where T : class
```
Attempts to obtain an extension of type `T`.
</td>
<td width="30%">

```csharp
if (ElysiumDatabase.TryGetExtension<AuthElysiumDB>(out var auth))
    auth.SignOut();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.AddExtensionGeneric"></a>
<tr>
<td width="70%">

<h5>AddExtension&lt;T&gt;</h5>

```csharp
public static T AddExtension<T>() where T : DBExtensionBase, new()
```
Creates and registers a new extension of type `T`.
</td>
<td width="30%">

```csharp
var auth = ElysiumDatabase.AddExtension<AuthElysiumDB>();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.RemoveExtensionGeneric"></a>
<tr>
<td width="70%">

<h5>RemoveExtension&lt;T&gt;</h5>

```csharp
public static bool RemoveExtension<T>() where T : DBExtensionBase
```
Removes the first extension of type `T`, if nothing else depends on it.
</td>
<td width="30%">

```csharp
ElysiumDatabase.RemoveExtension<AuthElysiumDB>();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtension"></a>
<tr>
<td width="70%">

<h5>GetExtension(Type)</h5>

```csharp
public static object GetExtension(Type type)
```
Returns the first extension of the given type, or `null`.
</td>
<td width="30%">

```csharp
var auth = ElysiumDatabase.GetExtension(typeof(AuthElysiumDB));
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensions"></a>
<tr>
<td width="70%">

<h5>GetExtensions(Type)</h5>

```csharp
public static object[] GetExtensions(Type type)
```
Returns all extensions convertible to the given type.
</td>
<td width="30%">

```csharp
var extensions = ElysiumDatabase.GetExtensions(typeof(DBExtensionBase));
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.HasExtension"></a>
<tr>
<td width="70%">

<h5>HasExtension(Type)</h5>

```csharp
public static bool HasExtension(Type type)
```
Checks whether at least one extension of the given type exists.
</td>
<td width="30%">

```csharp
bool hasAuth = ElysiumDatabase.HasExtension(typeof(AuthElysiumDB));
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.TryGetExtension"></a>
<tr>
<td width="70%">

<h5>TryGetExtension(Type, out object)</h5>

```csharp
public static bool TryGetExtension(Type type, out object extension)
```
Attempts to obtain the first extension of the given type.
</td>
<td width="30%">

```csharp
if (ElysiumDatabase.TryGetExtension(typeof(AuthElysiumDB), out var ext))
    Debug.Log(ext);
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.AddExtension"></a>
<tr>
<td width="70%">

<h5>AddExtension(Type)</h5>

```csharp
public static object AddExtension(Type type)
```
Creates and registers a new extension of the given type, applying its default group and mandatory-dependency checks.
</td>
<td width="30%">

```csharp
ElysiumDatabase.AddExtension(typeof(AuthElysiumDB));
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.RemoveExtension"></a>
<tr>
<td width="70%">

<h5>RemoveExtension(Type)</h5>

```csharp
public static bool RemoveExtension(Type type)
```
Removes the extension of the given type, if nothing else depends on it.
</td>
<td width="30%">

```csharp
ElysiumDatabase.RemoveExtension(typeof(AuthElysiumDB));
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetRequiresExtensions"></a>
<tr>
<td width="70%">

<h5>GetRequiresExtensions</h5>

```csharp
public static List<Type> GetRequiresExtensions(Type extensionType)
```
Returns the list of extension types that depend on the given type.
</td>
<td width="30%">

```csharp
var dependents = ElysiumDatabase.GetRequiresExtensions(typeof(AuthElysiumDB));
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.New"></a>
<tr>
<td width="70%">

<h5>New</h5>

```csharp
public void New()
```
Initializes the system: connects all configured databases and processes extensions for the `Initialize` event.
</td>
<td width="30%">

```csharp
var db = new ElysiumDatabase();
db.New();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.DetachDB"></a>
<tr>
<td width="70%">

<h5>DetachDB</h5>

```csharp
public void DetachDB(string path)
```
Closes and removes the database connection at the given path.
</td>
<td width="30%">

```csharp
db.DetachDB("MyDB.db");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.ConnectDB"></a>
<tr>
<td width="70%">

<h5>ConnectDB</h5>

```csharp
public void ConnectDB(string path)
```
Copies a database from `StreamingAssets` (if needed) and opens a connection to it.
</td>
<td width="30%">

```csharp
db.ConnectDB("MyDB.db");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.CreateSQLiteDatabase"></a>
<tr>
<td width="70%">

<h5>CreateSQLiteDatabase</h5>

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
Creates a brand-new SQLite database file at the given path and registers the connection.
</td>
<td width="30%">

```csharp
db.CreateSQLiteDatabase("NewDB.db");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Dispose"></a>
<tr>
<td width="70%">

<h5>Dispose</h5>

```csharp
public void Dispose()
```
Closes all connections and processes extensions for the `Dispose` event.
</td>
<td width="30%">

```csharp
ElysiumDatabase.Instance.Dispose();
```
</td>
</tr>
<tbody>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings"></a>
## ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings

### Opportunities

* Stores the configuration for ElysiumDB: which databases to connect, which extensions are registered, and which log categories are shown.
* Edited from the Unity Inspector, and readable at runtime via `ElysiumDatabase.Settings`.

### Declaration

```csharp
public class ElysiumDBSettings : ScriptableObject
```

A `ScriptableObject` asset automatically created and maintained under `Assets/ElysiumDB/Resources`.

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
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.logIgnorePatterns"></a>
<tr>
<td width="70%">

<h5>logIgnorePatterns</h5>

```csharp
public List<string> logIgnorePatterns = new List<string>();
```
Substrings; any log message containing one of them is not displayed.
</td>
<td width="30%">

```csharp
ElysiumDatabase.Settings.logIgnorePatterns.Add("heartbeat");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.dbPaths"></a>
<tr>
<td width="70%">

<h5>dbPaths</h5>

```csharp
public List<string> dbPaths = new List<string>();
```
Relative paths of the databases connected automatically when `ElysiumDatabase.New()` runs.
</td>
<td width="30%">

```csharp
ElysiumDatabase.Settings.dbPaths.Add("MyDB.db");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.extensions"></a>
<tr>
<td width="70%">

<h5>extensions</h5>

```csharp
[SerializeReference]
public List<DBExtensionBase> extensions = new();
```
The list of extensions registered in the project.
</td>
<td width="30%">

```csharp
foreach (var ext in ElysiumDatabase.Settings.extensions)
    Debug.Log(ext.extensionName);
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showLogs"></a>
<tr>
<td width="70%">

<h5>showLogs</h5>

```csharp
public bool showLogs = true;
```
Master toggle for displaying ElysiumDB logs.
</td>
<td width="30%">

```csharp
ElysiumDatabase.Settings.showLogs = false;
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showSqlLogs"></a>
<tr>
<td width="70%">

<h5>showSqlLogs</h5>

```csharp
public bool showSqlLogs = true;
```
Toggle for displaying SQL query logs.
</td>
<td width="30%">

```csharp
ElysiumDatabase.Settings.showSqlLogs = false;
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showCoreLogs"></a>
<tr>
<td width="70%">

<h5>showCoreLogs</h5>

```csharp
public bool showCoreLogs = true;
```
Toggle for displaying core and database-loader logs.
</td>
<td width="30%">

```csharp
ElysiumDatabase.Settings.showCoreLogs = false;
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showDefaultLogs"></a>
<tr>
<td width="70%">

<h5>showDefaultLogs</h5>

```csharp
public bool showDefaultLogs = true;
```
Toggle for displaying default-level logs.
</td>
<td width="30%">

```csharp
ElysiumDatabase.Settings.showDefaultLogs = false;
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.ElysiumDBSettings.showExtensionProccesingLogs"></a>
<tr>
<td width="70%">

<h5>showExtensionProccesingLogs</h5>

```csharp
public bool showExtensionProccesingLogs = true;
```
Toggle for displaying extension-processing logs.
</td>
<td width="30%">

```csharp
ElysiumDatabase.Settings.showExtensionProccesingLogs = false;
```
</td>
</tr>
<tbody>
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

<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase"></a>
## ModuDevCore.ElysiumDB.Extension.DBExtensionBase

### Opportunities

* The base class for writing your own ElysiumDB extensions — override `OnInitialize`/`OnDispose` to add custom behaviour.
* Provides convenient shortcuts for accessing sibling extensions (`GetExtension`, `HasExtension`, `AddExtension`, `RemoveExtension`).
* Can be toggled on/off, grouped in the inspector, and combined with `RequireExtensionAttribute` / `AfterExtensionAttribute` / `ExtensionProcessOrderAttribute` to control dependencies and ordering.

### Declaration

```csharp
[Serializable]
public class DBExtensionBase
```

Inherit from this class to create your own ElysiumDB extension.

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
[HideInInspector]
public bool enabled = true;
```
Whether the extension is active; disabled extensions do not receive the `Initialize` event.
</td>
<td width="30%">

```csharp
myExtension.enabled = false;
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionGroup"></a>
<tr>
<td width="70%">

<h5>extensionGroup</h5>

```csharp
[HideInInspector]
public string extensionGroup = "";
```
The inspector group (folder path) the extension belongs to.
</td>
<td width="30%">

```csharp
Debug.Log(myExtension.extensionGroup);
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionId"></a>
<tr>
<td width="70%">

<h5>extensionId</h5>

```csharp
[HideInInspector]
public int extensionId = -1;
```
A unique identifier automatically assigned to the extension.
</td>
<td width="30%">

```csharp
Debug.Log(myExtension.extensionId);
```
</td>
</tr>
<tbody>
</table>

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
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionName"></a>
<tr>
<td width="70%">

<h5>extensionName</h5>

```csharp
public string extensionName { get; }
```
The type name of the current extension.
</td>
<td width="30%">

```csharp
Debug.Log(myExtension.extensionName);
```
</td>
</tr>
<tbody>
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
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtensionGeneric"></a>
<tr>
<td width="70%">

<h5>GetExtension&lt;T&gt;</h5>

```csharp
public T GetExtension<T>() where T : class
```
Shortcut for `ElysiumDatabase.GetExtension<T>()`.
</td>
<td width="30%">

```csharp
var auth = GetExtension<AuthElysiumDB>();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtensionsGeneric"></a>
<tr>
<td width="70%">

<h5>GetExtensions&lt;T&gt;</h5>

```csharp
public T[] GetExtensions<T>() where T : class
```
Shortcut for `ElysiumDatabase.GetExtensions<T>()`.
</td>
<td width="30%">

```csharp
var receivers = GetExtensions<IAuthElysiumReceiver>();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.TryGetExtensions"></a>
<tr>
<td width="70%">

<h5>TryGetExtensions&lt;T&gt;</h5>

```csharp
public bool TryGetExtensions<T>(out T[] extensions) where T : class
```
Retrieves all extensions of type `T`, returning `true` if at least one was found.
</td>
<td width="30%">

```csharp
if (TryGetExtensions<IAuthElysiumReceiver>(out var receivers))
{
    // use receivers
}
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.HasExtension"></a>
<tr>
<td width="70%">

<h5>HasExtension&lt;T&gt;</h5>

```csharp
public bool HasExtension<T>() where T : class
```
Shortcut for `ElysiumDatabase.HasExtension<T>()`.
</td>
<td width="30%">

```csharp
if (HasExtension<AuthElysiumDB>())
{
    // ...
}
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.AddExtension"></a>
<tr>
<td width="70%">

<h5>AddExtension&lt;T&gt;</h5>

```csharp
public T AddExtension<T>() where T : DBExtensionBase, new()
```
Shortcut for `ElysiumDatabase.AddExtension<T>()`.
</td>
<td width="30%">

```csharp
AddExtension<AuthElysiumDB>();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.RemoveExtension"></a>
<tr>
<td width="70%">

<h5>RemoveExtension&lt;T&gt;</h5>

```csharp
public bool RemoveExtension<T>() where T : DBExtensionBase, new()
```
Shortcut for `ElysiumDatabase.RemoveExtension<T>()`.
</td>
<td width="30%">

```csharp
RemoveExtension<AuthElysiumDB>();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnInitialize"></a>
<tr>
<td width="70%">

<h5>OnInitialize</h5>

```csharp
protected virtual void OnInitialize(ElysiumDatabase elysium) {}
```
Override this method to run your extension's initialization logic.
</td>
<td width="30%">

```csharp
protected override void OnInitialize(ElysiumDatabase elysium)
{
    elysium.CreateSQLiteDatabase("MyExtension.db");
}
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnDispose"></a>
<tr>
<td width="70%">

<h5>OnDispose</h5>

```csharp
protected virtual void OnDispose() {}
```
Override this method to run your extension's cleanup logic on disposal.
</td>
<td width="30%">

```csharp
protected override void OnDispose()
{
    ElysiumDatabase.Instance?.DetachDB("MyExtension.db");
}
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Log"></a>
<tr>
<td width="70%">

<h5>Log</h5>

```csharp
public void Log(object message)
```
Logs a message tagged with the extension's own name.
</td>
<td width="30%">

```csharp
Log("Extension initialized");
```
</td>
</tr>
<tbody>
</table>

## Enum
None

## Nested Classes
None

---

<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer"></a>
## ModuDevCore.ElysiumDB.Editor.ExtensionDrawer

### Opportunities

* Base `PropertyDrawer` class for writing a custom inspector for your own extension type.
* Gives access to `Settings` and to the same extension-lookup helpers available on `DBExtensionBase`.
* Provides `DrawDefaultExtension`/`GetChildrenHeight` to fall back to the default field layout when needed.

### Declaration

```csharp
public abstract class ExtensionDrawer : PropertyDrawer
```

Inherit from this class (instead of `PropertyDrawer` directly) to build a custom editor for a `DBExtensionBase` derivative.

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
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.target"></a>
<tr>
<td width="70%">

<h5>target</h5>

```csharp
public object target = null;
```
The boxed value of the extension currently being drawn.
</td>
<td width="30%">

```csharp
var myExtension = (MyExtension)target;
```
</td>
</tr>
<tbody>
</table>

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
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.Settings"></a>
<tr>
<td width="70%">

<h5>Settings</h5>

```csharp
protected ElysiumDBSettings Settings { get; }
```
Shortcut for `ElysiumDatabase.Settings`.
</td>
<td width="30%">

```csharp
var paths = Settings.dbPaths;
```
</td>
</tr>
<tbody>
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
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetExtensionGeneric"></a>
<tr>
<td width="70%">

<h5>GetExtension&lt;T&gt;</h5>

```csharp
public T GetExtension<T>() where T : class
```
Shortcut for `ElysiumDatabase.GetExtension<T>()`.
</td>
<td width="30%">

```csharp
var auth = GetExtension<AuthElysiumDB>();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetExtensionsGeneric"></a>
<tr>
<td width="70%">

<h5>GetExtensions&lt;T&gt;</h5>

```csharp
public T[] GetExtensions<T>() where T : class
```
Shortcut for `ElysiumDatabase.GetExtensions<T>()`.
</td>
<td width="30%">

```csharp
var receivers = GetExtensions<IAuthElysiumReceiver>();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.TryGetExtensions"></a>
<tr>
<td width="70%">

<h5>TryGetExtensions&lt;T&gt;</h5>

```csharp
public bool TryGetExtensions<T>(out T[] extensions) where T : class
```
Retrieves all extensions of type `T`, returning `true` if at least one was found.
</td>
<td width="30%">

```csharp
if (TryGetExtensions<IAuthElysiumReceiver>(out var receivers))
{
    // use receivers
}
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.HasExtension"></a>
<tr>
<td width="70%">

<h5>HasExtension&lt;T&gt;</h5>

```csharp
public bool HasExtension<T>() where T : class
```
Shortcut for `ElysiumDatabase.HasExtension<T>()`.
</td>
<td width="30%">

```csharp
if (HasExtension<AuthElysiumDB>())
{
    // ...
}
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.AddExtension"></a>
<tr>
<td width="70%">

<h5>AddExtension&lt;T&gt;</h5>

```csharp
public T AddExtension<T>() where T : DBExtensionBase, new()
```
Shortcut for `ElysiumDatabase.AddExtension<T>()`.
</td>
<td width="30%">

```csharp
AddExtension<AuthElysiumDB>();
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.RemoveExtension"></a>
<tr>
<td width="70%">

<h5>RemoveExtension&lt;T&gt;</h5>

```csharp
public bool RemoveExtension<T>() where T : DBExtensionBase, new()
```
Shortcut for `ElysiumDatabase.RemoveExtension<T>()`.
</td>
<td width="30%">

```csharp
RemoveExtension<AuthElysiumDB>();
```
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
)
```
Draws all visible child fields of the extension using the default layout.
</td>
<td width="30%">

```csharp
protected override void OnExtensionGUI(
    Rect position, SerializedProperty property, GUIContent label)
{
    DrawDefaultExtension(position, property);
}
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetChildrenHeight"></a>
<tr>
<td width="70%">

<h5>GetChildrenHeight</h5>

```csharp
public float GetChildrenHeight(SerializedProperty property)
```
Computes the total height needed to draw all visible child fields.
</td>
<td width="30%">

```csharp
protected override float GetExtensionHeight(
    SerializedProperty property, GUIContent label)
    => GetChildrenHeight(property);
```
</td>
</tr>
<tbody>
</table>

## Enum
None

## Nested Classes
None

---

<a id="AuthElysiumDB"></a>
## AuthElysiumDB

### Opportunities

* A ready-made authentication extension: stores a JWT token, expiry date, and user id in its own SQLite database.
* Restores a saved session automatically on startup and notifies your code through `IAuthElysiumReceiver`.
* Reads `exp` and `sub` claims straight out of the JWT payload, so you don't need a separate JWT library.

### Declaration

```csharp
public class AuthElysiumDB : DBExtensionBase
```

Add this extension via `ElysiumDatabase.AddExtension<AuthElysiumDB>()` to enable JWT-based authentication storage.

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
<a id="AuthElysiumDB.authTable"></a>
<tr>
<td width="70%">

<h5>authTable</h5>

```csharp
public DBMeta authTable;
```
The database connection holding the authentication session table.
</td>
<td width="30%">

```csharp
int userCount = auth.authTable
    .QueryValue<int>("SELECT COUNT(*) FROM AuthSession");
```
</td>
</tr>
<tbody>
</table>

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
<a id="AuthElysiumDB.IsAuthenticated"></a>
<tr>
<td width="70%">

<h5>IsAuthenticated</h5>

```csharp
public bool IsAuthenticated { get; private set; }
```
Whether there is currently an active authenticated session.
</td>
<td width="30%">

```csharp
if (auth.IsAuthenticated)
{
    // ...
}
```
</td>
</tr>
<tbody>
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
<a id="AuthElysiumDB.Auth"></a>
<tr>
<td width="70%">

<h5>Auth</h5>

```csharp
public async Task Auth(string credentials)
```
Stores the given JWT token as the active session and notifies subscribers.
</td>
<td width="30%">

```csharp
await auth.Auth(jwtToken);
```
</td>
</tr>
<a id="AuthElysiumDB.SignOut"></a>
<tr>
<td width="70%">

<h5>SignOut</h5>

```csharp
public void SignOut()
```
Clears the stored session and notifies subscribers that the token was reset.
</td>
<td width="30%">

```csharp
auth.SignOut();
```
</td>
</tr>
<a id="AuthElysiumDB.GetCredentials"></a>
<tr>
<td width="70%">

<h5>GetCredentials</h5>

```csharp
public ElysiumAuthCredentials GetCredentials()
```
Returns the currently stored credentials, or `null` if there is no session.
</td>
<td width="30%">

```csharp
var creds = auth.GetCredentials();
```
</td>
</tr>
<tbody>
</table>

## Enum
None

## Nested Classes

<table>
<thead>
<tr>
<td>
<h4>About Class</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ElysiumAuthCredentials"></a>
<tr>
<td width="70%">

<h5>ElysiumAuthCredentials</h5>

```csharp
public class ElysiumAuthCredentials
{
    public string jwt_token { get; set; }
    public string user_id { get; set; }
}
```
A simple data holder for the stored JWT token and user id.
</td>
<td width="30%">

```csharp
var creds = auth.GetCredentials();
Debug.Log(creds.user_id);
```
</td>
</tr>
<a id="IAuthElysiumReceiver"></a>
<tr>
<td width="70%">

<h5>IAuthElysiumReceiver</h5>

```csharp
public interface IAuthElysiumReceiver
{
    void OnAuthTokenUpdated(string newJwt);
    void OnAuthLoggedOut();
    Task OnFetchAuthUserData(DBMeta authTable);
}
```
Implement this interface on your own extension to react to authentication events raised by `AuthElysiumDB`: token updates, sign-out, and post-login user data loading.
</td>
<td width="30%">

```csharp
public class MyExtension : DBExtensionBase, IAuthElysiumReceiver
{
    public void OnAuthTokenUpdated(string newJwt) { }
    public void OnAuthLoggedOut() { }
    public async Task OnFetchAuthUserData(DBMeta authTable) { }
}
```
</td>
</tr>
<tbody>
</table>

---

<a id="ModuDevCore.ElysiumDB.Internal.DBLogger"></a>
## ModuDevCore.ElysiumDB.Internal.DBLogger

### Opportunities

* A shared logging helper for writing consistent, color-formatted log messages from your own extensions.
* Respects the log toggles and ignore patterns configured on `ElysiumDBSettings`.

### Declaration

```csharp
public static class DBLogger
```

Use these static methods from your extension code instead of calling `Debug.Log` directly, so your messages respect the project's logging settings.

## Fields
None

## Properties
None

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
<a id="ModuDevCore.ElysiumDB.Internal.DBLogger.Log"></a>
<tr>
<td width="70%">

<h5>Log</h5>

```csharp
public static void Log(
    object message,
    ContextLevel contextLevel = ContextLevel.Default
)
```
Outputs a message if it is not filtered out by the current logging settings.
</td>
<td width="30%">

```csharp
DBLogger.Log("Something happened");
```
</td>
</tr>
<a id="ModuDevCore.ElysiumDB.Internal.DBLogger.LogContext"></a>
<tr>
<td width="70%">

<h5>LogContext</h5>

```csharp
public static void LogContext(
    string contextName,
    object message,
    ContextLevel contextLevel = ContextLevel.Default
)
```
Outputs a message prefixed with a colored context name, such as an extension name.
</td>
<td width="30%">

```csharp
DBLogger.LogContext("MyExtension", "Initialized");
```
</td>
</tr>
<tbody>
</table>

## Enum

<table>
<thead>
<tr>
<td>
<h4>About Enum</h4>
</td>
<td>
<h4>Example</h4>
</td>
</tr>
</thead>
<tbody>
<a id="ModuDevCore.ElysiumDB.Internal.DBLogger.ContextLevel"></a>
<tr>
<td width="70%">

<h5>ContextLevel</h5>

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
`Default` — regular logs. `Core` — core system logs. `Hidden` — logs that are never shown. `SQLQuery` — SQL query logs. `DBLoader` — database loading/connection logs. `ExtensionProccesing` — extension processing logs.
</td>
<td width="30%">

```csharp
DBLogger.Log("Query executed", DBLogger.ContextLevel.SQLQuery);
```
</td>
</tr>
<tbody>
</table>

## Nested Classes
None