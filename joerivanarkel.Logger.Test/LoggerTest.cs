using FakeItEasy;
using joerivanarkel.Logger;
using joerivanarkel.FileHandler;
using joerivanarkel.Logger.Interfaces;
using joerivanarkel.FileHandler.Model;
using joerivanarkel.FileHandler.Interfaces;
using joerivanarkel.Logger.Exception;
using Xunit;
using static joerivanarkel.Logger.Logger;

namespace joerivanarkel.Logger.Test;

public class LoggerTest
{
    [Fact]
    public void ShouldLog()
    {
        // Arrange
        var FileWriteHandler = A.Fake<IFileWriteHandler>();
        var logger = new Logger();

        A.CallTo(() => FileWriteHandler.WriteToFile(A<FileWriteModel>.Ignored)).Returns(true);
        var message = "Test message";
        var type = LogType.INFO;

        // Act
        var result = logger.Log(message, type);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ShouldLogToConsole()
    {
        // Arrange
        var FileWriteHandler = A.Fake<IFileWriteHandler>();
        var logger = new Logger(FileWriteHandler);

        A.CallTo(() => FileWriteHandler.WriteToFile(A<FileWriteModel>.Ignored)).Returns(true);
        var message = "Test message";
        var type = LogType.INFO;

        // Act
        var result = logger.Log(message, type);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ShouldNotLog()
    {
        try
        {
            // Arrange
            var FileWriteHandler = A.Fake<IFileWriteHandler>();
            var logger = new Logger();

            A.CallTo(() => FileWriteHandler.WriteToFile(A<FileWriteModel>.Ignored)).Returns(false);
            var message = "";
            var type = LogType.INFO;
            // Act
            var result = logger.Log(message, type);
        }
        catch (System.Exception ex)
        {
            Assert.IsType<LoggerException>(ex);
            Assert.Equal("Message cannot be null or empty", ex.Message);
        }
    }

}