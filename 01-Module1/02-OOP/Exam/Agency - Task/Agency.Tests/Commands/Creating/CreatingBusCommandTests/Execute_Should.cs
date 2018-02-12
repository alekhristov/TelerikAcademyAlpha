using Agency.Commands.Creating;
using Agency.Core.Contracts;
using Agency.Models.Vehicles.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Agency.Tests.Commands.Creating.CreatingBusCommandTests
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

            var bus = new CreateBusCommand(factoryMock.Object, engineMock.Object);
            var parameters = new List<string>()
            {
                "10",
                "0.7"
            };

            // Act
            var actualMessage = bus.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void SaveObjectToEngine_WhenInvoked()
        {
            // Arrange
            var factoryMock = new Mock<IAgencyFactory>();
            factoryMock.Setup(x => x.CreateBus(It.IsAny<int>(), It.IsAny<int>())).Verifiable();
            var engineMock = new Mock<IEngine>();
            engineMock.SetupGet(x => x.Vehicles).Returns(new List<IVehicle>());

            var bus = new CreateBusCommand(factoryMock.Object, engineMock.Object);
            var parameters = new List<string>()
            {
                "10",
                "0.7"
            };

            // Act
            var actualMessage = bus.Execute(parameters);

            // Assert
            factoryMock.Verify(x => x.CreateBus(10, 0.7m), Times.Once);
        }

        [TestMethod]
        public void AddBusToEngine_WhenInvoked()
        {
            // Arrange
            var factoryMock = new Mock<IAgencyFactory>();
            var engineMock = new Mock<IEngine>();
            var busMock = new Mock<IBus>();
            var vehicles = new List<IVehicle>();

            factoryMock.Setup(x => x.CreateBus(10, 0.7m)).Returns(busMock.Object);
            engineMock.SetupGet(x => x.Vehicles).Returns(vehicles);

            var bus = new CreateBusCommand(factoryMock.Object, engineMock.Object);
            var parameters = new List<string>()
            {
                "10",
                "0.7"
            };

            // Act
            var actualMessage = bus.Execute(parameters);

            // Assert  
            Assert.IsTrue(vehicles.Contains(busMock.Object));
        }
    }
}
