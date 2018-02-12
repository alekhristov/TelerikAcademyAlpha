using Academy.Commands.Contracts;
using Academy.Core;
using Academy.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Text;

namespace Academy.UnitTests.Core.EngineTests
{
    [TestClass]
    public class Start_Should
    {
        [TestMethod]
        public void CallWriterWriteMethodWithCommandsResults_WhenInputIsCorrect()
        {
            // Arrange
            var fullCommand = "CreateStudent Alek Frontend";
            var exitCommand = "Exit";
            
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<ICommandParser>();
            var processorMock = new Mock<ICommandProcessor>();
            var commandMock = new Mock<ICommand>();
            var commandResultMessage = "Student created";

            var sb = new StringBuilder();
            sb.AppendLine(commandResultMessage);
            var expectedResult = sb.ToString();
            
            readerMock
                .SetupSequence(m => m.ReadLine())
                .Returns(fullCommand)
                .Returns(exitCommand);

            parserMock
                .Setup(m => m.ParseCommand(fullCommand))
                .Returns(commandMock.Object);

            commandMock
                .Setup(m => m.Execute(It.IsAny<IList<string>>()))
                .Returns(commandResultMessage);

            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, processorMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(m => m.Write(expectedResult), Times.Once);
        }
    }
}
