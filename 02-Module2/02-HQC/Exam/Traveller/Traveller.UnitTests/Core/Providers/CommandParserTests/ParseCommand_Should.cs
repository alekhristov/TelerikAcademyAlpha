using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Traveller.Commands.Contracts;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers;

namespace Traveller.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseCommand_Should
    {
        [TestMethod]
        public void CallsCreateCommandOnce_WhenInvokedWithValidParameter()
        {
            // Arrange
            var fullCommand = "createbus 25 1";
            var commandName = "createbus";

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act
            commandParser.ParseCommand(fullCommand);

            // Assert
            commandFactoryMock.Verify(m => m.CreateCommand(commandName), Times.Once);
        }

        [TestMethod]
        public void CreateICommand_WhenInvokedWithValidParameter()
        {
            // Arrange
            var fullCommand = "createbus 25 1";
            var commandName = "createbus";

            var commandFactoryMock = new Mock<ICommandFactory>();
            var commandMock = new Mock<ICommand>();

            commandFactoryMock
                .Setup(m => m.CreateCommand(commandName))
                .Returns(commandMock.Object);

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act
            var command = commandParser.ParseCommand(fullCommand);

            // Assert
            Assert.IsNotNull(command);
            Assert.IsInstanceOfType(command, typeof(ICommand));
        }

        [TestMethod]
        public void ReturnICommand_WhenInvokedWithValidParameter()
        {
            // Arrange
            var fullCommand = "createbus 25 1";
            var commandName = "createbus";

            var commandFactoryMock = new Mock<ICommandFactory>();
            var commandMock = new Mock<ICommand>();

            commandFactoryMock
                .Setup(m => m.CreateCommand(commandName))
                .Returns(commandMock.Object);

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act
            var command = commandParser.ParseCommand(fullCommand);

            // Assert
            Assert.AreSame(commandMock.Object, command);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullFullCommandParameter()
        {
            // Arrange
            //var fullCommand = "createbus 25 1";

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => commandParser.ParseCommand(null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyFullCommandParameter()
        {
            // Arrange
            //var fullCommand = "createbus 25 1";

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => commandParser.ParseCommand(string.Empty));
        }
    }
}
