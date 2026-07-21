# 3.2 [RequireExtensionAttribute](./REFERENCE.md#ModuDevCore.ElysiumDB.Attributes.RequireExtensionAttribute)

Create two files anywhere in your project folder:

### DBCustomExtension1.cs
```csharp
using UnityEngine;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

[RequireExtensionAttribute(typeof(DBCustomExtension2))]
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

Click the **Add** button to add a new Extension and select **DBCustomExtension1** from the list.
![elysiumdb-extensions](./Images/elysiumdb-extensions.png)

At the end, you should see two modules in the Extensions list (or a warning if you used `[RequireExtensionAttribute(typeof(DBCustomExtension2), false)]`).


![requireextensionattribute-adding-new-flow](./../../Images/requireextensionattribute-adding-new-flow.png)

![requireextensionattribute-remove-flow](./../../Images/requireextensionattribute-remove-flow.png)