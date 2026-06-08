using System;

namespace ModuDevCore.ElysiumDB
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class DefaultExtensionGroupAttribute : Attribute
    {
        public string ExtensionGroup;

        public DefaultExtensionGroupAttribute(string extensionGroup)
        {
            ExtensionGroup = extensionGroup;
        }
    }
}