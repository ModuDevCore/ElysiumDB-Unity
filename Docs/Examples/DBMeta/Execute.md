# Execute

`Execute()` executes an SQL command that does not return a result set.

It is commonly used for:

- Creating tables
- Inserting data
- Updating records
- Deleting records
- Creating indexes
- Executing PRAGMA statements
- Any other SQL command that does not require reading rows

---

## Creating a Table

```csharp
ElysiumDatabase.Instance["Players.db"].Execute(@"
CREATE TABLE IF NOT EXISTS Player
(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Money INTEGER NOT NULL DEFAULT 0
)");
```

---

## Insert Data

```csharp
ElysiumDatabase.Instance["Players.db"].Execute(
    "INSERT INTO Player(Name, Money) VALUES(@name, @money)",
    parameters: new (string name, object value)[]
    {
        ("@name", "Alex"),
        ("@money", 1000)
    });
```

---

## Update Data

```csharp
ElysiumDatabase.Instance["Players.db"].Execute(
    @"UPDATE Player
      SET Money = @money
      WHERE Id = @id",
    parameters: new (string name, object value)[]
    {
        ("@money", 5000),
        ("@id", 1)
    });
```

---

## Delete Data

```csharp
ElysiumDatabase.Instance["Players.db"].Execute(
    "DELETE FROM Player WHERE Id = @id",
    parameters: new (string name, object value)[]
    {
        ("@id", 1)
    });
```

---

## Multiple Parameters

There is no limit to the number of SQL parameters.

```csharp
ElysiumDatabase.Instance["Players.db"].Execute(
    @"INSERT INTO Player
      (Name, Money, Score)
      VALUES
      (@name, @money, @score)",
    parameters: new (string name, object value)[]
    {
        ("@name", "John"),
        ("@money", 250),
        ("@score", 1200)
    });
```

---

## Without Parameters

For constant SQL statements, parameters are optional.

```csharp
ElysiumDatabase.Instance["Players.db"].Execute(
    "DELETE FROM Player");
```

---

## Creating an Index

```csharp
ElysiumDatabase.Instance["Players.db"].Execute(
    @"CREATE INDEX IF NOT EXISTS
      idx_player_name
      ON Player(Name)");
```

---

## Executing PRAGMA Commands

SQLite PRAGMA statements can also be executed.

```csharp
ElysiumDatabase.Instance["Players.db"].Execute(
    "PRAGMA foreign_keys = ON;");
```

---

## Notes

- `Execute()` should be used only for SQL commands that do **not** return rows.
- To retrieve data, use one of the query methods such as `Query()`, `QueryList<T>()`, `QueryColumn<T>()`, or `QueryValue<T>()`.
- Parameterized queries are recommended to improve readability and avoid SQL injection.

---

> **See also**
>
> - [CreateSQLiteDatabase](../DBMeta/CreateSQLiteDatabase.md)
> - [Query Examples](../Database/QueryExamples.md)
> - [DBConnections](../Database/DBConnections.md)
> - [DBMeta](../../REFERENCE.md#modudevcoreelysiumdbdbmeta)