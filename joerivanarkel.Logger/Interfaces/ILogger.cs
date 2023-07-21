namespace joerivanarkel.Logger.Interfaces;

public interface ILogger
{
    public enum LogType
    {
        ERROR,
        WARNING,
        INFO
    }

    ILoggerConfiguration LoggerConfiguration { get; set; }

    bool Log(string message, Logger.LogType logType);
    bool Error(System.Exception exception);
}