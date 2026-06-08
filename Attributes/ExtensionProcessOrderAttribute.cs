using System;

namespace ModuDevCore.ElysiumDB
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ExtensionProcessOrderAttribute : Attribute
    {
        public string Group { get; }
        public int Order { get; }

        public ExtensionProcessOrderAttribute(string group, int order = 0)
        {
            Group = group ?? "Default";
            Order = order;
        }
    }
}