using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Traveller.Commands.Creating;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.UnitTests.Commands.Creating.CreateAirplaneCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateAirplane_WhenInvokedWithValidParameters()
        {
            // Arrange
            var passengerCapacity = 150;
            var pricePerKm = 1.5m;
            var hasFreeFood = true;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstAirplaneMock = new Mock<IVehicle>();
            var secondAirplaneMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstAirplaneMock.Object };

            factoryMock
                .Setup(m => m.CreateAirplane(passengerCapacity, pricePerKm, hasFreeFood))
                .Returns(secondAirplaneMock.Object);

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString(), hasFreeFood.ToString() };
            var airplaneCommand = new CreateAirplaneCommand(factoryMock.Object, databaseMock.Object);

            // Act
            airplaneCommand.Execute(parameters);

            // Assert
            factoryMock.Verify(m => m.CreateAirplane(passengerCapacity, pricePerKm, hasFreeFood), Times.Once);
        }

        [TestMethod]
        public void AddAirplaneToDatabase_WhenInvokedWithValidParameters()
        {
            // Arrange
            var passengerCapacity = 150;
            var pricePerKm = 1.5m;
            var hasFreeFood = true;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstAirplaneMock = new Mock<IVehicle>();
            var secondAirplaneMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstAirplaneMock.Object };

            factoryMock
                .Setup(m => m.CreateAirplane(passengerCapacity, pricePerKm, hasFreeFood))
                .Returns(secondAirplaneMock.Object);

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString(), hasFreeFood.ToString() };
            var airplaneCommand = new CreateAirplaneCommand(factoryMock.Object, databaseMock.Object);

            // Act
            airplaneCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(2, databaseMock.Object.Vehicles.Count);
            Assert.AreSame(secondAirplaneMock.Object, databaseMock.Object.Vehicles[1]);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var passengerCapacity = 150;
            var pricePerKm = 1.5m;
            var hasFreeFood = true;
            var expectedMessage = $"Vehicle with ID 1 was created.";

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var airplaneMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { airplaneMock.Object };

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString(), hasFreeFood.ToString() };
            var airplaneCommand = new CreateAirplaneCommand(factoryMock.Object, databaseMock.Object);

            // Act
            var actualMessage = airplaneCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidPassengerCapacityParameter()
        {
            // Arrange
            var passengerCapacity = "hi";
            var pricePerKm = 1.5m;
            var hasFreeFood = true;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString(), hasFreeFood.ToString() };
            var airplaneCommand = new CreateAirplaneCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => airplaneCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidPricePerKmParameter()
        {
            // Arrange
            var passengerCapacity = 150;
            var pricePerKm = "hi";
            var hasFreeFood = true;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString(), hasFreeFood.ToString() };
            var airplaneCommand = new CreateAirplaneCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => airplaneCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidHasFreeFoodParameter()
        {
            // Arrange
            var passengerCapacity = 150;
            var pricePerKm = 1.5m;
            var hasFreeFood = "hi";

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            var parameters = new List<string>() { passengerCapacity.ToString(), pricePerKm.ToString(), hasFreeFood.ToString() };
            var airplaneCommand = new CreateAirplaneCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => airplaneCommand.Execute(parameters));
        }
    }
}
