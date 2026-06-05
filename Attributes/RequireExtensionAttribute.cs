using System;

namespace ModuDevCore.ElysiumDB
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class RequireExtensionAttribute : Attribute
    {
        public Type ExtensionType;

        public bool AutoCreate;

        public RequireExtensionAttribute(Type extensionType, bool autoCreate = true)
        {
            ExtensionType = extensionType;
            AutoCreate = autoCreate;
        }
    }
}