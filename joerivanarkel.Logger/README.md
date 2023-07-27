<div class="container">
  <div class="row">
    <img src="icon.png" alt="Image Description" width="50" height="50" alt="joerivanarkelPackages Icon">
    <h1>joerivanarkel.Logger</h1>
  </div>

  <div class="row">
    <a href="https://www.nuget.org/packages/joerivanarkel.Logger/">
        <img src="https://img.shields.io/nuget/v/joerivanarkel.Logger.svg" alt="joerivanarkel.Logger">
    </a>
  </div>
</div>

<style>
  .container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
  }

  .row {
    display: flex;
    align-items: center;
    justify-content: center;
    margin-bottom: 10px;
  }

  .row img {
    margin-bottom: 10px;
    margin-right: 10px;
  }
</style>

This package is a custom logger that logs to a file.

# Contents
- [Methods](#methods)
- [Usage](#usage)
    - [Log Types](#log-types)
    - [Configuration](#configuration)
- [Examples](#examples)
    - [Example 1: Basic usage](#example-1-basic-usage)
    - [Example 2: Using the configuration](#example-2-using-the-configuration)
    - [Example 3: Using the error method](#example-3-using-the-error-method)
    - [Example 4: Using the fatal method](#example-4-using-the-fatal-method)

## Methods
| Class.Method | Description |
| --- | --- |
| `Logger.Log(string message, LogType logType)` | Logs the given message with the given log type. |
| `Logger.Error(Exception exception)` | Logs the given exception as an error. |
| `Logger.Fatal(Exception exception)` | Logs the given exception as a fatal error. |

## Usage
The logger can be used as follows:
```csharp
ILogger logger = new Logger()

logger.Log("Hello World!", LogType.INFO);
```

```log
[2021-09-26 15:00:00] [INFO] Hello World!
```

### Log Types
The logger supports the following log types:
| LogType | Description |
| --- | --- |
| `INFO` | Informational messages. |
| `WARNING` | Warning messages. |
| `ERROR` | Error messages. |
| `FATAL` | Fatal error messages. |

### Configuration
The logger can be configured using the `LoggerConfiguration` class. The following properties can be set:
| Property | Description | Possible values |
| --- | --- | --- |
| `FolderName` | The name of the folder in which the log file will be created. | |
| `UseConsole` | Whether or not the logger should also log to the console. | `true`<br>`false` |
| `UseFile` | Whether or not the logger should also log to a file. | `true`<br>`false`<br>`OnFatal` |

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

### Example 4: Using the fatal method
```csharp
ILogger logger = new Logger();

try
{
    throw new Exception("Something went wrong!");
}
catch (Exception exception)
{
    logger.Fatal(exception);
}
```

```log
[2021-09-26 15:00:00] [FATAL] Something went wrong!
```