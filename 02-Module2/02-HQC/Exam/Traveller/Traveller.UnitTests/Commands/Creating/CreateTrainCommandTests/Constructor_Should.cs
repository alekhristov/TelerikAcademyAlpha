using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.UnitTests.Commands.Creating.CreateTrainCommandTests
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
            var createTrainCommand = new CreateTrainCommand(factoryMock.Object, databaseMock.Object);

            // Assert
            Assert.IsNotNull(createTrainCommand);
            Assert.IsInstanceOfType(createTrainCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullTravellerFactoryParameter()
        {
            // Arrange
            //var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateTrainCommand(null, databaseMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullDatabaseParameter()
        {
            // Arrange
            var factoryMock = new Mock<ITravellerFactory>();
            //var databaseMock = new Mock<IDatabase>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateTrainCommand(factoryMock.Object, null));
        }
    }
}
