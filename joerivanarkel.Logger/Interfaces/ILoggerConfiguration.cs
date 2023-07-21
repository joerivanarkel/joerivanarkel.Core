namespace joerivanarkel.Logger.Interfaces;

internal interface ILoggerConfiguration
{
    string FolderName { get; set; }

    bool UseConsole { get; set; }
    bool UseFile { get; set; }
}
