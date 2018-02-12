using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;
using System;
using System.Collections.Generic;
using Academy.Models.LectureResources;

namespace Academy.Core.Factories
{
    public class AcademyFactory : IAcademyFactory
    {
        public AcademyFactory()
        {
        }

        public ISeason CreateSeason(string startingYear, string endingYear, string initiative)
        {
            var parsedStartingYear = int.Parse(startingYear);
            var parsedEngingYear = int.Parse(endingYear);

            Initiative parsedInitiativeAsEnum;
            Enum.TryParse<Initiative>(initiative, out parsedInitiativeAsEnum);

            return new Season(parsedStartingYear, parsedEngingYear, parsedInitiativeAsEnum);
        }

        public IStudent CreateStudent(string username, string track)
        {
            return new Student(username, (Track)Enum.Parse(typeof(Track), track));
        }

        public ITrainer CreateTrainer(string username, string technologies)
        {
            IList<string> listOfTechnologies = technologies.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return new Trainer(username, listOfTechnologies);
        }

        public ICourse CreateCourse(string name, string lecturesPerWeek, string startingDate)
        {
            return new Course(name, int.Parse(lecturesPerWeek), DateTime.Parse(startingDate));
        }

        public ILecture CreateLecture(string name, string date, ITrainer trainer)
        {
            return new Lecture(name, DateTime.Parse(date), trainer);
        }

        public ILectureResource CreateLectureResource(string type, string name, string url)
        {
            var currentDate = DateTimeProvider.Now;

            switch (type)
            {
                case "video": return new VideoResource(name, url, currentDate);
                case "presentation": return new PresentationResource(name, url);
                case "demo": return new DemoResource(name, url);
                case "homework": return new HomeworkResource(name, url, currentDate);

                default: throw new ArgumentException("Invalid lecture resource type");
            }
        }

        public ICourseResult CreateCourseResult(ICourse course, string examPoints, string coursePoints)
        {
            return new CourseResult(course, float.Parse(examPoints), float.Parse(coursePoints));
        }
    }
}
