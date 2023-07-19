# joerivanarkel.Logger

This package is a custom logger that logs to a file.

## Classes
| Class.Method | Description |
| --- | --- |
| `Logger.Log(string message, LogType logType)` | Logs the given message with the given log type. |
| `Logger.Error(Exception exception)` | Logs the given exception as an error. |

## Configuration
The logger can be configured using the `LoggerConfiguration` class. The following properties can be set:
| Property | Description |
| --- | --- |
| `FolderName` | The name of the folder in which the log file will be created. |
| `UseConsole` | Whether or not the logger should also log to the console. |

## Usage
The logger can be used as follows:
```csharp
ILogger logger = new Logger(new LoggerConfiguration
{
    FolderName = "Logs",
    UseConsole = false
});

logger.Log("Hello World!", LogType.INFO);
```