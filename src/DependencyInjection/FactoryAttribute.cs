using System;

namespace LiteLoader.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    public sealed class FactoryAttribute : Attribute { }
}
