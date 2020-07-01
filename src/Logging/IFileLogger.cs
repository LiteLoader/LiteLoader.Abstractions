using System;

namespace LiteLoader.Logging
{
    public interface IFileLogger : ILogger
    {
        /// <summary>
        /// Maximum file size before rotating file
        /// </summary>
        long MaxFileSize { get; }

        /// <summary>
        /// How long to keep a log file
        /// </summary>
        TimeSpan DeleteAfter { get; }

        /// <summary>
        /// The path to the file this logger is currently writing too
        /// </summary>
        string FilePath { get; }
    }
}
