using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Core;
using Traveller.Core.Providers.Contracts;

namespace Traveller.UnitTests.Core.EngineTests
{
    [TestClass]
    public class Start_Should
    {
        [TestMethod]
        public void InvokeProcessorProcessCommandMethodOnce_WhenValidCommandIsEntered()
        {
            // Arrange
            var commandAsString = "createbus 25 1";
            var exitCommandMessage = "Exit";

            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<ICommandProcessor>();

            readerMock
                .SetupSequence(m => m.ReadLine())
                .Returns(commandAsString)
                .Returns(exitCommandMessage);

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);

            // Act
            engine.Start();

            // Assert
            processorMock.Verify(m => m.ProcessCommand(commandAsString), Times.Once);
        }

        [TestMethod]
        public void InvokeWriterWriteMethodOnceWithValidResult_WhenValidCommandIsEntered()
        {
            // Arrange
            var sb = new StringBuilder();
            var commandAsString = "createbus 25 1";
            var exitCommandMessage = "Exit";
            var executionResultMessage = "Execution result";
            sb.AppendLine(executionResultMessage);

            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<ICommandProcessor>();

            readerMock
                .SetupSequence(m => m.ReadLine())
                .Returns(commandAsString)
                .Returns(exitCommandMessage);

            processorMock
                .Setup(m => m.ProcessCommand(commandAsString))
                .Returns(executionResultMessage);

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(m => m.Write(It.Is<string>(x => x == sb.ToString())), Times.Once);
        }

        [TestMethod]
        public void InvokeWriterWriteMethodOnceWithExceptionMessage_WhenInvokedWithInvalidParameters()
        {
            // Arrange
            var sb = new StringBuilder();
            var commandAsString = "25 1";
            var exitCommandMessage = "Exit";
            var exceptionMessage = "Invalid command!";
            var exception = new Exception(exceptionMessage);
            sb.AppendLine(exceptionMessage);

            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<ICommandProcessor>();


            readerMock
                .SetupSequence(m => m.ReadLine())
                .Returns(commandAsString)
                .Returns(exitCommandMessage);

            processorMock
                .Setup(m => m.ProcessCommand(commandAsString))
                .Throws(exception);

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(m => m.Write(It.Is<string>(x => x == sb.ToString())), Times.Once);
        }
    }
}
