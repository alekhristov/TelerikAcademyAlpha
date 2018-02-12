using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Traveller.Commands.Creating;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.UnitTests.Commands.Creating.CreateTrainCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateAirplane_WhenInvokedWithValidParameters()
        {
            // Arrange
            var passengerCapacity = 30;
            var pricePerKm = 1.5m;
            var cartsCount = 5;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstTrainMock = new Mock<IVehicle>();
            var secondTrainMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstTrainMock.Object };

            factoryMock
                .Setup(m => m.CreateTrain(passengerCapacity, pricePerKm, cartsCount))
                .Returns(secondTrainMock.Object);

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString(), cartsCount.ToString() };
            var trainCommand = new CreateTrainCommand(factoryMock.Object, databaseMock.Object);

            // Act
            trainCommand.Execute(parameters);

            // Assert
            factoryMock.Verify(m => m.CreateTrain(passengerCapacity, pricePerKm, cartsCount), Times.Once);
        }

        [TestMethod]
        public void AddTrainToDatabase_WhenInvokedWithValidParameters()
        {
            // Arrange
            var passengerCapacity = 30;
            var pricePerKm = 1.5m;
            var cartsCount = 5;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstTrainMock = new Mock<IVehicle>();
            var secondTrainMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstTrainMock.Object };

            factoryMock
                .Setup(m => m.CreateTrain(passengerCapacity, pricePerKm, cartsCount))
                .Returns(secondTrainMock.Object);

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString(), cartsCount.ToString() };
            var trainCommand = new CreateTrainCommand(factoryMock.Object, databaseMock.Object);

            // Act
            trainCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(2, databaseMock.Object.Vehicles.Count);
            Assert.AreSame(secondTrainMock.Object, databaseMock.Object.Vehicles[1]);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var passengerCapacity = 30;
            var pricePerKm = 1.5m;
            var cartsCount = 5;
            var expectedMessage = $"Vehicle with ID 1 was created.";

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var trainMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { trainMock.Object };

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString(), cartsCount.ToString() };
            var trainCommand = new CreateTrainCommand(factoryMock.Object, databaseMock.Object);

            // Act
            var actualMessage = trainCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidPassengerCapacityParameter()
        {
            // Arrange
            var passengerCapacity = "hi";
            var pricePerKm = 1.5m;
            var cartsCount = 5;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString(), cartsCount.ToString() };
            var trainCommand = new CreateTrainCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => trainCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidPricePerKmParameter()
        {
            // Arrange
            var passengerCapacity = 30;
            var pricePerKm = "hi";
            var cartsCount = 5;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString(), cartsCount.ToString() };
            var trainCommand = new CreateTrainCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => trainCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidHasFreeFoodParameter()
        {
            // Arrange
            var passengerCapacity = 300;
            var pricePerKm = 1.5m;
            var cartsCount = "hi";

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString(), cartsCount };
            var trainCommand = new CreateTrainCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => trainCommand.Execute(parameters));
        }
    }
}
