# CreateElysiumDatabase

Before working with ElysiumDB, you must create an `ElysiumDatabase` instance and initialize it.

During initialization, ElysiumDB performs the following operations:

- Creates the global `ElysiumDatabase.Instance`.
- Loads configured database connections.
- Initializes registered extensions.
- Executes all initialization processes.
- Makes the database system ready for use.

---

## Basic Initialization

```csharp
using ModuDevCore.ElysiumDB;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Start()
    {
        var elysium = new ElysiumDatabase();
        elysium.New();
    }
}
```

After calling `New()`, the database system is fully initialized and can be accessed through `ElysiumDatabase.Instance`.

---

## Accessing the Global Instance

```csharp
public class Example : MonoBehaviour
{
    private void Start()
    {
        ElysiumDatabase database = ElysiumDatabase.Instance;

        database.CreateSQLiteDatabase("Players.db");
    }
}
```

The global instance is available only after initialization.

---

## Initialization Flow

The simplified initialization process is shown below.

```text
Create ElysiumDatabase
          │
          ▼
       New()
          │
          ▼
Load configured databases
          │
          ▼
Initialize extensions
          │
          ▼
Run initialization processes
          │
          ▼
ElysiumDatabase.Instance is ready
```

---

## When Should Initialization Happen?

It is recommended to initialize ElysiumDB only once during application startup.

Typical places include:

- Bootstrap scene
- GameManager
- Startup MonoBehaviour
- Dependency initialization scene

Avoid creating multiple `ElysiumDatabase` instances unless your project specifically requires it.

---

## What Happens After Initialization?

Once initialization is complete, you can:

- Create additional database connections.
- Execute SQL commands.
- Query data.
- Access extensions.
- Retrieve registered extensions.
- Observe initialization processes.

---

## Notes

- `New()` should be called before accessing `ElysiumDatabase.Instance`.
- The initialization process loads configured databases and extensions.
- After initialization, additional databases may still be created at runtime.
- Most examples in the documentation assume that ElysiumDB has already been initialized.

---

> **See also**
>
> - [DBConnections](./Database/DBConnections.md)
> - [CreateSQLiteDatabase](./DBMeta/CreateSQLiteDatabase.md)
> - [Query Examples](./Database/QueryExamples.md)
> - [Process Management](./Database/ProcessManagement.md)
> - [Create and Use Extensions](./Extensions/CreateAndUseExtensions.md)
> - [ElysiumDatabase](../REFERENCE.md#modudevcoreelysiumdbelysiumdatabase)