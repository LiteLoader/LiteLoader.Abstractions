namespace LiteLoader.Logging
{
    public static class LogExtensions
    {
        public static bool HasFlag(this LogLevel logLevel, LogLevel flags)
        {
            return (logLevel & flags) == flags;
        }

        public static LogLevel SetFlag(this LogLevel logLevel, LogLevel flags)
        {
            return logLevel | flags;
        }

        public static LogLevel ClearFlag(this LogLevel logLevel, LogLevel flags)
        {
            return logLevel & (~flags);
        }
    }
}
