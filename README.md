<div style="display: flex;flex-direction: column;align-items: center;justify-content: center;">
  <div style="display: flex;align-items: center;justify-content: center;margin-bottom: 10px;">
    <img src="icon.png" alt="Image Description" width="50" height="50" alt="joerivanarkelPackages Icon" style="margin-bottom: 10px;margin-right: 10px;">
    <h1>joerivanarkel.Packages</h1>
  </div>

  <div style="display: flex;align-items: center;justify-content: center;margin-bottom: 10px;">
    <a href="https://github.com/joerivanarkel/joerivanarkel.Packages/actions/workflows/dotnet.yml">
      <img src="https://github.com/joerivanarkel/joerivanarkel.Packages/actions/workflows/dotnet.yml/badge.svg" alt=".NET & Deploy Package, Workflow Status Badge" style="margin-bottom: 10px;margin-right: 10px;">
    </a>
  </div>
</div>

<!--
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
-->

In this repository, the owner has published packages that they use in their own projects. These packages are available on both [NuGet](https://www.nuget.org/profiles/joerivanarkel) and in this repository as Github Packages.

These packages vary from simple wrappers around existing packages to custom packages that are used in multiple projects. The packages are listed [below](#packages). For more information about a specific package, click on the package name. This will take you to the package's README file. This file contains information about the package, such as how to use it.

## Packages
| Package | Version | Description |
| --- | --- | --- |
| [joerivanarkel.UserSecrets](./joerivanarkel.UserSecrets/README.md) | [![joerivanarkel.UserSecrets](https://img.shields.io/nuget/v/joerivanarkel.UserSecrets.svg)](https://www.nuget.org/packages/joerivanarkel.UserSecrets/) | This package is a simple wrapper around the [Microsoft.Extensions.Configuration.UserSecrets](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets/) package. |
| [joerivanarkel.Logger](./joerivanarkel.Logger/README.md) | [![joerivanarkel.Logger](https://img.shields.io/nuget/v/joerivanarkel.Logger.svg)](https://www.nuget.org/packages/joerivanarkel.Logger/) | This package is a custom logger that logs to a file. |
| [joerivanarkel.FileHandler](./joerivanarkel.FileHandler/README.md) | [![joerivanarkel.FileHandler](https://img.shields.io/nuget/v/joerivanarkel.FileHandler.svg)](https://www.nuget.org/packages/joerivanarkel.FileHandler/) | This package which handles read and write operations to files. |

## Solution Structure
<i>As of 22 of July 2023</i><br>
The solution has a number of projects. For each package, there is a project that contains the package. In addition, there is a project that contains the tests for the package. The package has a relation with the Solution entity. The solution structure is shown below.

```mermaid
classDiagram
    class Solution {
    }

    Solution --> UserSecrets
    Solution --> Logger
    Solution --> FileHandler

    class UserSecrets {
        class UserSecrets

        exception UserSecretsException
    }

    class UserSecretsTest {
        class UserSecretsTest
    }

    UserSecrets --> UserSecretsTest


    class Logger {
        class Logger
        class LoggerConfiguration
        class MessageFormatter

        interface ILogger
        interface ILoggerConfiguration

        enum LogType

        exception LoggerException
    }

    class LoggerTest {
        class LoggerTest
    }

    Logger --> LoggerTest

    class FileHandler {
        class BaseFileHandler
        class FileReadHandler
        class FileWriteHandler
        class FileWriteModel

        interface IFileReadHandler
        interface IFileWriteHandler

        enum FileExtension

        exception FileHandlerException
    }

    class FileHandlerTest {
        class FileHandlerTest
    }

    FileHandler --> FileHandlerTest
```
