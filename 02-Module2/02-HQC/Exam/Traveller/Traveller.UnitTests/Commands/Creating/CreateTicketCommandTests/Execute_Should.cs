using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Traveller.Commands.Creating;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;
using Traveller.Models.Abstractions;

namespace Traveller.UnitTests.Commands.Creating.CreateTicketCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateTicket_WhenInvokedWithValidParameters()
        {
            // Arrange
            var journeyIndex = 1;
            var administrativeCosts = 40.5m;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstJourneyMock = new Mock<IJourney>();
            var secondJourneyMock = new Mock<IJourney>();
            var journeys = new List<IJourney>() { firstJourneyMock.Object, secondJourneyMock.Object };
            var ticketMock = new Mock<ITicket>();
            var tickets = new List<ITicket>() { ticketMock.Object };

            databaseMock
                .SetupGet(m => m.Journeys)
                .Returns(journeys);

            databaseMock
                .SetupGet(m => m.Tickets)
                .Returns(tickets);

            var parameters = new List<string>() { journeyIndex.ToString(), administrativeCosts.ToString() };
            var ticketCommand = new CreateTicketCommand(factoryMock.Object, databaseMock.Object);

            // Act
            ticketCommand.Execute(parameters);

            // Assert
            factoryMock.Verify(m => m.CreateTicket(secondJourneyMock.Object, administrativeCosts), Times.Once);
        }

        [TestMethod]
        public void AddTicketToDatabase_WhenInvokedWithValidParameters()
        {
            // Arrange
            var journeyIndex = 1;
            var administrativeCosts = 40.5m;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstJourneyMock = new Mock<IJourney>();
            var secondJourneyMock = new Mock<IJourney>();
            var journeys = new List<IJourney>() { firstJourneyMock.Object, secondJourneyMock.Object };
            var firstTicketMock = new Mock<ITicket>();
            var secondTicketMock = new Mock<ITicket>();
            var tickets = new List<ITicket>() { firstTicketMock.Object };

            databaseMock
                .SetupGet(m => m.Journeys)
                .Returns(journeys);

            factoryMock
                .Setup(m => m.CreateTicket(secondJourneyMock.Object, administrativeCosts))
                .Returns(secondTicketMock.Object);

            databaseMock
                .SetupGet(m => m.Tickets)
                .Returns(tickets);

            var parameters = new List<string>() { journeyIndex.ToString(), administrativeCosts.ToString() };
            var ticketCommand = new CreateTicketCommand(factoryMock.Object, databaseMock.Object);

            // Act
            ticketCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(2, databaseMock.Object.Tickets.Count);
            Assert.AreSame(secondTicketMock.Object, databaseMock.Object.Tickets[journeyIndex]);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var journeyIndex = 1;
            var administrativeCosts = 40.5m;
            var expectedResult = $"Ticket with ID 1 was created.";

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstJourneyMock = new Mock<IJourney>();
            var secondJourneyMock = new Mock<IJourney>();
            var journeys = new List<IJourney>() { firstJourneyMock.Object, secondJourneyMock.Object };
            var firstTicketMock = new Mock<ITicket>();
            var secondTicketMock = new Mock<ITicket>();
            var tickets = new List<ITicket>() { firstTicketMock.Object };

            databaseMock
                .SetupGet(m => m.Journeys)
                .Returns(journeys);

            factoryMock
                .Setup(m => m.CreateTicket(secondJourneyMock.Object, administrativeCosts))
                .Returns(secondTicketMock.Object);

            databaseMock
                .SetupGet(m => m.Tickets)
                .Returns(tickets);

            var parameters = new List<string>() { journeyIndex.ToString(), administrativeCosts.ToString() };
            var ticketCommand = new CreateTicketCommand(factoryMock.Object, databaseMock.Object);

            // Act
            var actualResult = ticketCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidJourneyIndexParameter()
        {
            // Arrange
            var journeyIndex = 2;
            var administrativeCosts = 40.5m;

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstJourneyMock = new Mock<IJourney>();
            var secondJourneyMock = new Mock<IJourney>();
            var journeys = new List<IJourney>() { firstJourneyMock.Object, secondJourneyMock.Object };

            databaseMock
                .SetupGet(m => m.Journeys)
                .Returns(journeys);

            var parameters = new List<string>() { journeyIndex.ToString(), administrativeCosts.ToString() };
            var ticketCommand = new CreateTicketCommand(factoryMock.Object, databaseMock.Object);
         
            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => ticketCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidAdministrativeCostsParameter()
        {
            // Arrange
            var journeyIndex = 1;
            var administrativeCosts = "Sup?";

            var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstJourneyMock = new Mock<IJourney>();
            var secondJourneyMock = new Mock<IJourney>();
            var journeys = new List<IJourney>() { firstJourneyMock.Object, secondJourneyMock.Object };

            databaseMock
                .SetupGet(m => m.Journeys)
                .Returns(journeys);

            var parameters = new List<string>() { journeyIndex.ToString(), administrativeCosts.ToString() };
            var ticketCommand = new CreateTicketCommand(factoryMock.Object, databaseMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => ticketCommand.Execute(parameters));
        }
    }
}
