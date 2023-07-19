using System.Diagnostics;

namespace joerivanarkel.Logger;

public static class LoggerUtils
{
    public static string FormatMessage(string message)
    {
        if (message.Contains('\n')) message = message.Replace('\n', ' ');
        if (message.Contains('\r')) message = message.Replace('\r', ' ');

        return message;
    }

    public static string GetCallingClassName()
    {
        var stackTrace = new StackTrace();
        var callingClass = stackTrace.GetFrame(2)?.GetMethod()?.DeclaringType?.Name ?? "Unknown";

        return callingClass;
    }
}