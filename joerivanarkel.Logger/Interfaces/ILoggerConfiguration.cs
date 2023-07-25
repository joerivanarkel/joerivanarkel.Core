using joerivanarkel.Logger.Enum;

namespace joerivanarkel.Logger.Interfaces;

public partial interface ILoggerConfiguration
{
    string FolderName { get; set; }
    
    UseConsoleEnum UseConsole { get; set; }
    UseFileEnum UseFile { get; set; }
}
