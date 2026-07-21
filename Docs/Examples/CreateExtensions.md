# Creating a Custom Module/Extension for ElysiumDB

Create two files anywhere in your project folder:

### DBCustomExtension1.cs
```csharp
using UnityEngine;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

public class DBCustomExtension1 : DBExtensionBase
{
    public string initializeText = "Hello world!";

    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Debug.Log(initializeText);
    }

    protected override void OnDispose() { }

    public void PrintHelloFromSecondExtension()
    {
        GetExtension<DBCustomExtension2>().Hello();
    }
}
```

### DBCustomExtension2.cs
```csharp
using UnityEngine;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

public class DBCustomExtension2 : DBExtensionBase
{
    public string hello = "Hello World from second extension!";

    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        
    }

    protected override void OnDispose()
    {
    }

    public void Hello()
    {
        Debug.Log(hello);
    }
}
```

Then open **ElysiumDB → Settings**.

![elysiumdb-inspector](./../Images/elysiumdb-inspector.png)

Click the **Add** button to add a new Extension and select **DBCustomExtension1** and **DBCustomExtension2** from the list.

At the end, you should see two modules in the Extensions list.

![elysiumdb-extensions](./../Images/elysiumdb-extensions.png)
