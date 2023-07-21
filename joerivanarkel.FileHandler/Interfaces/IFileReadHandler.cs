using joerivanarkel.FileHandler.Enum;

namespace joerivanarkel.FileHandler.Interfaces;

/// <inheritdoc cref="FileReadHandler"/>
public interface IFileReadHandler
{
    bool FileExists(string name, FileExtension extension, string location);
    Task<string> ReadAllTextFromFile(string name, FileExtension extension, string location);
    bool DirectoryExists(string location);
}
