using joerivanarkel.Core.Logger.Interfaces;

namespace joerivanarkel.Core.Logger;

public class LoggerConfiguration : ILoggerConfiguration
{
    public string FolderName { get; set; } = ".logs";
}
