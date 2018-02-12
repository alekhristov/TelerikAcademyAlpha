using Agency.Commands.Creating;
using Agency.Core.Contracts;
using Agency.Models.Vehicles.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Agency.Tests.Command.Creating.CreateAirplaneCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnCorrectMessage_WhenInvokedWithCorrectData()
        {
            // Arrange
            var expectedMessage = "Vehicle with ID 0 was created.";

            var factoryMock = new Mock<IAgencyFactory>();
            var engineMock = new Mock<IEngine>();

            var parameters = new List<string>()
            {
                "250",
                "1",
                "true"
            };

            var sut = new CreateAirplaneCommand(factoryMock.Object, engineMock.Object);

            // act
            var actualMessage = sut.Execute(parameters);

            // assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void GenerateAirplaneFromFactory_WhenInvoked()
        {
            // Arrange
            var pasengerCount = 250;
            var expectedMessage = "Vehicle with ID 0 was created.";

            var factoryMock = new Mock<IAgencyFactory>();
            var engineMock = new Mock<IEngine>();

            engineMock.SetupGet(x => x.Vehicles).Returns(new List<IVehicle>());

            var parameters = new List<string>()
            {
                pasengerCount.ToString(),
                "1",
                "true"
            };

            var sut = new CreateAirplaneCommand(factoryMock.Object, engineMock.Object);

            // act
            var actualMessage = sut.Execute(parameters);

            // assert
            factoryMock.Verify(x => x.CreateAirplane(pasengerCount, 1, true), Times.Once);
        }

        [TestMethod]
        public void AddAirplaneToEngine_WhenInvoked()
        {
            // Arrange
            var factoryMock = new Mock<IAgencyFactory>();
            var engineMock = new Mock<IEngine>();
            var airplaneMock = new Mock<IAirplane>();
            var vehiclesList = new List<IVehicle>();

            factoryMock.Setup(x => x.CreateAirplane(250, 1, It.IsAny<bool>())).Returns(airplaneMock.Object);
            engineMock.SetupGet(x => x.Vehicles).Returns(vehiclesList);

            var parameters = new List<string>()
            {
                "250",
                "1",
                "true"
            };

            var sut = new CreateAirplaneCommand(factoryMock.Object, engineMock.Object);

            // act
            var actualMessage = sut.Execute(parameters);

            // assert
            Assert.IsTrue(vehiclesList.Contains(airplaneMock.Object));
        }
    }
}
