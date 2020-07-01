using LiteLoader.DependencyInjection;
using LiteLoader.Logging;
using System.Threading;

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
        /// The temporary directory used by LiteLoader
        /// </summary>
        string TemporaryDirectory { get; }

        /// <summary>
        /// The log level defined by the user
        /// </summary>
        LogLevel LogLevel { get; }

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

        #region Cleanup

#if !NET35

        CancellationToken GenerateCancellationToken();

#endif

        #endregion
    }
}
