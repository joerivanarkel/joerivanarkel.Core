namespace joerivanarkel.Logger.Interfaces;

public interface ILoggerConfiguration
{
    string FolderName { get; set; }
    
    bool UseConsole { get; set; }
    bool UseFile { get; set; }
}
