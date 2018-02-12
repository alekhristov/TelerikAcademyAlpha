using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Traveller.Commands.Creating;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.UnitTests.Commands.Creating.CreateJourneyCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateJourney_WhenInvokedWithValidParameters()
        {
            // Arrange
            var vehiclesIndex = 1;
            var startLocation = "Sofia";
            var destination = "Burgas";
            var distance = 400;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstVehicleMock = new Mock<IVehicle>();
            var secondVehicleMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstVehicleMock.Object, secondVehicleMock.Object };
            var journeyMock = new Mock<IJourney>();
            var journeys = new List<IJourney>() { journeyMock.Object };

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            databaseMock
                .SetupGet(m => m.Journeys)
                .Returns(journeys);

            var parameters = new List<string>() { startLocation, destination, distance.ToString(), vehiclesIndex.ToString() };
            var journeyCommand = new CreateJourneyCommand(factoryMock.Object, databaseMock.Object);

            // Act
            journeyCommand.Execute(parameters);

            // Assert
            factoryMock.Verify(m => m.CreateJourney(startLocation, destination, distance, secondVehicleMock.Object), Times.Once);
        }

        [TestMethod]
        public void AddJourneyToDatabase_WhenInvokedWithValidParameters()
        {
            // Arrange
            var vehiclesIndex = 1;
            var startLocation = "Sofia";
            var destination = "Burgas";
            var distance = 400;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstVehicleMock = new Mock<IVehicle>();
            var secondVehicleMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstVehicleMock.Object, secondVehicleMock.Object };
            var firstJourneyMock = new Mock<IJourney>();
            var secondJourneyMock = new Mock<IJourney>();
            var journeys = new List<IJourney>() { firstJourneyMock.Object };

            factoryMock
                .Setup(m => m.CreateJourney(startLocation, destination, distance, secondVehicleMock.Object))
                .Returns(secondJourneyMock.Object);

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            databaseMock
                .SetupGet(m => m.Journeys)
                .Returns(journeys);


            var parameters = new List<string>() { startLocation, destination, distance.ToString(), vehiclesIndex.ToString() };
            var journeyCommand = new CreateJourneyCommand(factoryMock.Object, databaseMock.Object);

            // Act
            journeyCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(2, databaseMock.Object.Journeys.Count);
            Assert.AreSame(secondJourneyMock.Object, databaseMock.Object.Journeys[vehiclesIndex]);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var vehiclesIndex = 1;
            var startLocation = "Sofia";
            var destination = "Burgas";
            var distance = 400;
            var expectedResult = $"Journey with ID 1 was created.";

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstVehicleMock = new Mock<IVehicle>();
            var secondVehicleMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstVehicleMock.Object, secondVehicleMock.Object };
            var firstJourneyMock = new Mock<IJourney>();
            var secondJourneyMock = new Mock<IJourney>();
            var journeys = new List<IJourney>() { firstJourneyMock.Object };

            factoryMock
                .Setup(m => m.CreateJourney(startLocation, destination, distance, secondVehicleMock.Object))
                .Returns(secondJourneyMock.Object);

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            databaseMock
                .SetupGet(m => m.Journeys)
                .Returns(journeys);


            var parameters = new List<string>() { startLocation, destination, distance.ToString(), vehiclesIndex.ToString() };
            var journeyCommand = new CreateJourneyCommand(factoryMock.Object, databaseMock.Object);

            // Act
            var actualResult = journeyCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidVehicleIndexParameter()
        {
            // Arrange
            var vehiclesIndex = 2;
            var startLocation = "Sofia";
            var destination = "Burgas";
            var distance = 400;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstVehicleMock = new Mock<IVehicle>();
            var secondVehicleMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstVehicleMock.Object, secondVehicleMock.Object };

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { startLocation, destination, distance.ToString(), vehiclesIndex.ToString() };
            var journeyCommand = new CreateJourneyCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => journeyCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithNullStartLocationParameter()
        {
            // Arrange
            var vehiclesIndex = 2;
            //var startLocation = "Sofia";
            var destination = "Burgas";
            var distance = 400;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstVehicleMock = new Mock<IVehicle>();
            var secondVehicleMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstVehicleMock.Object, secondVehicleMock.Object };

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { null, destination, distance.ToString(), vehiclesIndex.ToString() };
            var journeyCommand = new CreateJourneyCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => journeyCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyStartLocationParameter()
        {
            // Arrange
            var vehiclesIndex = 2;
            //var startLocation = "Sofia";
            var destination = "Burgas";
            var distance = 400;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstVehicleMock = new Mock<IVehicle>();
            var secondVehicleMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstVehicleMock.Object, secondVehicleMock.Object };

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { string.Empty, destination, distance.ToString(), vehiclesIndex.ToString() };
            var journeyCommand = new CreateJourneyCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => journeyCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyDestinationParameter()
        {
            // Arrange
            var vehiclesIndex = 2;
            var startLocation = "Sofia";
            //var destination = "Burgas";
            var distance = 400;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstVehicleMock = new Mock<IVehicle>();
            var secondVehicleMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstVehicleMock.Object, secondVehicleMock.Object };

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { startLocation, string.Empty, distance.ToString(), vehiclesIndex.ToString() };
            var journeyCommand = new CreateJourneyCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => journeyCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithNullDestinationParameter()
        {
            // Arrange
            var vehiclesIndex = 2;
            var startLocation = "Sofia";
            //var destination = "Burgas";
            var distance = 400;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstVehicleMock = new Mock<IVehicle>();
            var secondVehicleMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstVehicleMock.Object, secondVehicleMock.Object };

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { startLocation, null, distance.ToString(), vehiclesIndex.ToString() };
            var journeyCommand = new CreateJourneyCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => journeyCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidDistanceParameter()
        {
            // Arrange
            var vehiclesIndex = 2;
            var startLocation = "Sofia";
            var destination = "Burgas";
            var distance = "Sup?";

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstVehicleMock = new Mock<IVehicle>();
            var secondVehicleMock = new Mock<IVehicle>();
            var vehicles = new List<IVehicle>() { firstVehicleMock.Object, secondVehicleMock.Object };

            databaseMock
                .SetupGet(m => m.Vehicles)
                .Returns(vehicles);

            var parameters = new List<string>() { startLocation, destination, distance, vehiclesIndex.ToString() };
            var journeyCommand = new CreateJourneyCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => journeyCommand.Execute(parameters));
        }
    }
}
