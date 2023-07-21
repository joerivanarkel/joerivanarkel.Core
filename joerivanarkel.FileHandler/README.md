<div class="container">
  <div class="row">
    <img src="icon.png" alt="Image Description" width="50" height="50" alt="joerivanarkelPackages Icon">
    <h1>joerivanarkel.FileHandler</h1>
  </div>

  <div class="row">
    <a href="https://www.nuget.org/packages/joerivanarkel.FileHandler/">
        <img src="https://img.shields.io/nuget/v/joerivanarkel.FileHandler.svg" alt="joerivanarkel.FileHandler">
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

This package which handles read and write operations to files.

# Contents
- [Methods](#methods)
- [Usage](#usage)

## Methods
| Class.Method | Description |
| --- | --- |
| `FileReadHandler.ReadAllTextFromFile(string name, FileExtension extension, string location)` | Reads all text from the file with the given name, extension and location. |
| `FileReadHandler.FileExists(string name, FileExtension extension, string location)` | Returns whether the file with the given name, extension and location exists. |
| `FileWriteHandler.WriteAllTextToFile(string name, FileExtension extension, string location, string content)` | Writes the given content to the file with the given name, extension and location. |
| | |
| `FileWriteHandler.AppendToFile(FileWriteModel fileWriteModel)` | Appends the given content to the file with the given name, extension and location. |
| `FileWriteHandler.AppendToFile(string name, FileExtension extension, string location, string content)` | Appends the given content to the file with the given name, extension and location. |

## Usage

The reader can be used as follows:
```csharp
var content = FileReadHandler.ReadAllTextFromFile("test", FileExtension.TXT, "C:\\Users\\joeri\\Desktop");
```

The writer can be used as follows:
```csharp
FileWriteHandler.WriteAllTextToFile(new FileWriteModel
{
    Name = "test",
    Extension = FileExtension.TXT,
    Location = "C:\\Users\\joeri\\Desktop",
    Text = "Hello World!"
});
```

## Examples

### Example 1: Basic usage of the reader

```csharp
var content = FileReadHandler.ReadAllTextFromFile("test", FileExtension.TXT, "C:\\Users\\joeri\\Desktop");
```

### Example 2: Basic usage of the writer

```csharp
FileWriteHandler.WriteAllTextToFile(new FileWriteModel
{
    Name = "test",
    Extension = FileExtension.TXT,
    Location = "C:\\Users\\joeri\\Desktop",
    Text = "Hello World!"
});
```

### Example 3: Basic usage of the writer with the append method

```csharp
FileWriteHandler.AppendToFile(new FileWriteModel
{
    Name = "test",
    Extension = FileExtension.TXT,
    Location = "C:\\Users\\joeri\\Desktop",
    Text = "Hello World!"
});
```

### Example 4: Checking if a file exists

```csharp
var fileExists = FileReadHandler.FileExists("test", FileExtension.TXT, "C:\\Users\\joeri\\Desktop");
```

### Example 5: Checking if a directory exists

```csharp
var directoryExists = FileReadHandler.DirectoryExists("C:\\Users\\joeri\\Desktop");
```
