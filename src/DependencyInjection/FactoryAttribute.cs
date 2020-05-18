using System;

namespace LiteLoader.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    public class FactoryAttribute : Attribute { }
}
