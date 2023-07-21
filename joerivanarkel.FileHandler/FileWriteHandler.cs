using joerivanarkel.FileHandler.Exception;
using joerivanarkel.FileHandler.Model;
using joerivanarkel.FileHandler.Interfaces;

namespace joerivanarkel.FileHandler;

/// <summary>
/// This class handles writing to files.
/// </summary>
public class FileWriteHandler : BaseFileHandler, IFileWriteHandler
{
    public bool WriteToFile(FileWriteModel fileWriteModel, bool encryption = false)
    {
        fileWriteModel.IsValid();

        if (encryption)fileWriteModel.Text = Encrypt(fileWriteModel.Text);
        
        CreateFolder(fileWriteModel.Location);

        var result = Write(fileWriteModel).Result;

        return result;
    }
    public bool AppendToFile(FileWriteModel fileWriteModel, Boolean encryption = false)
    {
        fileWriteModel.IsValid();

        if (encryption)
        {
            fileWriteModel.Text = Encrypt(fileWriteModel.Text);
        }

        CreateFolder(fileWriteModel.Location);

        var result = AppendWrite(fileWriteModel).Result;

        return result;
    }

    private string Encrypt(string text)
    {
        return text += " This should be encrypted.";
    }

    private void CreateFolder(string location)
    {
        var targetFolder = Path.Combine(Environment.CurrentDirectory, location);

        bool exists = Directory.Exists(targetFolder);
        if (!exists)
        {
            Directory.CreateDirectory(targetFolder);
        }
    }

    private async Task<bool> Write(FileWriteModel fileWriteModel)
    {
        var name = fileWriteModel.Name + fileWriteModel.Extension;
        var targetFolder = Path.Combine(Environment.CurrentDirectory, fileWriteModel.Location);

        string fileName = Path.Combine(targetFolder, name);

        await File.WriteAllTextAsync(fileName, fileWriteModel.Text);

        return true;
    }

    private async Task<bool> AppendWrite(FileWriteModel fileWriteModel)
    {
        var name = fileWriteModel.Name + fileWriteModel.Extension;
        var targetFolder = Path.Combine(Environment.CurrentDirectory, fileWriteModel.Location);

        string fileName = Path.Combine(targetFolder, name);

        await File.AppendAllTextAsync(fileName, fileWriteModel.Text);

        return true;
    }
}
