namespace LiteLoader.Logging
{
    /// <summary>
    /// Basic interface for logging messages
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// The log level this logger will process
        /// </summary>
        LogLevel Level { get; }

        /// <summary>
        /// Logs a message to this logger
        /// </summary>
        /// <param name="msg">Message to log</param>
        /// <param name="level">Log Level</param>
        void Log(object msg, LogLevel level);
    }
}
