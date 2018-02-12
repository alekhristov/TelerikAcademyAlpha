using Academy.Commands.Creating;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Academy.UnitTests.Commands.Creating.CreateCourseCommanTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateCourseAndAddItToDatabase_WhenParametersAreCorrect()
        {
            // Arrange
            var courseName = "C#HQC";
            var lecturesPerWeek = "4";
            var startDate = "2018-01-02";

            var factoryMock = new Mock<IAcademyFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstSeasonMock = new Mock<ISeason>();
            var secondSeasonMock = new Mock<ISeason>();
            var courseMock = new Mock<ICourse>();
            var seasons = new List<ISeason>() { firstSeasonMock.Object, secondSeasonMock.Object };
            var courses = new List<ICourse>();

            databaseMock
                .SetupGet(m => m.Seasons)
                .Returns(seasons);

            factoryMock
                .Setup(m => m.CreateCourse(courseName, lecturesPerWeek, startDate))
                .Returns(courseMock.Object);

            secondSeasonMock
                .SetupGet(m => m.Courses)
                .Returns(courses);

            var parameters = new List<string>() { "1", courseName, lecturesPerWeek, startDate };
            var command = new CreateCourseCommand(factoryMock.Object, databaseMock.Object);

            // Act
            command.Execute(parameters);

            // Assert
            Assert.AreEqual(1, secondSeasonMock.Object.Courses.Count);
            Assert.AreSame(courseMock.Object, secondSeasonMock.Object.Courses.Single());
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenParametersAreCorrect()
        {
            // Arrange
            var seasonId = "1";
            var courseName = "C#HQC";
            var lecturesPerWeek = "4";
            var startDate = "2018-01-02";

            var factoryMock = new Mock<IAcademyFactory>();
            var databaseMock = new Mock<IDatabase>();
            var firstSeasonMock = new Mock<ISeason>();
            var secondSeasonMock = new Mock<ISeason>();
            var courseMock = new Mock<ICourse>();
            var seasons = new List<ISeason>() { firstSeasonMock.Object, secondSeasonMock.Object };
            var courses = new List<ICourse>();
            var expectedSuccessMessage = $"Course with ID 0 was created in Season {seasonId}.";

            databaseMock
                .SetupGet(m => m.Seasons)
                .Returns(seasons);

            factoryMock
                .Setup(m => m.CreateCourse(courseName, lecturesPerWeek, startDate))
                .Returns(courseMock.Object);

            secondSeasonMock
                .SetupGet(m => m.Courses)
                .Returns(courses);

            var parameters = new List<string>() { "1", courseName, lecturesPerWeek, startDate };
            var command = new CreateCourseCommand(factoryMock.Object, databaseMock.Object);

            // Act
            var actualSuccessMessage = command.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedSuccessMessage, actualSuccessMessage);
        }
    }
}
