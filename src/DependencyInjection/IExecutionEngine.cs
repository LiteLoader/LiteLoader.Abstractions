using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LiteLoader.DependencyInjection
{
    public interface IExecutionEngine
    {
        MethodBase FindBestMethod(MethodBase[] methods, object[] arguments, out object[] newArgs, out int?[] map, out ParameterInfo[] parameters, IServiceProvider serviceProvider = null);

        object ExecuteMethod(MethodBase method, object[] arguments, object instance = null);

        bool CreateParameterMap(ParameterInfo[] parameters, object[] arguments, out int?[] map, out object[] newArgs, out int usedArguments, IServiceProvider serviceProvider = null);

        void ProcessByRefs(ParameterInfo[] parameters, object[] args, object[] original, int?[] map);
    }
}
