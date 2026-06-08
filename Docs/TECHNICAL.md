<a id="ModuDevCore.ElysiumDB.ElysiumDatabase"></a>

## ModuDevCore.ElysiumDB.ElysiumDatabase

### Opportunities

* Modular extension-driven database lifecycle system
* Centralized SQLite connection management for Unity runtime
* Hot-pluggable extension pipeline with ordered execution
* Cross-platform persistent data path abstraction

---

### Class

```csharp
public class ElysiumDatabase : IDisposable
```

Provides a centralized database runtime manager for Unity, handling SQLite connections, extension lifecycle execution, platform-aware file handling, and editor integration for configuration and settings management.

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
<td>Global singleton instance of the database runtime context.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Connections"></a>
<td><code>Connections</code></td>
<td>

```csharp
public Dictionary<string, DBMeta> Connections = new Dictionary<string, DBMeta>();
```

</td>
<td>Active database connections indexed by database path key.</td>
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
<td>Loads global ElysiumDB configuration from Unity Resources.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.IsOffline"></a>
<td><code>IsOffline</code></td>
<td>

```csharp
public static bool IsOffline { get; }
```

</td>
<td>Indicates whether the application is currently offline (no network reachability).</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.PlatformDataPath"></a>
<td><code>PlatformDataPath</code></td>
<td>

```csharp
public static string PlatformDataPath { get; }
```

</td>
<td>Platform-specific persistent storage path (Android vs other platforms).</td>
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
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.New"></a>
<td><code>New</code></td>
<td>

```csharp
public void New()
```

</td>
<td>Initializes the database runtime, clears existing connections, runs extension initialization, and connects all configured databases.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.DetachDB"></a>
<td><code>DetachDB</code></td>
<td>

```csharp
public void DetachDB(string path)
```

</td>
<td>Disposes and removes a database connection by path key.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.ConnectDB"></a>
<td><code>ConnectDB</code></td>
<td>

```csharp
public void ConnectDB(string path)
```

</td>
<td>Creates or loads a SQLite database connection from StreamingAssets into persistent storage and opens it.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.Dispose"></a>
<td><code>Dispose</code></td>
<td>

```csharp
public void Dispose()
```

</td>
<td>Disposes all active database connections, runs extension cleanup, and clears singleton instance.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.OpenSettings"></a>
<td><code>OpenSettings</code></td>
<td>

```csharp
public static void OpenSettings()
```

</td>
<td>Opens the ElysiumDB settings asset in Unity editor property window.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.RunExtensionsProcess"></a>
<td><code>RunExtensionsProcess</code></td>
<td>

```csharp
void RunExtensionsProcess(ExtensionEvent processEvent)
```

</td>
<td>Executes all registered extensions in ordered sequence based on initialization or disposal event lifecycle rules.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.SafeProcess"></a>
<td><code>SafeProcess</code></td>
<td>

```csharp
private void SafeProcess(DBExtensionBase extension, ExtensionEvent evt)
```

</td>
<td>Safely executes extension lifecycle method with exception handling and error logging.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtension"></a>
<td><code>GetExtension</code></td>
<td>

```csharp
public static T GetExtension<T>() where T : class
```

</td>
<td>Returns the first matching extension of the specified type.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetExtensions"></a>
<td><code>GetExtensions</code></td>
<td>

```csharp
public static T[] GetExtensions<T>() where T : class
```

</td>
<td>Returns all extensions matching the specified type.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.HasExtension"></a>
<td><code>HasExtension</code></td>
<td>

```csharp
public static bool HasExtension<T>() where T : class
```

</td>
<td>Checks whether at least one extension of the specified type exists.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.TryGetExtension"></a>
<td><code>TryGetExtension</code></td>
<td>

```csharp
public static bool TryGetExtension<T>(out T extension) where T : class
```

</td>
<td>Attempts to retrieve an extension of the specified type.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.AddExtension"></a>
<td><code>AddExtension</code></td>
<td>

```csharp
public static T AddExtension<T>() where T : DBExtensionBase, new()
```

</td>
<td>Creates and registers a new extension instance and initializes it if runtime instance exists.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.RemoveExtension"></a>
<td><code>RemoveExtension</code></td>
<td>

```csharp
public static bool RemoveExtension<T>() where T : DBExtensionBase
```

</td>
<td>Removes and disposes an extension of the specified type.</td>
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
<td>Returns all extensions assignable from the specified runtime type.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.HasExtension_Type"></a>
<td><code>HasExtension(Type)</code></td>
<td>

```csharp
public static bool HasExtension(Type type)
```

</td>
<td>Checks if any extension of the given runtime type exists.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.TryGetExtension_Type"></a>
<td><code>TryGetExtension(Type)</code></td>
<td>

```csharp
public static bool TryGetExtension(Type type, out object extension)
```

</td>
<td>Attempts to retrieve an extension by runtime type.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.AddExtension_Type"></a>
<td><code>AddExtension(Type)</code></td>
<td>

```csharp
public static object AddExtension(Type type)
```

</td>
<td>Creates and registers a new extension instance via reflection and initializes it.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.RemoveExtension_Type"></a>
<td><code>RemoveExtension(Type)</code></td>
<td>

```csharp
public static bool RemoveExtension(Type type)
```

</td>
<td>Removes and disposes an extension by runtime type.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.GetRequiresExtensions"></a>
<td><code>GetRequiresExtensions</code></td>
<td>

```csharp
public static List<Type> GetRequiresExtensions(Type extensionType)
```

</td>
<td>Returns a list of extension types that depend on the specified extension type via attributes.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.ElysiumDatabase.ProcessRequiredExtensions"></a>
<td><code>ProcessRequiredExtensions</code></td>
<td>

```csharp
public static void ProcessRequiredExtensions()
```

</td>
<td>Validates and auto-creates required extensions based on dependency attributes.</td>
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
<td colspan="3">None</td>
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
<td colspan="3">None</td>
</tr>
</table>

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

<tr>
<a id="ModuDevCore.ElysiumDB.DBMeta.ShouldIgnoreLog"></a>
<td><code>ShouldIgnoreLog</code></td>
<td>

```csharp
private bool ShouldIgnoreLog(string log)
```

</td>
<td>Determines whether a query log entry should be filtered from output.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

---

<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor"></a>
## ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor

### Opportunities

* ElysiumDB settings editor
* Database connection monitoring
* Extension management interface

---

### Class

```csharp
[CustomEditor(typeof(ElysiumDBSettings))]
public class ElysiumDBSettingsEditor : UnityEditor.Editor
```

---

Provides a custom Unity Inspector for ElysiumDB settings. Allows management of database paths, log filters, extensions, runtime database connections, and environment diagnostics.

---

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.listLogsFilter"></a>
<td><code>listLogsFilter</code></td>
<td>

```csharp
public CustomList listLogsFilter;
```

</td>
<td>Custom list used to manage log filter patterns.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.listOfPathDB"></a>
<td><code>listOfPathDB</code></td>
<td>

```csharp
public CustomList listOfPathDB;
```

</td>
<td>Custom list used to manage configured database paths.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.elysiumDBSettings"></a>
<td><code>elysiumDBSettings</code></td>
<td>

```csharp
private ElysiumDBSettings elysiumDBSettings;
```

</td>
<td>Cached reference to the currently edited settings asset.</td>
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
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.OnInspectorGUI"></a>
<td><code>OnInspectorGUI</code></td>
<td>

```csharp
public override void OnInspectorGUI()
```

</td>
<td>Draws the complete custom inspector interface for ElysiumDB settings.</td>
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
    string falseText = "FALSE")
```

</td>
<td>Draws a status indicator row and returns whether it was clicked.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawElysiumDBInfo"></a>
<td><code>DrawElysiumDBInfo</code></td>
<td>

```csharp
void DrawElysiumDBInfo()
```

</td>
<td>Draws runtime information, database states, and connection controls.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.DrawExtensions"></a>
<td><code>DrawExtensions</code></td>
<td>

```csharp
void DrawExtensions()
```

</td>
<td>Draws the extension management section.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.ShowOpenMenu"></a>
<td><code>ShowOpenMenu</code></td>
<td>

```csharp
void ShowOpenMenu(string sourcePath, string runtimePath)
```

</td>
<td>Displays a context menu for opening source and runtime database files.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Core.Settings.Editor.ElysiumDBSettingsEditor.OpenFile"></a>
<td><code>OpenFile</code></td>
<td>

```csharp
void OpenFile(string path)
```

</td>
<td>Opens a file using the operating system default application.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

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

None

---

## Nested Classes

None

---

<a id="ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute"></a>

## ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute

### Opportunities

* Declarative default grouping for database extensions
* Metadata-driven extension organization
* Reduces boilerplate group assignment in runtime logic

---

### Class

```csharp id="6v8m3q"
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public sealed class DefaultExtensionGroupAttribute : Attribute
```

Attribute used to define a default extension group for `DBExtensionBase` implementations.
It allows extensions to be automatically assigned to a logical group during registration.

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

```csharp id="c9q7kp"
public string ExtensionGroup;
```

</td>
<td>Name of the default extension group applied to the target extension class.</td>
</tr>

</table>

---

## Properties

<table>
<tr>
<td colspan="3">None</td>
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
<a id="ModuDevCore.ElysiumDB.DefaultExtensionGroupAttribute.ctor"></a>
<td><code>Constructor</code></td>
<td>

```csharp id="m2t7wq"
public DefaultExtensionGroupAttribute(string extensionGroup)
```

</td>
<td>Initializes the attribute with the specified extension group name.</td>
</tr>

</table>

---

## Enum

<table>
<tr>
<td colspan="3">None</td>
</tr>
</table>

---

## Nested Classes

<table>
<tr>
<td colspan="3">None</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute"></a>
## ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute
### Opportunities
* Provides clean and explicit control over the initialization and disposal order of ElysiumDB extensions
* Supports logical grouping of extensions (e.g. all Supabase-related extensions in one group)
* Ensures deterministic execution order for `Process(ExtensionEvent.Initialize)` and reverse order for `Dispose`
* Works seamlessly with `RequireExtensionAttribute`
* Maintains stable ordering when multiple extensions share the same `Group` and `Order`

---
### Class
```csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class ExtensionProcessOrderAttribute : Attribute
```
---
Attribute that defines the group and execution order for `DBExtensionBase` extensions in the ElysiumDB system.
---
## Fields
None
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
<td>The name of the group used for sorting extensions. Extensions within the same group are sorted by their `Order` value.</td>
</tr>
<tr>
<a id="ModuDevCore.ElysiumDB.ExtensionProcessOrderAttribute.Order"></a>
<td><code>Order</code></td>
<td>
```csharp
public int Order { get; }
```
</td>
<td>Execution order within the group. Lower values are executed first during initialization.</td>
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
<td>Attribute constructor.<br>If `group` is `null`, the group `"Default"` will be used.</td>
</tr>
</table>
---
## Enum
None
---
## Nested Classes
None
---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor

### Opportunities

* Automatic ElysiumDB setup
* Asset validation and repair
* Extension dependency synchronization

---

### Class

```csharp
public class DBPostprocessor : AssetPostprocessor
```

---

Handles Unity asset import events for ElysiumDB. Ensures required folders and settings assets exist, validates extension dependencies, repairs duplicate extension identifiers, and maintains project consistency.

---

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.RootFolder"></a>
<td><code>RootFolder</code></td>
<td>

```csharp
private const string RootFolder = "Assets/ElysiumDB";
```

</td>
<td>Root directory used by ElysiumDB assets.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.ResourcesFolder"></a>
<td><code>ResourcesFolder</code></td>
<td>

```csharp
private const string ResourcesFolder = "Assets/ElysiumDB/Resources";
```

</td>
<td>Resources directory containing ElysiumDB assets.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.AssetPath"></a>
<td><code>AssetPath</code></td>
<td>

```csharp
private const string AssetPath = "Assets/ElysiumDB/Resources/ElysiumDB Settings.asset";
```

</td>
<td>Expected location of the ElysiumDB settings asset.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor._isProcessing"></a>
<td><code>_isProcessing</code></td>
<td>

```csharp
private static bool _isProcessing;
```

</td>
<td>Prevents recursive asset processing.</td>
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
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.SafetyFixExtensions"></a>
<td><code>SafetyFixExtensions</code></td>
<td>

```csharp
public static void SafetyFixExtensions()
```

</td>
<td>Processes required extensions and repairs invalid or duplicate extension identifiers.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.OnPostprocessAllAssets"></a>
<td><code>OnPostprocessAllAssets</code></td>
<td>

```csharp
static void OnPostprocessAllAssets(
    string[] imported,
    string[] deleted,
    string[] moved,
    string[] movedFrom)
```

</td>
<td>Handles Unity asset changes and triggers ElysiumDB validation when relevant assets are modified.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.IsRelevant"></a>
<td><code>IsRelevant</code></td>
<td>

```csharp
private static bool IsRelevant(
    string[] imported,
    string[] deleted,
    string[] moved)
```

</td>
<td>Determines whether asset changes affect ElysiumDB resources.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.SafetyFix"></a>
<td><code>SafetyFix</code></td>
<td>

```csharp
static void SafetyFix()
```

</td>
<td>Ensures required assets and folders exist and repairs settings asset placement.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.EnsureFolders"></a>
<td><code>EnsureFolders</code></td>
<td>

```csharp
static void EnsureFolders()
```

</td>
<td>Creates required ElysiumDB project folders if they are missing.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBPostprocessor.FindSettings"></a>
<td><code>FindSettings</code></td>
<td>

```csharp
static ElysiumDBSettings FindSettings(out string path)
```

</td>
<td>Searches the project for an existing ElysiumDB settings asset.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList

### Opportunities

* Serialized string list editor
* Keyboard navigation support
* Dynamic text field management

---

### Class

```csharp
public class CustomList
```

---

Provides a custom Unity Editor list control for editing serialized string arrays. Supports automatic item creation, deletion, focus management, keyboard navigation, and reusable text field instances.

---

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList._focusIndex"></a>
<td><code>_focusIndex</code></td>
<td>

```csharp
private int _focusIndex = -1;
```

</td>
<td>Index of the element that should receive focus.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList._focusRequested"></a>
<td><code>_focusRequested</code></td>
<td>

```csharp
private bool _focusRequested;
```

</td>
<td>Indicates whether focus should be applied during the next repaint event.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList._selectRequested"></a>
<td><code>_selectRequested</code></td>
<td>

```csharp
private bool _selectRequested;
```

</td>
<td>Indicates whether text selection should be applied after focus.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList._list"></a>
<td><code>_list</code></td>
<td>

```csharp
private SerializedProperty _list;
```

</td>
<td>Serialized array property being edited.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList._serializedObject"></a>
<td><code>_serializedObject</code></td>
<td>

```csharp
private SerializedObject _serializedObject;
```

</td>
<td>Serialized object that owns the edited property.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList._label"></a>
<td><code>_label</code></td>
<td>

```csharp
private string _label;
```

</td>
<td>Display label of the list.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList._placeholder"></a>
<td><code>_placeholder</code></td>
<td>

```csharp
private string _placeholder;
```

</td>
<td>Placeholder text displayed in newly created input fields.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList.tfps"></a>
<td><code>tfps</code></td>
<td>

```csharp
private Dictionary<string, IMGUITextFieldPro> tfps = new();
```

</td>
<td>Collection of reusable text field instances.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList._usedThisFrame"></a>
<td><code>_usedThisFrame</code></td>
<td>

```csharp
private HashSet<string> _usedThisFrame = new();
```

</td>
<td>Tracks text fields used during the current GUI frame.</td>
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
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList.CustomList"></a>
<td><code>CustomList</code></td>
<td>

```csharp
public CustomList(
    SerializedProperty list,
    string label,
    SerializedObject serializedObject,
    string placeholder = "")
```

</td>
<td>Creates a new custom list editor for a serialized string array.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList.Draw"></a>
<td><code>Draw</code></td>
<td>

```csharp
public void Draw()
```

</td>
<td>Draws the complete editable list interface and processes user interaction.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList.DrawTextField"></a>
<td><code>DrawTextField</code></td>
<td>

```csharp
IMGUITextFieldPro DrawTextField(
    string name,
    string content,
    string placeholder = "")
```

</td>
<td>Creates or reuses a text field instance and renders it.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.List.CustomList.CleanupUnused"></a>
<td><code>CleanupUnused</code></td>
<td>

```csharp
void CleanupUnused()
```

</td>
<td>Removes cached text fields that were not used during the current frame.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer

### Opportunities

* Custom extension property rendering
* Array element visualization
* Dynamic property height calculation

---

### Class

```csharp
[CustomPropertyDrawer(typeof(DBExtensionBase), true)]
public class DBExtensionBaseDrawer : PropertyDrawer
```

---

Provides a custom property drawer for classes derived from `DBExtensionBase`. When extensions are displayed inside serialized collections, the drawer renders only child properties without the default object header.

---

## Fields

None

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
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer.OnGUI"></a>
<td><code>OnGUI</code></td>
<td>

```csharp
public override void OnGUI(
    Rect position,
    SerializedProperty property,
    GUIContent label)
```

</td>
<td>Draws the property in the Inspector and switches between standard rendering and headerless child rendering depending on whether the property is part of a collection.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer.GetPropertyHeight"></a>
<td><code>GetPropertyHeight</code></td>
<td>

```csharp
public override float GetPropertyHeight(
    SerializedProperty property,
    GUIContent label)
```

</td>
<td>Calculates the required height for rendering the property.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer.DrawChildrenWithoutHeader"></a>
<td><code>DrawChildrenWithoutHeader</code></td>
<td>

```csharp
private void DrawChildrenWithoutHeader(
    Rect position,
    SerializedProperty property)
```

</td>
<td>Draws all visible child properties without displaying the root property header.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionBaseDrawer.GetChildrenHeight"></a>
<td><code>GetChildrenHeight</code></td>
<td>

```csharp
private float GetChildrenHeight(
    SerializedProperty property)
```

</td>
<td>Calculates the combined height of all visible child properties.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.IInspectorElement"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.IInspectorElement

### Opportunities

* Inspector hierarchy abstraction
* Group and extension identification
* Inspector tree element contract

---

### Class

```csharp
public interface IInspectorElement
```

---

Defines a common contract for all elements displayed in the ElysiumDB extension inspector hierarchy.

---

## Fields

None

---

## Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.IInspectorElement.IsGroup"></a>
<td><code>IsGroup</code></td>
<td>

```csharp
bool IsGroup { get; }
```

</td>
<td>Indicates whether the element represents a group.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.IInspectorElement.IsExtension"></a>
<td><code>IsExtension</code></td>
<td>

```csharp
bool IsExtension { get; }
```

</td>
<td>Indicates whether the element represents an extension.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.IInspectorElement.Index"></a>
<td><code>Index</code></td>
<td>

```csharp
int Index { get; set; }
```

</td>
<td>Original index of the element inside the serialized collection.</td>
</tr>

</table>

---

## Methods

None

---

## Enum

None

---

## Nested Classes

None

---

# ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup

### Opportunities

* Extension grouping
* Nested group hierarchy
* Group migration support

---

### Class

```csharp
public class PropertyGroup : IInspectorElement
```

---

Represents a hierarchical group that can contain extensions and nested groups.

---

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.Elements"></a>
<td><code>Elements</code></td>
<td>

```csharp
public List<IInspectorElement> Elements = new List<IInspectorElement>();
```

</td>
<td>Child elements belonging to the group.</td>
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
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.GroupName"></a>
<td><code>GroupName</code></td>
<td>

```csharp
public string GroupName { get; set; }
```

</td>
<td>Name of the group.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.IsGroup"></a>
<td><code>IsGroup</code></td>
<td>

```csharp
public bool IsGroup { get; }
```

</td>
<td>Always returns true.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.IsExtension"></a>
<td><code>IsExtension</code></td>
<td>

```csharp
public bool IsExtension { get; }
```

</td>
<td>Always returns false.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.Index"></a>
<td><code>Index</code></td>
<td>

```csharp
public int Index { get; set; }
```

</td>
<td>Serialized collection index.</td>
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
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.DeleteGroup"></a>
<td><code>DeleteGroup</code></td>
<td>

```csharp
public void DeleteGroup()
```

</td>
<td>Removes the current group level from all contained extensions.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.MigrateToNewGroupName"></a>
<td><code>MigrateToNewGroupName</code></td>
<td>

```csharp
public void MigrateToNewGroupName(string newName)
```

</td>
<td>Renames the group and updates all contained extension paths.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

---

# ModuDevCore.ElysiumDB.Editor.Internal.PropertyExtension

### Opportunities

* Serialized extension wrapper
* Inspector tree element
* Extension metadata container

---

### Class

```csharp
public class PropertyExtension : IInspectorElement
```

---

Represents an extension entry inside the inspector hierarchy.

---

## Fields

None

---

## Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyExtension.IsGroup"></a>
<td><code>IsGroup</code></td>
<td>

```csharp
public bool IsGroup { get; }
```

</td>
<td>Always returns false.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyExtension.IsExtension"></a>
<td><code>IsExtension</code></td>
<td>

```csharp
public bool IsExtension { get; }
```

</td>
<td>Always returns true.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyExtension.Index"></a>
<td><code>Index</code></td>
<td>

```csharp
public int Index { get; set; }
```

</td>
<td>Serialized collection index.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyExtension.SerializedProperty"></a>
<td><code>SerializedProperty</code></td>
<td>

```csharp
public SerializedProperty SerializedProperty { get; set; }
```

</td>
<td>Serialized extension property.</td>
</tr>

</table>

---

## Methods

None

---

## Enum

None

---

## Nested Classes

None

---

# ModuDevCore.ElysiumDB.Editor.Internal.SerializedPropertyExtensions

### Opportunities

* SerializedProperty utilities
* Array element lookup
* Editor helper extensions

---

### Class

```csharp
public static class SerializedPropertyExtensions
```

---

Provides utility extension methods for working with SerializedProperty arrays.

---

## Fields

None

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
<a id="ModuDevCore.ElysiumDB.Editor.Internal.SerializedPropertyExtensions.IndexOf"></a>
<td><code>IndexOf</code></td>
<td>

```csharp
public static int IndexOf(
    this SerializedProperty arrayProperty,
    SerializedProperty elementToFind)
```

</td>
<td>Returns the index of a serialized element inside an array property.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

---

# ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer

### Opportunities

* Extension inspector rendering
* Hierarchical group management
* Dynamic extension creation

---

### Class

```csharp
public static class DBExtensionDrawer
```

---

Provides drawing, grouping, management, and interaction logic for ElysiumDB extensions within the Unity Inspector.

---

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.inspectorElements"></a>
<td><code>inspectorElements</code></td>
<td>

```csharp
public static List<IInspectorElement> inspectorElements = new List<IInspectorElement>();
```

</td>
<td>Current inspector hierarchy representation.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer._expandedStates"></a>
<td><code>_expandedStates</code></td>
<td>

```csharp
private static readonly Dictionary<string, bool> _expandedStates;
```

</td>
<td>Stores foldout expansion states.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer._iconCache"></a>
<td><code>_iconCache</code></td>
<td>

```csharp
private static readonly Dictionary<Type, Texture2D> _iconCache;
```

</td>
<td>Caches icons associated with extension types.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer._defaultScriptIcon"></a>
<td><code>_defaultScriptIcon</code></td>
<td>

```csharp
private static Texture2D _defaultScriptIcon;
```

</td>
<td>Fallback script icon.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer._scriptGuidCache"></a>
<td><code>_scriptGuidCache</code></td>
<td>

```csharp
private static readonly Dictionary<Type, string> _scriptGuidCache;
```

</td>
<td>Caches script GUIDs for extension types.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.tfps"></a>
<td><code>tfps</code></td>
<td>

```csharp
private static Dictionary<string, IMGUITextFieldPro> tfps = new();
```

</td>
<td>Cached text field controls.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer._usedThisFrame"></a>
<td><code>_usedThisFrame</code></td>
<td>

```csharp
private static HashSet<string> _usedThisFrame = new();
```

</td>
<td>Tracks active controls during GUI rendering.</td>
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
<td><code>TryGetGroup</code></td>
<td>

```csharp
public static bool TryGetGroup(
    string groupName,
    out IInspectorElement group)
```

</td>
<td>Searches for a group by name.</td>
</tr>

<tr>
<td><code>ValidateGroups</code></td>
<td>

```csharp
public static void ValidateGroups(
    SerializedProperty property)
```

</td>
<td>Builds the inspector hierarchy from serialized extension data.</td>
</tr>

<tr>
<td><code>GenerateNewGroupName</code></td>
<td>

```csharp
public static string GenerateNewGroupName(
    IEnumerable<IInspectorElement> elements)
```

</td>
<td>Generates a unique group name.</td>
</tr>

<tr>
<td><code>DrawExtensionsList</code></td>
<td>

```csharp
public static void DrawExtensionsList(
    SerializedProperty property,
    Type baseType)
```

</td>
<td>Draws the complete extensions inspector.</td>
</tr>

<tr>
<td><code>ShowContextMenuGroup</code></td>
<td>

```csharp
public static void ShowContextMenuGroup(
    SerializedProperty property,
    int currentIndex,
    int inspectorElementsIndex,
    List<IInspectorElement> elements,
    PropertyGroup propertyGroup)
```

</td>
<td>Displays the context menu for groups.</td>
</tr>

<tr>
<td><code>ShowContextMenuExtension</code></td>
<td>

```csharp
public static void ShowContextMenuExtension(
    SerializedProperty property,
    int currentIndex,
    SerializedProperty groupProp,
    Type targetType,
    int inspectorElementsIndex,
    List<IInspectorElement> elements)
```

</td>
<td>Displays the context menu for extensions.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

---

# ModuDevCore.ElysiumDB.Editor.Internal.GroupPathDropdown

### Opportunities

* Hierarchical group selection
* Advanced dropdown navigation
* Group assignment interface

---

### Class

```csharp
public class GroupPathDropdown : AdvancedDropdown
```

---

Provides a tree-based dropdown menu for assigning extensions to groups.

---

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GroupPathDropdown._groupProp"></a>
<td><code>_groupProp</code></td>
<td>

```csharp
private readonly SerializedProperty _groupProp;
```

</td>
<td>Serialized group path property.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GroupPathDropdown._property"></a>
<td><code>_property</code></td>
<td>

```csharp
private readonly SerializedProperty _property;
```

</td>
<td>Owning serialized property.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GroupPathDropdown._allGroups"></a>
<td><code>_allGroups</code></td>
<td>

```csharp
private readonly List<(string path, PropertyGroup group)> _allGroups;
```

</td>
<td>Available groups.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GroupPathDropdown._idToPath"></a>
<td><code>_idToPath</code></td>
<td>

```csharp
private readonly Dictionary<int, string> _idToPath = new Dictionary<int, string>();
```

</td>
<td>Maps dropdown identifiers to group paths.</td>
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
<td><code>GroupPathDropdown</code></td>
<td>

```csharp
public GroupPathDropdown(
    AdvancedDropdownState state,
    SerializedProperty property,
    SerializedProperty groupProp,
    List<(string path, PropertyGroup group)> allGroups)
```

</td>
<td>Creates a new group path dropdown.</td>
</tr>

<tr>
<td><code>BuildRoot</code></td>
<td>

```csharp
protected override AdvancedDropdownItem BuildRoot()
```

</td>
<td>Builds the dropdown hierarchy.</td>
</tr>

<tr>
<td><code>AddPathToTree</code></td>
<td>

```csharp
private void AddPathToTree(
    AdvancedDropdownItem current,
    string fullPath,
    ref int idCounter)
```

</td>
<td>Creates tree nodes from a group path.</td>
</tr>

<tr>
<td><code>ItemSelected</code></td>
<td>

```csharp
protected override void ItemSelected(
    AdvancedDropdownItem item)
```

</td>
<td>Handles dropdown selection and updates the target group.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.IInspectorElement"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.IInspectorElement

### Opportunities

* Inspector hierarchy abstraction
* Group and extension identification
* Inspector tree element contract

---

### Class

```csharp
public interface IInspectorElement
```

---

Defines a common contract for all elements displayed in the ElysiumDB extension inspector hierarchy.

---

## Fields

None

---

## Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.IInspectorElement.IsGroup"></a>
<td><code>IsGroup</code></td>
<td>

```csharp
bool IsGroup { get; }
```

</td>
<td>Indicates whether the element represents a group.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.IInspectorElement.IsExtension"></a>
<td><code>IsExtension</code></td>
<td>

```csharp
bool IsExtension { get; }
```

</td>
<td>Indicates whether the element represents an extension.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.IInspectorElement.Index"></a>
<td><code>Index</code></td>
<td>

```csharp
int Index { get; set; }
```

</td>
<td>Original index of the element inside the serialized collection.</td>
</tr>

</table>

---

## Methods

None

---

## Enum

None

---

## Nested Classes

None

---

# ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup

### Opportunities

* Extension grouping
* Nested group hierarchy
* Group migration support

---

### Class

```csharp
public class PropertyGroup : IInspectorElement
```

---

Represents a hierarchical group that can contain extensions and nested groups.

---

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.Elements"></a>
<td><code>Elements</code></td>
<td>

```csharp
public List<IInspectorElement> Elements = new List<IInspectorElement>();
```

</td>
<td>Child elements belonging to the group.</td>
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
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.GroupName"></a>
<td><code>GroupName</code></td>
<td>

```csharp
public string GroupName { get; set; }
```

</td>
<td>Name of the group.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.IsGroup"></a>
<td><code>IsGroup</code></td>
<td>

```csharp
public bool IsGroup { get; }
```

</td>
<td>Always returns true.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.IsExtension"></a>
<td><code>IsExtension</code></td>
<td>

```csharp
public bool IsExtension { get; }
```

</td>
<td>Always returns false.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.Index"></a>
<td><code>Index</code></td>
<td>

```csharp
public int Index { get; set; }
```

</td>
<td>Serialized collection index.</td>
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
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.DeleteGroup"></a>
<td><code>DeleteGroup</code></td>
<td>

```csharp
public void DeleteGroup()
```

</td>
<td>Removes the current group level from all contained extensions.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyGroup.MigrateToNewGroupName"></a>
<td><code>MigrateToNewGroupName</code></td>
<td>

```csharp
public void MigrateToNewGroupName(string newName)
```

</td>
<td>Renames the group and updates all contained extension paths.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

---

# ModuDevCore.ElysiumDB.Editor.Internal.PropertyExtension

### Opportunities

* Serialized extension wrapper
* Inspector tree element
* Extension metadata container

---

### Class

```csharp
public class PropertyExtension : IInspectorElement
```

---

Represents an extension entry inside the inspector hierarchy.

---

## Fields

None

---

## Properties

<table>
<tr>
<th>Property</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyExtension.IsGroup"></a>
<td><code>IsGroup</code></td>
<td>

```csharp
public bool IsGroup { get; }
```

</td>
<td>Always returns false.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyExtension.IsExtension"></a>
<td><code>IsExtension</code></td>
<td>

```csharp
public bool IsExtension { get; }
```

</td>
<td>Always returns true.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyExtension.Index"></a>
<td><code>Index</code></td>
<td>

```csharp
public int Index { get; set; }
```

</td>
<td>Serialized collection index.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.PropertyExtension.SerializedProperty"></a>
<td><code>SerializedProperty</code></td>
<td>

```csharp
public SerializedProperty SerializedProperty { get; set; }
```

</td>
<td>Serialized extension property.</td>
</tr>

</table>

---

## Methods

None

---

## Enum

None

---

## Nested Classes

None

---

# ModuDevCore.ElysiumDB.Editor.Internal.SerializedPropertyExtensions

### Opportunities

* SerializedProperty utilities
* Array element lookup
* Editor helper extensions

---

### Class

```csharp
public static class SerializedPropertyExtensions
```

---

Provides utility extension methods for working with SerializedProperty arrays.

---

## Fields

None

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
<a id="ModuDevCore.ElysiumDB.Editor.Internal.SerializedPropertyExtensions.IndexOf"></a>
<td><code>IndexOf</code></td>
<td>

```csharp
public static int IndexOf(
    this SerializedProperty arrayProperty,
    SerializedProperty elementToFind)
```

</td>
<td>Returns the index of a serialized element inside an array property.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

---

# ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer

### Opportunities

* Extension inspector rendering
* Hierarchical group management
* Dynamic extension creation

---

### Class

```csharp
public static class DBExtensionDrawer
```

---

Provides drawing, grouping, management, and interaction logic for ElysiumDB extensions within the Unity Inspector.

---

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.inspectorElements"></a>
<td><code>inspectorElements</code></td>
<td>

```csharp
public static List<IInspectorElement> inspectorElements = new List<IInspectorElement>();
```

</td>
<td>Current inspector hierarchy representation.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer._expandedStates"></a>
<td><code>_expandedStates</code></td>
<td>

```csharp
private static readonly Dictionary<string, bool> _expandedStates;
```

</td>
<td>Stores foldout expansion states.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer._iconCache"></a>
<td><code>_iconCache</code></td>
<td>

```csharp
private static readonly Dictionary<Type, Texture2D> _iconCache;
```

</td>
<td>Caches icons associated with extension types.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer._defaultScriptIcon"></a>
<td><code>_defaultScriptIcon</code></td>
<td>

```csharp
private static Texture2D _defaultScriptIcon;
```

</td>
<td>Fallback script icon.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer._scriptGuidCache"></a>
<td><code>_scriptGuidCache</code></td>
<td>

```csharp
private static readonly Dictionary<Type, string> _scriptGuidCache;
```

</td>
<td>Caches script GUIDs for extension types.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer.tfps"></a>
<td><code>tfps</code></td>
<td>

```csharp
private static Dictionary<string, IMGUITextFieldPro> tfps = new();
```

</td>
<td>Cached text field controls.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.DBExtensionDrawer._usedThisFrame"></a>
<td><code>_usedThisFrame</code></td>
<td>

```csharp
private static HashSet<string> _usedThisFrame = new();
```

</td>
<td>Tracks active controls during GUI rendering.</td>
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
<td><code>TryGetGroup</code></td>
<td>

```csharp
public static bool TryGetGroup(
    string groupName,
    out IInspectorElement group)
```

</td>
<td>Searches for a group by name.</td>
</tr>

<tr>
<td><code>ValidateGroups</code></td>
<td>

```csharp
public static void ValidateGroups(
    SerializedProperty property)
```

</td>
<td>Builds the inspector hierarchy from serialized extension data.</td>
</tr>

<tr>
<td><code>GenerateNewGroupName</code></td>
<td>

```csharp
public static string GenerateNewGroupName(
    IEnumerable<IInspectorElement> elements)
```

</td>
<td>Generates a unique group name.</td>
</tr>

<tr>
<td><code>DrawExtensionsList</code></td>
<td>

```csharp
public static void DrawExtensionsList(
    SerializedProperty property,
    Type baseType)
```

</td>
<td>Draws the complete extensions inspector.</td>
</tr>

<tr>
<td><code>ShowContextMenuGroup</code></td>
<td>

```csharp
public static void ShowContextMenuGroup(
    SerializedProperty property,
    int currentIndex,
    int inspectorElementsIndex,
    List<IInspectorElement> elements,
    PropertyGroup propertyGroup)
```

</td>
<td>Displays the context menu for groups.</td>
</tr>

<tr>
<td><code>ShowContextMenuExtension</code></td>
<td>

```csharp
public static void ShowContextMenuExtension(
    SerializedProperty property,
    int currentIndex,
    SerializedProperty groupProp,
    Type targetType,
    int inspectorElementsIndex,
    List<IInspectorElement> elements)
```

</td>
<td>Displays the context menu for extensions.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

---

# ModuDevCore.ElysiumDB.Editor.Internal.GroupPathDropdown

### Opportunities

* Hierarchical group selection
* Advanced dropdown navigation
* Group assignment interface

---

### Class

```csharp
public class GroupPathDropdown : AdvancedDropdown
```

---

Provides a tree-based dropdown menu for assigning extensions to groups.

---

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GroupPathDropdown._groupProp"></a>
<td><code>_groupProp</code></td>
<td>

```csharp
private readonly SerializedProperty _groupProp;
```

</td>
<td>Serialized group path property.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GroupPathDropdown._property"></a>
<td><code>_property</code></td>
<td>

```csharp
private readonly SerializedProperty _property;
```

</td>
<td>Owning serialized property.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GroupPathDropdown._allGroups"></a>
<td><code>_allGroups</code></td>
<td>

```csharp
private readonly List<(string path, PropertyGroup group)> _allGroups;
```

</td>
<td>Available groups.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GroupPathDropdown._idToPath"></a>
<td><code>_idToPath</code></td>
<td>

```csharp
private readonly Dictionary<int, string> _idToPath = new Dictionary<int, string>();
```

</td>
<td>Maps dropdown identifiers to group paths.</td>
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
<td><code>GroupPathDropdown</code></td>
<td>

```csharp
public GroupPathDropdown(
    AdvancedDropdownState state,
    SerializedProperty property,
    SerializedProperty groupProp,
    List<(string path, PropertyGroup group)> allGroups)
```

</td>
<td>Creates a new group path dropdown.</td>
</tr>

<tr>
<td><code>BuildRoot</code></td>
<td>

```csharp
protected override AdvancedDropdownItem BuildRoot()
```

</td>
<td>Builds the dropdown hierarchy.</td>
</tr>

<tr>
<td><code>AddPathToTree</code></td>
<td>

```csharp
private void AddPathToTree(
    AdvancedDropdownItem current,
    string fullPath,
    ref int idCounter)
```

</td>
<td>Creates tree nodes from a group path.</td>
</tr>

<tr>
<td><code>ItemSelected</code></td>
<td>

```csharp
protected override void ItemSelected(
    AdvancedDropdownItem item)
```

</td>
<td>Handles dropdown selection and updates the target group.</td>
</tr>

</table>

---

## Enum

None

---

## Nested Classes

None

---

<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro"></a>
## ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro

### Opportunities

* Custom IMGUI text input field for Unity Editor tooling
* Full text editing system with caret, selection, and keyboard shortcuts
* Lightweight replacement for Unity default text fields with styling control

---

### Class

```csharp
public class IMGUITextFieldPro
```

A custom IMGUI-based text field implementation for Unity Editor that provides advanced text editing features such as caret control, selection, clipboard operations, word navigation, and fully customizable styling.

---

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
<td>Current text content of the field.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.caret"></a>
<td><code>caret</code></td>
<td>

```csharp
public int caret;
```

</td>
<td>Current caret position index.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.select"></a>
<td><code>select</code></td>
<td>

```csharp
public int select;
```

</td>
<td>Selection anchor index for text selection.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.hasFocus"></a>
<td><code>hasFocus</code></td>
<td>

```csharp
public bool hasFocus;
```

</td>
<td>Indicates whether the field currently has input focus.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.placeholder"></a>
<td><code>placeholder</code></td>
<td>

```csharp
public string placeholder;
```

</td>
<td>Placeholder text shown when input is empty and unfocused.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.NormalBackground"></a>
<td><code>NormalBackground</code></td>
<td>

```csharp
public Color NormalBackground;
```

</td>
<td>Background color when the field is not focused.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.FocusedBackground"></a>
<td><code>FocusedBackground</code></td>
<td>

```csharp
public Color FocusedBackground;
```

</td>
<td>Background color when the field is focused.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.FocusAccentColor"></a>
<td><code>FocusAccentColor</code></td>
<td>

```csharp
public Color FocusAccentColor;
```

</td>
<td>Accent color used for focus highlight decoration.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.textStyle"></a>
<td><code>textStyle</code></td>
<td>

```csharp
public GUIStyle textStyle;
```

</td>
<td>GUI style used for rendering text content.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.placeholderStyle"></a>
<td><code>placeholderStyle</code></td>
<td>

```csharp
public GUIStyle placeholderStyle;
```

</td>
<td>GUI style used for rendering placeholder text.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.dragging"></a>
<td><code>dragging</code></td>
<td>

```csharp
public bool dragging;
```

</td>
<td>Indicates whether text selection dragging is active.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.drawBackground"></a>
<td><code>drawBackground</code></td>
<td>

```csharp
public bool drawBackground;
```

</td>
<td>Controls whether the background is rendered.</td>
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
<td colspan="3"><code>None</code></td>
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
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.IMGUITextFieldPro"></a>
<td><code>IMGUITextFieldPro</code></td>
<td>

```csharp
public IMGUITextFieldPro(string name, string initial = "", string placeholderText = "", bool drawBackground = true)
```

</td>
<td>Initializes a new instance of the IMGUI text field with control name, initial text, placeholder, and background option.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.Draw"></a>
<td><code>Draw</code></td>
<td>

```csharp
public void Draw()
```

</td>
<td>Renders the text field using automatic layout rect.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.DrawRect"></a>
<td><code>Draw</code></td>
<td>

```csharp
public void Draw(Rect rect)
```

</td>
<td>Renders the text field inside a specified rectangle.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.Focus"></a>
<td><code>Focus</code></td>
<td>

```csharp
public void Focus()
```

</td>
<td>Forces keyboard focus into the text field.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.SetSelection"></a>
<td><code>SetSelection</code></td>
<td>

```csharp
public void SetSelection(int start, int end)
```

</td>
<td>Sets text selection range between two indices.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.SelectAll"></a>
<td><code>SelectAll</code></td>
<td>

```csharp
public void SelectAll()
```

</td>
<td>Selects all text in the field.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.ClearSelection"></a>
<td><code>ClearSelection</code></td>
<td>

```csharp
public void ClearSelection()
```

</td>
<td>Clears current selection and keeps caret position.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.GetSelectedText"></a>
<td><code>GetSelectedText</code></td>
<td>

```csharp
public string GetSelectedText()
```

</td>
<td>Returns currently selected text if selection exists, otherwise empty string.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.Internal.GUI.Text.IMGUITextFieldPro.HasSelection"></a>
<td><code>HasSelection</code></td>
<td>

```csharp
public bool HasSelection()
```

</td>
<td>Returns whether any text selection is active.</td>
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
<td colspan="3"><code>None</code></td>
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
<td colspan="3"><code>None</code></td>
</tr>
</table>

<a id="ModuDevCore.ElysiumDB.Internal.Data.ExtensionEvent"></a>
## ModuDevCore.ElysiumDB.Internal.Data.ExtensionEvent

### Opportunities

* Define lifecycle events for extension systems
* Provide standardized initialization and disposal hooks
* Enable clean separation of setup and teardown logic

---

## Fields

<table>
<tr>
<th>Field</th>
<th>Declaration</th>
<th>Description</th>
</tr>

<tr>
<td colspan="3">None</td>
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
<td colspan="3">None</td>
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
<td colspan="3">None</td>
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
<a id="ModuDevCore.ElysiumDB.Internal.Data.ExtensionEvent"></a>
<td><code>ExtensionEvent</code></td>
<td>

```csharp
public enum ExtensionEvent
{
    Initialize = 0,
    Dispose = 1
}
```

</td>
<td>Defines lifecycle stages for extension management, including initialization and disposal.</td>
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
<td>None</td>
<td>None</td>
<td>None</td>
</tr>
</table>

---

<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase"></a>

## ModuDevCore.ElysiumDB.Extension.DBExtensionBase

### Opportunities

* Base lifecycle class for modular ElysiumDB extensions
* Unified initialization/disposal pipeline for database features
* Extension-to-extension dependency access layer
* Lightweight debugging and logging abstraction per extension

---

### Class

```csharp
[Serializable]
public abstract class DBExtensionBase
```

Core abstract base class for all ElysiumDB extensions. Provides lifecycle hooks (`Initialize`, `Dispose`), global extension access helpers, and standardized processing through the `ElysiumDatabase` runtime system.

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
public bool enabled = true;
```

</td>
<td>Controls whether the extension participates in the initialization lifecycle.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionGroup"></a>
<td><code>extensionGroup</code></td>
<td>

```csharp
public string extensionGroup = "";
```

</td>
<td>Logical grouping identifier used for ordering and organization of extensions.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionId"></a>
<td><code>extensionId</code></td>
<td>

```csharp
public int extensionId = -1;
```

</td>
<td>Numeric identifier for extension instance tracking or internal grouping.</td>
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
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.extensionName"></a>
<td><code>extensionName</code></td>
<td>

```csharp
public string extensionName { get; }
```

</td>
<td>Returns the runtime type name of the extension.</td>
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
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Process"></a>
<td><code>Process</code></td>
<td>

```csharp
public void Process(ExtensionEvent ev, ElysiumDatabase elysium = null)
```

</td>
<td>Executes extension lifecycle events (Initialize / Dispose) and routes them to virtual hooks.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtension"></a>
<td><code>GetExtension</code></td>
<td>

```csharp
public T GetExtension<T>() where T : class
```

</td>
<td>Retrieves the first matching extension from the global ElysiumDatabase context.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.GetExtensions"></a>
<td><code>GetExtensions</code></td>
<td>

```csharp
public T[] GetExtensions<T>() where T : class
```

</td>
<td>Retrieves all extensions matching the specified type from the global database context.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.TryGetExtensions"></a>
<td><code>TryGetExtensions</code></td>
<td>

```csharp
public bool TryGetExtensions<T>(out T[] extensions) where T : class
```

</td>
<td>Attempts to retrieve extensions of a given type and returns whether any exist.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.HasExtension"></a>
<td><code>HasExtension</code></td>
<td>

```csharp
public bool HasExtension<T>() where T : class
```

</td>
<td>Checks if any extension of the specified type exists in the global database.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.AddExtension"></a>
<td><code>AddExtension</code></td>
<td>

```csharp
public T AddExtension<T>() where T : DBExtensionBase, new()
```

</td>
<td>Creates and registers a new extension instance in the global ElysiumDatabase context.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.RemoveExtension"></a>
<td><code>RemoveExtension</code></td>
<td>

```csharp
public bool RemoveExtension<T>() where T : DBExtensionBase, new()
```

</td>
<td>Removes an extension of the specified type from the global database context.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnInitialize"></a>
<td><code>OnInitialize</code></td>
<td>

```csharp
protected virtual void OnInitialize(ElysiumDatabase elysium)
```

</td>
<td>Override point for extension initialization logic.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.OnDispose"></a>
<td><code>OnDispose</code></td>
<td>

```csharp
protected virtual void OnDispose()
```

</td>
<td>Override point for extension cleanup logic.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Extension.DBExtensionBase.Log"></a>
<td><code>Log</code></td>
<td>

```csharp
public void Log(object message)
```

</td>
<td>Logs a message prefixed with the extension runtime name.</td>
</tr>

</table>

---

## Enum

<table>
<tr>
<td colspan="3">None</td>
</tr>
</table>

---

## Nested Classes

<table>
<tr>
<td colspan="3">None</td>
</tr>
</table>

---

</details>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer"></a>

## ModuDevCore.ElysiumDB.Editor.ExtensionDrawer

### Opportunities

* Provides unified base for Unity `PropertyDrawer`-based extension rendering
* Simplifies working with ElysiumDB extension system inside Unity Editor
* Gives reusable helpers for extension lifecycle management (add/remove/query)
* Enables custom IMGUI rendering for DB extensions
* Provides safe default drawing utilities for serialized properties

---

### Class

```csharp
public abstract class ExtensionDrawer : PropertyDrawer
```

Base abstract drawer used for rendering and managing ElysiumDB extensions inside Unity Editor inspector GUI.

It acts as a bridge between Unity `PropertyDrawer` system and the `ElysiumDatabase` extension API, providing helper methods to query, add, remove, and render extensions consistently.

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
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.Settings"></a>
<td><code>Settings</code></td>
<td>

```csharp
protected ElysiumDBSettings Settings { get; }
```

</td>
<td>Provides access to global ElysiumDB settings from <code>ElysiumDatabase.Settings</code>.</td>
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
<td>Checks whether an extension of type <code>T</code> exists in the database.</td>
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
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.OnGUI"></a>
<td><code>OnGUI</code></td>
<td>

```csharp
protected sealed override void OnGUI(
    Rect position,
    SerializedProperty property,
    GUIContent label)
```

</td>
<td>Unity IMGUI entry point for drawing the property. Wraps drawing with <code>EditorGUI.BeginProperty</code> / <code>EndProperty</code> and delegates rendering to <code>OnExtensionGUI</code>.</td>
</tr>

<tr>
<a id="ModuDevCore.ElysiumDB.Editor.ExtensionDrawer.GetPropertyHeight"></a>
<td><code>GetPropertyHeight</code></td>
<td>

```csharp
protected sealed override float GetPropertyHeight(
    SerializedProperty property,
    GUIContent label)
```

</td>
<td>Returns the height of the property drawer by delegating to <code>GetExtensionHeight</code>.</td>
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
<td>Draws all visible serialized child properties using Unity default IMGUI rendering logic.</td>
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
<td>Calculates total height of all visible serialized child properties including spacing.</td>
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