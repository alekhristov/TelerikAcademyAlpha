using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers;
using Traveller.Core.Providers.Contracts;

namespace Traveller.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameter()
        {
            // Arrange
            var commandFactoryMock = new Mock<ICommandFactory>();

            // Act
            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Assert
            Assert.IsNotNull(commandParser);
            Assert.IsInstanceOfType(commandParser, typeof(ICommandParser));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullCommandFactoryParameter()
        {
            // Arrange
            //var commandFactoryMock = new Mock<ICommandFactory>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CommandParser(null));
        }
    }
}
