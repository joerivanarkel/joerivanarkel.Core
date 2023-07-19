namespace joerivanarkel.Logger.Interfaces;

public interface ILogger
{
    bool Log(string message, Logger.LogType logType);
    bool Error(System.Exception exception);
}