using System;

namespace ModuDevCore.ElysiumDB
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class AfterExtensionAttribute : Attribute
    {
        public Type ExtensionType { get; }

        public AfterExtensionAttribute(Type extensionType)
        {
            ExtensionType = extensionType;
        }
    }
}