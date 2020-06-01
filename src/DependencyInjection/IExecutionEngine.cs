using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LiteLoader.DependencyInjection
{
    public interface IExecutionEngine
    {
        object ExecuteMethod(MethodBase method, object[] arguments, object instance = null, IServiceProvider serviceProvider = null);
    }
}
