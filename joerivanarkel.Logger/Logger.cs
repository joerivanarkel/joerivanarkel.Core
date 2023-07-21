using System.Diagnostics;
using joerivanarkel.Logger.Enum;
using joerivanarkel.Logger.Exception;
using joerivanarkel.Logger.FileHandlers;
using joerivanarkel.Logger.FileHandlers.Model;
using joerivanarkel.Logger.Interfaces;

namespace joerivanarkel.Logger;

public class Logger : ILogger
{
    public enum LogType
    {
        ERROR,
        WARNING,
        INFO
    }

    private string LogFileName { get; set; }
    private readonly IFileWriteHandler _fileWriteHandler;

    public LoggerConfiguration _loggerConfiguration;


    public Logger() : this(new FileWriteHandler()) {}
    public Logger(IFileWriteHandler fileWriteHandler)
    {
        _fileWriteHandler = fileWriteHandler;
        _loggerConfiguration = new LoggerConfiguration();

        LogFileName = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}.{DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second}";
    }


    public bool Log(string message, LogType logType)
    {
        if (string.IsNullOrEmpty(message)) throw new LoggerException("Message cannot be null or empty");

        var time = DateTime.Now.ToString();
        var formattedMessage = LoggerUtils.FormatMessage(message);

        if (string.IsNullOrEmpty(formattedMessage)) throw new LoggerException("Message cannot be null or empty");

        var text = $"{time.Replace(" uur", "")}: {logType}: {LoggerUtils.GetCallingClassName()}.cs: {formattedMessage}\n";

        _fileWriteHandler.AppendToFile(new FileWriteModel(LogFileName, FileExtension.LOG, _loggerConfiguration.FolderName, text));
        if (_loggerConfiguration.UseConsole) Console.WriteLine(text);

        return true;
    }

    public bool Error(System.Exception exception)
        => Log(exception.Message, LogType.ERROR);


}
