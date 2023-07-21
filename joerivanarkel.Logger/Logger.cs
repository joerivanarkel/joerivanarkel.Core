using System.Diagnostics;
using joerivanarkel.Logger.Exception;
using joerivanarkel.Logger.Interfaces;
using joerivanarkel.FileHandler.Model;
using joerivanarkel.FileHandler;
using joerivanarkel.FileHandler.Enum;
using joerivanarkel.FileHandler.Interfaces;

namespace joerivanarkel.Logger;

public class Logger : ILogger
{
    /// <summary>
    /// The type of log, which can be ERROR, WARNING or INFO.
    /// </summary>
    public enum LogType
    {
        ERROR,
        WARNING,
        INFO
    }

    /// <summary>
    /// The configuration options for the logger.
    /// </summary>
    public LoggerConfiguration LoggerConfiguration { get; set; }

    private string LogFileName { get; set; }
    
    private readonly IFileWriteHandler _fileWriteHandler;

    public Logger() : this(new FileWriteHandler()) {}
    public Logger(IFileWriteHandler fileWriteHandler)
    {
        _fileWriteHandler = fileWriteHandler;
        LoggerConfiguration = new LoggerConfiguration();

        LogFileName = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}.{DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second}";
    }

    /// <summary>
    /// Logs a message
    /// </summary>
    /// <param name="message">The message to log</param>
    /// <param name="logType">INFO, WARNING or ERROR</param>
    /// <returns>True if the message was logged successfully</returns>
    /// <exception cref="LoggerException">Thrown when the message is null or empty</exception>
    public bool Log(string message, LogType logType)
    {
        if (string.IsNullOrEmpty(message)) throw new LoggerException("Message cannot be null or empty");

        var time = DateTime.Now.ToString();
        var formattedMessage = MessageFormatter.FormatMessage(message);

        if (string.IsNullOrEmpty(formattedMessage)) throw new LoggerException("Message cannot be null or empty");

        var text = $"{time.Replace(" uur", "")}: {logType}: {MessageFormatter.GetCallingClassName()}.cs: {formattedMessage}\n";

        _fileWriteHandler.AppendToFile(new FileWriteModel(LogFileName, FileExtension.LOG, LoggerConfiguration.FolderName, text));
        if (LoggerConfiguration.UseConsole) Console.WriteLine(text);

        return true;
    }

    /// <summary>
    /// Logs an exception
    /// </summary>
    /// <param name="exception">The exception to log</param>
    /// <returns>True if the exception was logged successfully</returns>
    /// <exception cref="LoggerException">Thrown when the exception is null or empty</exception>
    public bool Error(System.Exception exception)
    {
        var result = Log(exception.Message, LogType.ERROR);
        if (exception.InnerException != null) result = Log(exception.InnerException.Message, LogType.ERROR);

        return result;
    }
}
