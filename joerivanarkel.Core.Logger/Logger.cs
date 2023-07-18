using System.Diagnostics;
using joerivanarkel.Core.Logger.Enum;
using joerivanarkel.Core.Logger.FileHandlers;
using joerivanarkel.Core.Logger.FileHandlers.Model;
using joerivanarkel.Core.Logger.Interfaces;

namespace joerivanarkel.Core.Logger;

public class Logger
{
    public enum LogType
    {
        ERROR,
        WARNING,
        INFO
    }

    private string logFileName { get; set; }
    private readonly IFileWriteHandler _fileWriteHandler;
    private readonly string _location;

    public Logger() : this(new FileWriteHandler()) {}

    public Logger(FileWriteHandler fileWriteHandler)
    {
        logFileName = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}.{DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second}";
        _fileWriteHandler = fileWriteHandler;
        _location = "Logs";
    }

    public bool Log(string message, LogType logType)
    {
        var time = DateTime.Now.ToString();
        var formattedMessage = FormatMessage(message);
        var text = ($"{time.Replace(" uur", "")}: {logType.ToString()}: {GetCallingClassName()}.cs: {formattedMessage}\n");

        _fileWriteHandler.AppendToFile(new FileWriteModel(logFileName, FileExtension.LOG, _location, text));

        return true;
    }


    private string FormatMessage(string message)
    {
        if (message.Contains('\n')) message = message.Replace('\n', ' ');
        if (message.Contains('\r')) message = message.Replace('\r', ' ');

        return message;
    }

    private string GetCallingClassName()
    {
        var stackTrace = new StackTrace();
        var callingClass = stackTrace.GetFrame(2)?.GetMethod()?.DeclaringType?.Name ?? "Unknown";

        return callingClass;
    }
}
