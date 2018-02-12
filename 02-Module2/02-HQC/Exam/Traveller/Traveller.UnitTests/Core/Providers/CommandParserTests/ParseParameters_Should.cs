using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers;

namespace Traveller.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseParameters_Should
    {
        [TestMethod]
        public void ReturnCollection_WhenInvokedWithValidParameter()
        {
            // Arrange
            var fullCommand = "createbus 25 1";
            var expectedResult = new List<string>() { "25", "1" };

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act
            var actualResult = commandParser.ParseParameters(fullCommand);

            // Assert
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void ReturnEmptyCollection_WhenInvokedWithInvalidParameter()
        {
            // Arrange
            var fullCommand = "createbus";
            var expectedResult = new List<string>();

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act
            var actualResult = commandParser.ParseParameters(fullCommand);

            // Assert
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullFullCommandParameter()
        {
            // Arrange
            //var fullCommand = "createbus";

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => commandParser.ParseParameters(null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyFullCommandParameter()
        {
            // Arrange
            //var fullCommand = "createbus";

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => commandParser.ParseParameters(string.Empty));
        }
    }
}
