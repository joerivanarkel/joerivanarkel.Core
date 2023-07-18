namespace joerivanarkel.Core.Logger.FileHandlers.Interfaces;

/// <inheritdoc cref="FileWriteHandler"/>
public interface IFileWriteHandler
{
    bool AppendToFile(FileWriteModel fileWriteModel, bool encryption = false);
    bool WriteToFile(FileWriteModel fileWriteModel, bool encryption = false);
}
