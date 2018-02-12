using Academy.Commands.Listing;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Academy.UnitTests.Commands.Listing.ListUsersInSeasonCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnMessage_WhenInvokedWithCorrectParameters()
        {
            // Arrange
            var parameters = new List<string>() { "1" };
            var expectedResultMessage = "Users";

            var factoryMock = new Mock<IAcademyFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstSeasonMock = new Mock<ISeason>();
            var secondSeasonMock = new Mock<ISeason>();
            var seasons = new List<ISeason>() { firstSeasonMock.Object, secondSeasonMock.Object };

            databaseMock
                .SetupGet(m => m.Seasons)
                .Returns(seasons);

            secondSeasonMock
                .Setup(m => m.ListUsers())
                .Returns(expectedResultMessage);

            var command = new ListUsersInSeasonCommand(factoryMock.Object, databaseMock.Object);

            // Act
            var actualResultMessage = command.Execute(parameters);

            // Assert
            secondSeasonMock.Verify(m => m.ListUsers(), Times.Once);
            Assert.AreEqual(expectedResultMessage, actualResultMessage);
        }
    }
}
