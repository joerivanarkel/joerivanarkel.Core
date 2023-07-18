using joerivanarkel.Core.Logger.FileHandlers;
using joerivanarkel.Core.Logger.FileHandlers.Model;

namespace joerivanarkel.Core.Logger.Interfaces;

/// <inheritdoc cref="FileWriteHandler"/>
public interface IFileWriteHandler
{
    bool AppendToFile(FileWriteModel fileWriteModel, bool encryption = false);
    bool WriteToFile(FileWriteModel fileWriteModel, bool encryption = false);
}
