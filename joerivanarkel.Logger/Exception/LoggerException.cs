namespace joerivanarkel.Logger.Exception;

using System;

public class LoggerException : Exception
{
    public LoggerException(string message) : base(message) { }
}