using System;
using System.Collections.Generic;
using System.Reflection;

namespace LiteLoader.DependencyInjection
{
    public interface IExecutionEngine
    {
        bool CreateParameterMap(ParameterInfo[] parameters, object[] arguments, out int?[] map, out object[] newArgs, out int usedArguments, IServiceProvider serviceProvider = null);

        object ExecuteMethod(MethodBase method, object[] arguments, object instance = null);

        MethodBase FindBestMethod(IEnumerable<MethodBase> methods, object[] arguments, out object[] newArgs, out int?[] map, out ParameterInfo[] parameters, IServiceProvider serviceProvider = null);

        void ProcessByRefs(ParameterInfo[] parameters, object[] args, object[] original, int?[] map);
    }
}
