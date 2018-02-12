using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.UnitTests.Commands.Creating.CreateTicketCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreValid()
        {
            // Arrange
            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            // Act
            var createTicketCommand = new CreateTicketCommand(factoryMock.Object, databaseMock.Object);

            // Assert
            Assert.IsNotNull(createTicketCommand);
            Assert.IsInstanceOfType(createTicketCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullTravellerFactoryParameter()
        {
            // Arrange
            //var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(()=> new CreateTicketCommand(null, databaseMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullDatabaseParameter()
        {
            // Arrange
            var factoryMock = new Mock<ITravellerFactory>();
            //var databaseMock = new Mock<IDatabase>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateTicketCommand(factoryMock.Object, null));
        }
    }
}
