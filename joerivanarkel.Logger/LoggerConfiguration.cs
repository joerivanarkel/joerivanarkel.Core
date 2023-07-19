using joerivanarkel.Logger.Interfaces;

namespace joerivanarkel.Logger;

public class LoggerConfiguration : ILoggerConfiguration
{
    public string FolderName { get; set; } = ".logs";
    public bool UseConsole { get; set; } = false;
}
