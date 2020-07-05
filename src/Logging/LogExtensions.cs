using System;

namespace LiteLoader.Logging
{
    public static class LogExtensions
    {
        public static bool HasFlag(this LogLevel logLevel, LogLevel flag)
        {
            return (logLevel & flag) == flag;
        }

        public static void Debug(this ILogger logger, object msg)
        {
            logger.Log(msg, LogLevel.Debug);
        }

        public static void Debug(this ILogger logger, string format, params object[] args)
        {
            logger.Log(string.Format(format, args), LogLevel.Debug);
        }

        public static void Error(this ILogger logger, object msg)
        {
            logger.Log(msg, LogLevel.Error);
        }

        public static void Error(this ILogger logger, string format, params object[] args)
        {
            logger.Log(string.Format(format, args), LogLevel.Error);
        }

        public static void Error(this ILogger logger, Exception exception)
        {
            string msg = string.Empty;

            while (exception != null)
            {
                msg += $"{exception.GetType().Name}: {exception.Message}" + Environment.NewLine +
                    $"--------------------------- Stacktrace ---------------------------" + Environment.NewLine +
                    exception.StackTrace + Environment.NewLine +
                    "------------------------- End Stacktrace -------------------------";

                if (exception.InnerException != null)
                {
                    msg += Environment.NewLine + Environment.NewLine;
                }

                exception = exception.InnerException;
            }

            logger.Log(msg, LogLevel.Error);
        }

        public static void Warning(this ILogger logger, object msg)
        {
            logger.Log(msg, LogLevel.Warning);
        }

        public static void Warning(this ILogger logger, string format, params object[] args)
        {
            logger.Log(string.Format(format, args), LogLevel.Warning);
        }

        public static void Information(this ILogger logger, object msg)
        {
            logger.Log(msg, LogLevel.Information);
        }

        public static void Information(this ILogger logger, string format, params object[] args)
        {
            logger.Log(string.Format(format, args), LogLevel.Information);
        }
    }
}
