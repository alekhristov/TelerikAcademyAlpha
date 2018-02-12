﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.UnitTests.Commands.Creating.CreateBusCommandTests
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
            var createBusCommand = new CreateBusCommand(factoryMock.Object, databaseMock.Object);

            // Assert
            Assert.IsNotNull(createBusCommand);
            Assert.IsInstanceOfType(createBusCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullTravellerFactoryParameter()
        {
            // Arrange
            //var factoryMock = new Mock<ITravellerFactory>();
            var databaseMock = new Mock<IDatabase>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateBusCommand(null, databaseMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullDatabaseParameter()
        {
            // Arrange
            var factoryMock = new Mock<ITravellerFactory>();
            //var databaseMock = new Mock<IDatabase>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CreateBusCommand(factoryMock.Object, null));
        }
    }
}