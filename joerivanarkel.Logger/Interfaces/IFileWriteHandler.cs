using joerivanarkel.Logger.FileHandlers;
using joerivanarkel.Logger.FileHandlers.Model;

namespace joerivanarkel.Logger.Interfaces;

/// <inheritdoc cref="FileWriteHandler"/>
public interface IFileWriteHandler
{
    bool AppendToFile(FileWriteModel fileWriteModel, bool encryption = false);
    bool WriteToFile(FileWriteModel fileWriteModel, bool encryption = false);
}
