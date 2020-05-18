using System;

namespace LiteLoader.Plugins
{
    public interface IPlugin : IEquatable<IPlugin>, IComparable<IPlugin>
    {
        #region Plugin Methods

        /// <summary>
        /// Executes a hook on this plugin
        /// </summary>
        /// <param name="hookName">Name of the hook to call</param>
        /// <param name="arguments">Arguments values</param>
        /// <returns>Resulting value of the hook execution</returns>
        object ExecuteHook(string hookName, object[] arguments);

        #endregion
    }
}
