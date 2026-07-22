# DBConnections Usage
`ElysiumDatabase.Instance.Connections` contains all SQLite databases (`.db`) currently connected to ElysiumDB.

Connections can be established in two ways:

- **Automatically** during initialization using the database paths configured in `ElysiumDBSettings.dbPaths`.
- **At runtime** by creating or connecting databases through code.

Connected databases can later be detached or reattached using `ElysiumDatabase.Instance.DetachDB()` and `ElysiumDatabase.Instance.ConnectDB()`.

Each connected database is represented by a `DBMeta` instance, which provides methods for executing SQL commands and queries.

Below are a few examples demonstrating different ways to access connected databases.

## Access by Name

```csharp
DBMeta database = ElysiumDatabase.Instance["Players.db"];
```

## Access Through the Connections Dictionary

```csharp
DBMeta database = ElysiumDatabase.Instance.Connections["Players.db"];
```

## Iterate Through All Connected Databases

```csharp
foreach (KeyValuePair<string, DBMeta> connection in ElysiumDatabase.Instance.Connections)
{
    Debug.Log($"Database: {connection.Key}");
}
```

## Check Whether a Database Is Connected

```csharp
if (ElysiumDatabase.Instance.Connections.ContainsKey("Players.db"))
{
    Debug.Log("Database is connected.");
}
```

## Using the ElysiumDatabase indexer

```csharp
Debug.Log(ElysiumDatabase.Instance["Players.db"]);
```

> **See also**
>
> - [Creating and Using Extensions](../Extensions/CreateAndUseExtensions.md)
> - [AfterExtensionAttribute](../Extensions/AfterExtensionAttribute.md)
> - [ExtensionProcessOrderAttribute](../Extensions/ExtensionProcessOrderAttribute.md)
> - [ElysiumDatabase.Suspend](../../REFERENCE.md#suspend)
> - [ElysiumDatabase.Resume](../../REFERENCE.md#resume)
> - [ElysiumDatabase.OnStageChanged](../../REFERENCE.md#onstagechanged)