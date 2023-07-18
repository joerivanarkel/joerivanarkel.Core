using System.Diagnostics;
using joerivanarkel.Core.Logger.Enum;
using joerivanarkel.Core.Logger.FileHandlers;
using joerivanarkel.Core.Logger.FileHandlers.Model;
using joerivanarkel.Core.Logger.Interfaces;

namespace joerivanarkel.Core.Logger;

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
    private LoggerConfiguration _loggerConfiguration;


    public Logger() : this(new FileWriteHandler()) {}
    public Logger(FileWriteHandler fileWriteHandler) : this(fileWriteHandler, new LoggerConfiguration()) {}
    public Logger(IFileWriteHandler fileWriteHandler, LoggerConfiguration loggerConfiguration)
    {
        _fileWriteHandler = fileWriteHandler;
        _loggerConfiguration = loggerConfiguration;

        LogFileName = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}.{DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second}";
    }


    public bool Log(string message, LogType logType)
    {
        var time = DateTime.Now.ToString();
        var formattedMessage = LoggerUtils.FormatMessage(message);
        var text = $"{time.Replace(" uur", "")}: {logType}: {LoggerUtils.GetCallingClassName()}.cs: {formattedMessage}\n";

        _fileWriteHandler.AppendToFile(new FileWriteModel(LogFileName, FileExtension.LOG, _loggerConfiguration.FolderName, text));

        return true;
    }

    public bool Error(Exception exception)
        => Log(exception.Message, LogType.ERROR);
    



}
