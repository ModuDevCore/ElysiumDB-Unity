# CreateSQLiteDatabase

`CreateSQLiteDatabase()` creates a new SQLite database connection and registers it inside **ElysiumDB**. Once connected, the database can be accessed through `ElysiumDatabase.Instance.Connections` or by its name using the indexer.

The method can either create a new database file or connect to an existing one.

---

## Basic Usage

The simplest way is to provide only the database file name.

```csharp
ElysiumDatabase.Instance.CreateSQLiteDatabase("Players.db");
```

The database can then be accessed as:

```csharp
DBMeta database = ElysiumDatabase.Instance["Players.db"];
```

or

```csharp
DBMeta database = ElysiumDatabase.Instance.Connections["Players.db"];
```

---

## Creating Multiple Databases

ElysiumDB supports multiple databases simultaneously.

```csharp
ElysiumDatabase.Instance.CreateSQLiteDatabase("Players.db");
ElysiumDatabase.Instance.CreateSQLiteDatabase("Settings.db");
ElysiumDatabase.Instance.CreateSQLiteDatabase("Logs.db");
```

Access them independently:

```csharp
DBMeta players = ElysiumDatabase.Instance["Players.db"];
DBMeta settings = ElysiumDatabase.Instance["Settings.db"];
DBMeta logs = ElysiumDatabase.Instance["Logs.db"];
```

---

## Using a Custom Database Path

Instead of creating the database inside the default ElysiumDB directory, you can specify a custom path.

```csharp
ElysiumDatabase.Instance.CreateSQLiteDatabase(
    "Players.db",
    Application.persistentDataPath + "/Databases");
```

This creates (or opens) the database in:

```
<Application.persistentDataPath>/Databases/Players.db
```

---

## Using the Returned Connection

The method returns the created `DBMeta` instance, allowing immediate use.

```csharp
DBMeta database = ElysiumDatabase.Instance.CreateSQLiteDatabase("Players.db");

database.Execute(
    @"CREATE TABLE IF NOT EXISTS Player
    (
        Id INTEGER PRIMARY KEY,
        Name TEXT
    )");
```

---

## Storing the Connection

Instead of retrieving the connection later through the indexer, you can store it.

```csharp
private DBMeta database;

private void Start()
{
    database = ElysiumDatabase.Instance.CreateSQLiteDatabase("Players.db");
}
```

This is useful when the same database is accessed frequently.

---

## Checking Existing Connections

If there is a chance that the database is already connected, check before creating it.

```csharp
if (!ElysiumDatabase.Instance.Exists("Players.db"))
{
    ElysiumDatabase.Instance.CreateSQLiteDatabase("Players.db");
}
```

---

## Creating Tables Immediately

A common pattern is creating tables immediately after connecting.

```csharp
DBMeta database =
    ElysiumDatabase.Instance.CreateSQLiteDatabase("Players.db");

database.Execute(@"
CREATE TABLE IF NOT EXISTS Player
(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Money INTEGER NOT NULL DEFAULT 0
)");
```

---

## Notes

- Calling `CreateSQLiteDatabase()` does not automatically create tables.
- Tables should be created manually using SQL or automatically during initialization through extensions.
- Every created connection is registered inside `ElysiumDatabase.Instance.Connections`.
- A connected database can later be detached using `DetachDB()`.

---

> **See also**
>
> - [DBConnections](../Database/DBConnections.md)
> - [Execute](./Execute.md)
> - [Query Examples](../Database/QueryExamples.md)
> - [Process Management](../Database/ProcessManagement.md)
> - [DBMeta](../../REFERENCE.md#modudevcoreelysiumdbdbmeta)
> - [ElysiumDatabase](../../REFERENCE.md#modudevcoreelysiumdbelysiumdatabase)