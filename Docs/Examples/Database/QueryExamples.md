# Query Examples

This page contains practical examples of the most common query operations available in `DBMeta`.

DBMeta is an environment for Mono.Data.Sqlite.

---

## Query

Returns an `IDataReader` for manual iteration.

```csharp
using IDataReader reader = ElysiumDatabase.Instance["Players.db"]
    .Query("SELECT * FROM Player");

while (reader.Read())
{
    Debug.Log(reader["Name"]);
}
```

---

## QueryFirst<T>()

Returns the first mapped object or `null` if no records were found.

```csharp
Player player = ElysiumDatabase.Instance["Players.db"]
    .QueryFirst<Player>(
        "SELECT * FROM Player WHERE Id = @id",
        parameters: new (string, object)[]
        {
            ("@id", 1)
        });
```

---

## QueryList<T>()

Returns every row mapped to a class.

```csharp
List<Player> players =
    ElysiumDatabase.Instance["Players.db"]
        .QueryList<Player>(
            "SELECT * FROM Player");
```

---

## QueryColumn<T>()

Returns values from the first column.

```csharp
List<string> names =
    ElysiumDatabase.Instance["Players.db"]
        .QueryColumn<string>(
            "SELECT Name FROM Player");
```

---

## QueryValue<T>()

Returns a single value.

```csharp
int count =
    ElysiumDatabase.Instance["Players.db"]
        .QueryValue<int>(
            "SELECT COUNT(*) FROM Player");
```

---

## QueryDictionary<TKey, TValue>()

Returns key/value pairs.

```csharp
Dictionary<int, string> players =
    ElysiumDatabase.Instance["Players.db"]
        .QueryDictionary<int, string>(
            "SELECT Id, Name FROM Player");
```

---

## Query With Parameters

```csharp
List<Player> players =
    ElysiumDatabase.Instance["Players.db"]
        .QueryList<Player>(
            "SELECT * FROM Player WHERE Score >= @score",
            parameters: new (string, object)[]
            {
                ("@score", 100)
            });
```

---

## See also

- [Execute](../DBMeta/Execute.md)
- [DBConnections](./DBConnections.md)
- [CreateSQLiteDatabase](../DBMeta/CreateSQLiteDatabase.md)
- [DBMeta](../../REFERENCE.md#modudevcoreelysiumdbdbmeta)