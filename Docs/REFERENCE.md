# API Reference

Complete reference documentation for the public API of the ElysiumDB library.
This section describes all **public** classes, interfaces, enumerations, and other types available for developers.

> **Note:** This file contains only public types intended for end developers.
> Internal (`internal`), private, and editor-related types (everything inside `.Editor`, `.Internal`, `.Core.Settings.Editor` namespaces) are **not included** here — they are documented only in `TECHNICAL.md`.

---

## Contents

* [Classes](#classes)
* [Enumerations](#enumerations)

---

## Classes

<a id="ModuDevCore.ElysiumDB.ElysiumDatabase"></a>

## ModuDevCore.ElysiumDB.ElysiumDatabase

### Opportunities

* Central database manager for ElysiumDB runtime
* Extension-based modular system control and lifecycle management
* Cross-platform SQLite database connection handling
* Reflection-driven extension discovery and processing
* Unified API for database and extension operations

---

### Class

```csharp
public class ElysiumDatabase : IDisposable
```

---

Core runtime class of the ElysiumDB system.
Responsible for managing database connections, executing extension lifecycle events, and providing a global API for extension registration, lookup, and removal.
Also handles platform-specific file access and initialization of persistent databases.

---

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
<td>Global singleton instance of the ElysiumDatabase runtime context.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Connections"></a>
<td><code>Connections</code></td>
<td>

```csharp
public Dictionary<string, DBMeta> Connections = new Dictionary<string, DBMeta>();
```

</td>
<td>Active database connections mapped by database path identifier.</td>
</tr>
</table>

---

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
<td>Loads and provides global ElysiumDB settings from Unity Resources.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.IsOffline"></a>
<td><code>IsOffline</code></td>
<td>

```csharp
public static bool IsOffline { get; }
```

</td>
<td>Indicates whether the application currently has no network connectivity.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.PlatformDataPath"></a>
<td><code>PlatformDataPath</code></td>
<td>

```csharp
public static string PlatformDataPath { get; }
```

</td>
<td>Returns platform-specific persistent data path (Android-safe override included).</td>
</tr>
</table>

---

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtension_Generic"></a>
<td><code>GetExtension&lt;T&gt;</code></td>
<td>

```csharp
public static T GetExtension<T>() where T : class
```

</td>
<td>Returns the first registered extension of type T.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensions_Generic"></a>
<td><code>GetExtensions&lt;T&gt;</code></td>
<td>

```csharp
public static T[] GetExtensions<T>() where T : class
```

</td>
<td>Returns all registered extensions of type T.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.HasExtension_Generic"></a>
<td><code>HasExtension&lt;T&gt;</code></td>
<td>

```csharp
public static bool HasExtension<T>() where T : class
```

</td>
<td>Checks whether any extension of type T is registered.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.TryGetExtension_Generic"></a>
<td><code>TryGetExtension&lt;T&gt;</code></td>
<td>

```csharp
public static bool TryGetExtension<T>(out T extension) where T : class
```

</td>
<td>Attempts to retrieve an extension of type T.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.AddExtension_Generic"></a>
<td><code>AddExtension&lt;T&gt;</code></td>
<td>

```csharp
public static T AddExtension<T>() where T : DBExtensionBase, new()
```

</td>
<td>Creates and registers a new extension of type T.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.RemoveExtension_Generic"></a>
<td><code>RemoveExtension&lt;T&gt;</code></td>
<td>

```csharp
public static bool RemoveExtension<T>() where T : DBExtensionBase
```

</td>
<td>Removes a registered extension of type T.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtension_Type"></a>
<td><code>GetExtension(Type)</code></td>
<td>

```csharp
public static object GetExtension(Type type)
```

</td>
<td>Returns the first extension matching the specified runtime type.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensions_Type"></a>
<td><code>GetExtensions(Type)</code></td>
<td>

```csharp
public static object[] GetExtensions(Type type)
```

</td>
<td>Returns all extensions assignable to the specified runtime type.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.HasExtension_Type"></a>
<td><code>HasExtension(Type)</code></td>
<td>

```csharp
public static bool HasExtension(Type type)
```

</td>
<td>Checks whether any extension of the specified type exists.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.TryGetExtension_Type"></a>
<td><code>TryGetExtension(Type, out object)</code></td>
<td>

```csharp
public static bool TryGetExtension(Type type, out object extension)
```

</td>
<td>Attempts to retrieve an extension using runtime type information.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.AddExtension_Type"></a>
<td><code>AddExtension(Type)</code></td>
<td>

```csharp
public static object AddExtension(Type type)
```

</td>
<td>Creates and registers an extension using reflection-based instantiation.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.RemoveExtension_Type"></a>
<td><code>RemoveExtension(Type)</code></td>
<td>

```csharp
public static bool RemoveExtension(Type type)
```

</td>
<td>Removes an extension of the specified runtime type and disposes it.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetRequiresExtensions"></a>
<td><code>GetRequiresExtensions</code></td>
<td>

```csharp
public static List<Type> GetRequiresExtensions(Type extensionType)
```

</td>
<td>Returns a list of extension types that depend on the specified extension.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.ProcessRequiredExtensions"></a>
<td><code>ProcessRequiredExtensions</code></td>
<td>

```csharp
public static void ProcessRequiredExtensions()
```

</td>
<td>Ensures required extensions exist and auto-creates missing ones when allowed.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.New"></a>
<td><code>New</code></td>
<td>

```csharp
public void New()
```

</td>
<td>Initializes the database system, clears connections, and runs extension initialization.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.DetachDB"></a>
<td><code>DetachDB</code></td>
<td>

```csharp
public void DetachDB(string path)
```

</td>
<td>Closes and removes a database connection by path.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.ConnectDB"></a>
<td><code>ConnectDB</code></td>
<td>

```csharp
public void ConnectDB(string path)
```

</td>
<td>Creates and opens a SQLite connection for the specified database path.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Dispose"></a>
<td><code>Dispose</code></td>
<td>

```csharp
public void Dispose()
```

</td>
<td>Releases all database connections and runs extension disposal lifecycle.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.OpenSettings"></a>
<td><code>OpenSettings</code></td>
<td>

```csharp
public static void OpenSettings()
```

</td>
<td>Opens the ElysiumDB settings asset in the Unity editor.</td>
</tr>
</table>

---

## Enum

None

---

## Nested Classes

None

---

<a id="ModuDevCore.ElysiumDB.DBMeta"></a>

## ModuDevCore.ElysiumDB.DBMeta

### Opportunities

* Database connection wrapper
* SQL command execution
* Query logging and filtering

---

### Class

```csharp
public class DBMeta : IDisposable
```

---

Represents a database connection container that provides command execution, query logging, and connection lifecycle management.

---

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
<td>Underlying database connection instance.</td>
</tr>
</table>

---

## Properties

**None**

---

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
<td>Closes and disposes the active database connection.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.RunCmd"></a>
<td><code>RunCmd</code></td>
<td>
```csharp
public IDataReader RunCmd(
    string cmd,
    int linesToRead = 0,
    string callerMethod = "",
    string callerFile = "",
    int callerLine = 0
)
```
</td>
<td>Executes a SQL command, optionally advances the reader by a specified number of rows, and returns the resulting data reader.</td>
</tr>
</table>

---

## Enum

**None**

---

## Nested Classes

**None**

---

<a id="ModuDevCore.ElysiumDB.RequireExtensionAttribute"></a>

## ModuDevCore.ElysiumDB.RequireExtensionAttribute

### Opportunities

* Extension dependency declaration
* Automatic extension creation support
* Extension validation metadata

---

### Class

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public sealed class RequireExtensionAttribute : Attribute
```

---

Defines a dependency between ElysiumDB extensions. Allows an extension to declare that another extension is required and optionally enables automatic creation of the missing dependency.

---

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
<td>Type of the required extension.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.RequireExtensionAttribute.AutoCreate"></a>
<td><code>AutoCreate</code></td>
<td>
```csharp
public bool AutoCreate;
```
</td>
<td>Determines whether the required extension should be automatically created when missing.</td>
</tr>
</table>

---

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.RequireExtensionAttribute.RequireExtensionAttribute"></a>
<td><code>RequireExtensionAttribute</code></td>
<td>
```csharp
public RequireExtensionAttribute(
    Type extensionType,
    bool autoCreate = true)
```
</td>
<td>Creates a new dependency declaration for the specified extension type.</td>
</tr>
</table>

---

## Enum

**None**

---

## Nested Classes

**None**

---

<a id="ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute"></a>

## ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute

### Opportunities

* Defines processing order for database extensions.
* Allows grouping extensions into execution pipelines.
* Provides deterministic extension execution sequence.

---

### Class

```csharp
public class ExtensionProcessOrderAttribute : Attribute
```

---

Attribute used to specify the processing group and execution order of an extension.

---

## Fields

**None**

---

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
<td>Gets the extension processing group name.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute.Order"></a>
<td><code>Order</code></td>
<td>

```csharp
public int Order { get; }
```

</td>
<td>Gets the execution order within the specified group.</td>
</tr>
</table>

---

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute.ExtensionProcessOrderAttribute"></a>
<td><code>ExtensionProcessOrderAttribute</code></td>
<td>

```csharp
public ExtensionProcessOrderAttribute(string group, int order = 0)
```

</td>
<td>Initializes a new instance of the attribute with the specified group and execution order.</td>
</tr>
</table>

---

## Enum

**None**

---

## Nested Classes

**None**

---

<a id="ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute"></a>

## ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute

### Opportunities

* Define default extension grouping metadata for database extensions
* Provide declarative grouping via attribute system
* Enable reflection-based extension organization

---

### Class

```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public sealed class DefaultExtensionGroupAttribute : Attribute
```

---

This attribute is used to assign a default extension group name to a class.
It is primarily intended for use in reflection-based systems where extensions are automatically discovered and categorized within the ElysiumDB architecture.

---

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
<td>Specifies the name of the default extension group assigned to the attributed class.</td>
</tr>
</table>

---

## Properties

None

---

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute.DefaultExtensionGroupAttribute"></a>
<td><code>DefaultExtensionGroupAttribute</code></td>
<td>

```csharp
public DefaultExtensionGroupAttribute(string extensionGroup)
```

</td>
<td>Initializes a new instance of the DefaultExtensionGroupAttribute and assigns the specified extension group name.</td>
</tr>
</table>

---

## Enum

None

---

## Nested Classes

None

---

<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase"></a>

## ModuDevCore.ElysiumDB.Extension.DBExtensionBase

### Opportunities

* Provide a base lifecycle system for database extensions
* Standardize initialization and disposal hooks for modular features
* Enable global access to extensions through `ElysiumDatabase`
* Simplify extension retrieval and management via static helpers

---

### Class

```csharp
[Serializable]
public abstract class DBExtensionBase
```

---

Base class for all Elysium database extensions.

**Recommended usage:**

* Inherit from `DBExtensionBase`
* Override `OnInitialize(...)` and `OnDispose()`
* Use static methods like `GetExtension<T>()`, `AddExtension<T>()` for interaction with other extensions

---

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
public bool enabled;
```
</td>
<td>Determines whether the extension is active and should process events.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionGroup"></a>
<td><code>extensionGroup</code></td>
<td>
```csharp
public string extensionGroup;
```
</td>
<td>Logical grouping identifier for organizing extensions.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionId"></a>
<td><code>extensionId</code></td>
<td>
```csharp
public int extensionId;
```
</td>
<td>Unique identifier for the extension instance inside the database.</td>
</tr>
</table>

---

## Properties

**None**

---

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnInitialize"></a>
<td><code>OnInitialize</code></td>
<td>
```csharp
protected virtual void OnInitialize(ElysiumDatabase elysium)
```
</td>
<td>Called when the extension is initialized. Override this method to perform setup logic.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnDispose"></a>
<td><code>OnDispose</code></td>
<td>
```csharp
protected virtual void OnDispose()
```
</td>
<td>Called when the extension is being disposed. Override this method to perform cleanup logic.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtension"></a>
<td><code>GetExtension</code></td>
<td>
```csharp
public static T GetExtension<T>() where T : class
```
</td>
<td>Returns a single extension instance of type T from the database.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtensions"></a>
<td><code>GetExtensions</code></td>
<td>
```csharp
public static T[] GetExtensions<T>() where T : class
```
</td>
<td>Returns all extension instances of type T.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.TryGetExtensions"></a>
<td><code>TryGetExtensions</code></td>
<td>
```csharp
public static bool TryGetExtensions<T>(out T[] extensions) where T : class
```
</td>
<td>Attempts to retrieve all extensions of type T and returns whether any exist.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.HasExtension"></a>
<td><code>HasExtension</code></td>
<td>
```csharp
public static bool HasExtension<T>() where T : class
```
</td>
<td>Checks whether at least one extension of type T exists in the database.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.AddExtension"></a>
<td><code>AddExtension</code></td>
<td>
```csharp
public static T AddExtension<T>() where T : DBExtensionBase, new()
```
</td>
<td>Creates and registers a new extension instance in the database.</td>
</tr>
</table>

---

## Enumerations

**None** — there are currently no public enumerations in this version of the API.

<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer"></a>

## ModuDevCore.ElysiumDB.Editor.ExtensionDrawer

### Opportunities

* Unified base drawer for ElysiumDB extension rendering in Unity Editor
* Simplifies extension access layer from IMGUI PropertyDrawer context
* Provides reusable GUI utilities for serialized Unity properties
* Reduces boilerplate when implementing custom extension inspectors
* Standardizes extension management (add/remove/query) from editor UI

---

### Class

```csharp
public abstract class ExtensionDrawer : PropertyDrawer
```

Abstract Unity `PropertyDrawer` base class for rendering and managing ElysiumDB extensions inside the Unity Editor.
Provides a unified API layer for accessing `ElysiumDatabase` extensions and building custom IMGUI-based inspectors.

---

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<td colspan="3"><em>None</em></td>
</tr>
</table>

---

## Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<td colspan="3"><em>None</em></td>
</tr>
</table>

---

## Methods

<table>
<tr>
<th>Method</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetExtension"></a>
<td><code>GetExtension&lt;T&gt;</code></td>
<td>

```csharp
public T GetExtension<T>() where T : class
```

</td>
<td>Retrieves a single extension instance of type <code>T</code> from the ElysiumDatabase.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetExtensions"></a>
<td><code>GetExtensions&lt;T&gt;</code></td>
<td>

```csharp
public T[] GetExtensions<T>() where T : class
```

</td>
<td>Retrieves all registered extensions of type <code>T</code> from the ElysiumDatabase.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.TryGetExtensions"></a>
<td><code>TryGetExtensions&lt;T&gt;</code></td>
<td>

```csharp
public bool TryGetExtensions<T>(out T[] extensions) where T : class
```

</td>
<td>Attempts to retrieve all extensions of type <code>T</code>. Returns <code>true</code> if at least one extension exists.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.HasExtension"></a>
<td><code>HasExtension&lt;T&gt;</code></td>
<td>

```csharp
public bool HasExtension<T>() where T : class
```

</td>
<td>Checks whether an extension of type <code>T</code> exists in the ElysiumDatabase.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.AddExtension"></a>
<td><code>AddExtension&lt;T&gt;</code></td>
<td>

```csharp
public T AddExtension<T>() where T : DBExtensionBase, new()
```

</td>
<td>Adds and registers a new extension of type <code>T</code> into the ElysiumDatabase.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.RemoveExtension"></a>
<td><code>RemoveExtension&lt;T&gt;</code></td>
<td>

```csharp
public bool RemoveExtension<T>() where T : DBExtensionBase, new()
```

</td>
<td>Removes an extension of type <code>T</code> from the ElysiumDatabase if it exists.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.DrawDefaultExtension"></a>
<td><code>DrawDefaultExtension</code></td>
<td>

```csharp
public void DrawDefaultExtension(
    Rect position,
    SerializedProperty property)
```

</td>
<td>Draws all visible child serialized properties using Unity’s default IMGUI property rendering.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetChildrenHeight"></a>
<td><code>GetChildrenHeight</code></td>
<td>

```csharp
public float GetChildrenHeight(
    SerializedProperty property)
```

</td>
<td>Calculates the total visual height of all child serialized properties including spacing.</td>
</tr>

<tr>
<td colspan="3"><em>None</em></td>
</tr>
</table>

---

## Enum

<table>
<tr>
<th>Enum</th>
<th>Values</th>
<th>Description</th>
</tr>

<tr>
<td colspan="3"><em>None</em></td>
</tr>
</table>

---

## Nested Classes

<table>
<tr>
<th>Class</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<td colspan="3"><em>None</em></td>
</tr>
</table>

