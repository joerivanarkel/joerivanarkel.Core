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
ILogger logger = new Logger()

logger.Log("Hello World!", LogType.INFO);
```

```log
[2021-09-26 15:00:00] [INFO] Hello World!
```

## Log Types
The logger supports the following log types:
| LogType | Description |
| --- | --- |
| `INFO` | Informational messages. |
| `WARNING` | Warning messages. |
| `ERROR` | Error messages. |

## Configuration
The logger can be configured using the `LoggerConfiguration` class. The following properties can be set:
| Property | Description |
| --- | --- |
| `FolderName` | The name of the folder in which the log file will be created. |
| `UseConsole` | Whether or not the logger should also log to the console. |
| `UseFile` | Whether or not the logger should also log to a file. |

## Examples

### Example 1: Basic usage
```csharp
ILogger logger = new Logger();

logger.Log("Hello World!", LogType.INFO);
```

```log
[2021-09-26 15:00:00] [INFO] Hello World!
```

### Example 2: Using the configuration
```csharp
LoggerConfiguration configuration = new LoggerConfiguration()
{
    FolderName = "Logs",
    UseConsole = true,
    UseFile = true
};

ILogger logger = new Logger(configuration);

logger.Log("Hello World!", LogType.INFO);
```

```log
[2021-09-26 15:00:00] [INFO] Hello World!
```

### Example 3: Using the error method
```csharp
ILogger logger = new Logger();

try
{
    throw new Exception("Something went wrong!");
}
catch (Exception exception)
{
    logger.Error(exception);
}
```

```log
[2021-09-26 15:00:00] [ERROR] Something went wrong!
```