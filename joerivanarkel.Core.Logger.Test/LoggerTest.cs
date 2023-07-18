using FakeItEasy;
using joerivanarkel.Core.Logger;
using joerivanarkel.Core.Logger.FileHandlers;
using joerivanarkel.Core.Logger.Interfaces;
using joerivanarkel.Core.Logger.FileHandlers.Model;
using Xunit;
using static joerivanarkel.Core.Logger.Logger;

namespace joerivanarkel.Core.Logger.Test;

public class LoggerTest
{
    [Fact]
    public void ShouldLog()
    {
        // Arrange
        var FileWriteHandler = A.Fake<IFileWriteHandler>();
        var logger = new Logger();

        A.CallTo(() => FileWriteHandler.WriteToFile(A<FileWriteModel>.Ignored, A<bool>.Ignored)).Returns(true);
        var message = "Test message";
        var type = LogType.INFO;

        // Act
        var result = logger.Log(message, type);

        // Assert
        Assert.True(result);
    }
        
}