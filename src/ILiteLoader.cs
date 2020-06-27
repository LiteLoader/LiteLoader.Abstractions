using LiteLoader.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteLoader
{
    public interface ILiteLoader
    {
        #region Information

        /// <summary>
        /// The root path containing the game executable
        /// </summary>
        string RootDirectory { get; }

        /// <summary>
        /// The path containing all LiteLoader files
        /// </summary>
        string FrameworkDirectory { get; }

        /// <summary>
        /// The path containing all module files
        /// </summary>
        string ModuleDirectory { get; }

        /// <summary>
        /// The assembly name of the game module
        /// </summary>
        string GameModule { get; }

        #endregion

        #region Services

        /// <summary>
        /// The frameworks service provider
        /// </summary>
        IDynamicServiceProvider ServiceProvider { get; }

        #endregion
    }
}
