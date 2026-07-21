# Complete Working Case
```csharp
using UnityEngine;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

[DefaultExtensionGroupAttribute("Custom/DBCustomExtension")]
[ExtensionProcessOrderAttribute(nameof(DBCustomExtension1), 0)]
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

[ExtensionProcessOrderAttribute(nameof(DBCustomExtension1), 1)]
[DefaultExtensionGroupAttribute("Custom/DBCustomExtension")]
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

**Expected Result:**  
![Example Result](./../Images/defaultextensiongroupattribute.png)