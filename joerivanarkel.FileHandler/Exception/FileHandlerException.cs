namespace joerivanarkel.FileHandler.Exception;

using System;

internal class FileHandlerException : Exception
{
    internal FileHandlerException(string message) : base(message) { }
}