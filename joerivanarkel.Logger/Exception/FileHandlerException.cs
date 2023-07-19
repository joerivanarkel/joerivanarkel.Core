namespace joerivanarkel.Logger.Exception;

using System;

public class FileHandlerException : Exception
{
    public FileHandlerException(string message) : base(message) { }
}