using System.Collections.Generic;

namespace LiteLoader.Modules
{
    /// <summary>
    /// Responsible for loading Modules
    /// </summary>
    public interface IModuleLoader
    {
        /// <summary>
        /// Gets a collection of all loaded Modules
        /// </summary>
        IEnumerable<string> LoadedModules { get; }

        /// <summary>
        /// Gets a collection of Modules currently unloaded
        /// </summary>
        IEnumerable<string> UnloadedModules { get; }

        /// <summary>
        /// Returns a instance of a loaded Module
        /// </summary>
        /// <remarks>Should return null if Module is not loaded or is loading asyncronously</remarks>
        /// <param name="moduleName">The Module name</param>
        /// <returns>The Module instance</returns>
        IModule GetModule(string moduleName);

        /// <summary>
        /// Check if a Module is currently loaded
        /// </summary>
        /// <param name="moduleName">The Module name</param>
        /// <returns>True if the Module is loaded else false</returns>
        bool IsModuleLoaded(string moduleName);

        /// <summary>
        /// Check if a Module is currently being loaded asyncronously
        /// </summary>
        /// <param name="moduleName">The Module name</param>
        /// <returns>True if the Module is loading else false</returns>
        bool IsModuleLoading(string moduleName);

        /// <summary>
        /// Load a Module
        /// </summary>
        /// <param name="moduleName">The Module name</param>
        /// <param name="immediately">Load the Module asyncronously</param>
        void LoadModule(string moduleName, bool immediately = false);

        /// <summary>
        /// Unloads a Module
        /// </summary>
        /// <param name="moduleName">The Module name</param>
        void UnloadModule(string moduleName);
    }
}
