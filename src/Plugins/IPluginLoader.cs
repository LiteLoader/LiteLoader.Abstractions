using System.Collections.Generic;

namespace LiteLoader.Plugins
{
    /// <summary>
    /// Responsible for loading plugins
    /// </summary>
    public interface IPluginLoader
    {
        /// <summary>
        /// Gets a collection of all loaded plugins
        /// </summary>
        IEnumerable<string> LoadedPlugins { get; }

        /// <summary>
        /// Gets a collection of plugins currently unloaded
        /// </summary>
        IEnumerable<string> UnloadedPlugins { get; }

        /// <summary>
        /// Load a plugin
        /// </summary>
        /// <param name="pluginName">The plugin name</param>
        /// <param name="immediately">Load the plugin asyncronously</param>
        void LoadPlugin(string pluginName, bool immediately = false);

        /// <summary>
        /// Unloads a plugin
        /// </summary>
        /// <param name="pluginName">The plugin name</param>
        void UnloadPlugin(string pluginName);

        /// <summary>
        /// Check if a plugin is currently loaded
        /// </summary>
        /// <param name="pluginName">The plugin name</param>
        /// <returns>True if the plugin is loaded else false</returns>
        bool IsPluginLoaded(string pluginName);

        /// <summary>
        /// Check if a plugin is currently being loaded asyncronously
        /// </summary>
        /// <param name="pluginName">The plugin name</param>
        /// <returns>True if the plugin is loading else false</returns>
        bool IsPluginLoading(string pluginName);

        /// <summary>
        /// Returns a instance of a loaded plugin
        /// </summary>
        /// <remarks>
        /// Should return null if plugin is not loaded or is loading asyncronously
        /// </remarks>
        /// <param name="pluginName">The plugin name</param>
        /// <returns>The plugin instance</returns>
        IPlugin GetPlugin(string pluginName);
    }
}
