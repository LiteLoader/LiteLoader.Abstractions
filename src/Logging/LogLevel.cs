using System;

namespace LiteLoader.Logging
{
    /// <summary>
    /// Logger log level
    /// </summary>
    [Flags]
    public enum LogLevel
    {
        /// <summary>
        /// Show no log messages
        /// </summary>
        None = 0,

        /// <summary>
        /// Show info messages
        /// </summary>
        Information = 1,

        /// <summary>
        /// Show warning messages
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Show error messages
        /// </summary>
        Error = 4,

        /// <summary>
        /// Show debug messages
        /// </summary>
        Debug = 8,

        /// <summary>
        /// Shows informational and warning messages
        /// </summary>
        Production = Information | Warning,

        /// <summary>
        /// Shows all messages passed into the logger
        /// </summary>
        Development = Production | Error | Debug
    }
}
