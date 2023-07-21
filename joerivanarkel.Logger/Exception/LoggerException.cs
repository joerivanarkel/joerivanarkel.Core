namespace joerivanarkel.Logger.Exception;

using System;

internal class LoggerException : Exception
{
    internal LoggerException(string message) : base(message) { }
}