namespace Server.Logger
{
    public interface ILogger
    {
        public void Log(LogLevel logLevel, string methodName, string message);

    }
}
