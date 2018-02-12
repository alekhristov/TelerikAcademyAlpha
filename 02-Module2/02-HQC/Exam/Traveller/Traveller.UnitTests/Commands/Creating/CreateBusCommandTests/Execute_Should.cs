using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Traveller.Commands.Creating;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.UnitTests.Commands.Creating.CreateBusCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateBus_WhenInvokedWithValidParameters()
        {
            // Arrange
            var passengerCapacity = 25;
            var pricePerKm = 1.0m;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstBusMock = new Mock<IVehicle>();
            var secondBusMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstBusMock.Object };

            factoryMock
                .Setup(m => m.CreateBus(passengerCapacity, pricePerKm))
                .Returns(secondBusMock.Object);

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString() };
            var busCommand = new CreateBusCommand(factoryMock.Object, databaseMock.Object);

            // Act
            busCommand.Execute(parameters);

            // Assert
            factoryMock.Verify(m => m.CreateBus(passengerCapacity, pricePerKm), Times.Once);
        }

        [TestMethod]
        public void AddBusToDatabase_WhenInvokedWithValidParameters()
        {
            // Arrange
            var passengerCapacity = 25;
            var pricePerKm = 1.0m;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstBusMock = new Mock<IVehicle>();
            var secondBusMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstBusMock.Object };

            factoryMock
                .Setup(m => m.CreateBus(passengerCapacity, pricePerKm))
                .Returns(secondBusMock.Object);

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString() };
            var busCommand = new CreateBusCommand(factoryMock.Object, databaseMock.Object);

            // Act
            busCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(2, databaseMock.Object.Vehicles.Count);
            Assert.AreSame(secondBusMock.Object, databaseMock.Object.Vehicles[1]);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var passengerCapacity = 25;
            var pricePerKm = 1.0m;
            var expectedMessage = $"Vehicle with ID 1 was created.";

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var busMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { busMock.Object };

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString() };
            var busCommand = new CreateBusCommand(factoryMock.Object, databaseMock.Object);

            // Act
            var actualMessage = busCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidPassengerCapacityParameter()
        {
            // Arrange
            var passengerCapacity = "hi";
            var pricePerKm = 1.0m;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString() };
            var busCommand = new CreateBusCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => busCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidPricePerKmParameter()
        {
            // Arrange
            var passengerCapacity = 25;
            var pricePerKm = "hi";

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString() };
            var busCommand = new CreateBusCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => busCommand.Execute(parameters));
        }
    }
}
