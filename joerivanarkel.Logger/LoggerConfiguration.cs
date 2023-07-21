using joerivanarkel.Logger.Interfaces;

namespace joerivanarkel.Logger;

/// <summary>
/// The configuration options for the logger.
/// </summary>
public class LoggerConfiguration : ILoggerConfiguration
{
    /// <summary>
    /// The name of the folder where the logs will be stored.
    /// </summary>
    public string FolderName { get; set; } = ".logs";
    
    
    /// <summary>
    /// If the logger should use the console.
    /// </summary>
    public bool UseConsole { get; set; } = false;
    /// <summary>
    /// If the logger should use a file.
    /// </summary>
    public bool UseFile { get; set; } = true;
}
