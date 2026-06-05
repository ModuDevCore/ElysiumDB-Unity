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

* Database connection management
* Extension system support
* SQLite initialization and lifecycle management

---

### Class

```csharp
public class ElysiumDatabase : IDisposable
```

---

Provides the central database manager for ElysiumDB. Handles database connections, extension registration, initialization, disposal, file deployment, and access to project settings.

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
<td>Global active database instance (singleton).</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Connections"></a>
<td><code>Connections</code></td>
<td>
```csharp
public Dictionary<string, DBMeta> Connections = new Dictionary<string, DBMeta>();
```
</td>
<td>Collection of active database connections indexed by database path.</td>
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
<td>Returns the ElysiumDB settings asset loaded from Resources.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.IsOffline"></a>
<td><code>IsOffline</code></td>
<td>
```csharp
public static bool IsOffline { get; }
```
</td>
<td>Indicates whether the application currently has internet connectivity.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.PlatformDataPath"></a>
<td><code>PlatformDataPath</code></td>
<td>
```csharp
public static string PlatformDataPath { get; }
```
</td>
<td>Returns the platform-specific writable data directory.</td>
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
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtension"></a>
<td><code>GetExtension</code></td>
<td>
```csharp
public T GetExtension<T>() where T : class
```
</td>
<td>Returns the first registered extension of the specified type.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensions"></a>
<td><code>GetExtensions</code></td>
<td>
```csharp
public T[] GetExtensions<T>() where T : class
```
</td>
<td>Returns all registered extensions of the specified type.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.HasExtension"></a>
<td><code>HasExtension</code></td>
<td>
```csharp
public bool HasExtension<T>() where T : class
```
</td>
<td>Determines whether an extension of the specified type exists.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.TryGetExtension"></a>
<td><code>TryGetExtension</code></td>
<td>
```csharp
public bool TryGetExtension<T>(out T extension) where T : class
```
</td>
<td>Attempts to retrieve an extension of the specified type.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.AddExtension"></a>
<td><code>AddExtension</code></td>
<td>
```csharp
public T AddExtension<T>() where T : DBExtensionBase, new()
```
</td>
<td>Creates, initializes, and registers a new extension if one does not already exist.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetRequiresExtensions"></a>
<td><code>GetRequiresExtensions</code></td>
<td>
```csharp
public static List<Type> GetRequiresExtensions(Type extensionType)
```
</td>
<td>Returns all extensions that declare a dependency on the specified extension type.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.ProcessRequiredExtensions"></a>
<td><code>ProcessRequiredExtensions</code></td>
<td>
```csharp
public static void ProcessRequiredExtensions()
```
</td>
<td>Validates and automatically creates required extensions based on dependency attributes.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.New"></a>
<td><code>New</code></td>
<td>
```csharp
public void New()
```
</td>
<td>Initializes the database system, loads extensions, and connects configured databases.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.DetachDB"></a>
<td><code>DetachDB</code></td>
<td>
```csharp
public void DetachDB(string path)
```
</td>
<td>Disconnects and removes a database connection.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.ConnectDB"></a>
<td><code>ConnectDB</code></td>
<td>
```csharp
public void ConnectDB(string path)
```
</td>
<td>Copies and opens a database file, then registers the connection.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.OpenSettings"></a>
<td><code>OpenSettings</code></td>
<td>
```csharp
public static void OpenSettings()
```
</td>
<td>Opens the ElysiumDB settings asset in the Unity Editor.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Dispose"></a>
<td><code>Dispose</code></td>
<td>
```csharp
public void Dispose()
```
</td>
<td>Releases all database connections and disposes registered extensions.</td>
</tr>
</table>

---

## Enum

**None**

---

## Nested Classes

**None**

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
