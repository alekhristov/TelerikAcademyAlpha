using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;
using System;

namespace Academy.Models
{
    class CourseResult : ICourseResult
    {
        private ICourse course;
        private float examPoints;
        private float coursePoints;
        private Grade grade;

        public CourseResult(ICourse course, float examPoints, float coursePoints)
        {
            this.Course = course;
            this.ExamPoints = examPoints;
            this.CoursePoints = coursePoints;

            if (this.ExamPoints >= 65 || this.CoursePoints >= 75)
            {
                this.Grade = Grade.Excellent;
            }
            else if (this.ExamPoints < 30 || this.CoursePoints < 45)
            {
                this.Grade = Grade.Failed;
            }
            else if (this.ExamPoints < 60 || this.CoursePoints < 75)
            {
                this.Grade = Grade.Passed;
            }
        }

        public ICourse Course
        {
            get { return this.course; }
            private set
            {
                this.course = value ?? throw new ArgumentNullException("You must enter a course!");
            }
        }

        public float ExamPoints
        {
            get { return this.examPoints; }
            private set
            {
                if (value < 0 || value > 1000) throw new ArgumentException("Course result's exam points should be between 0 and 1000!");
                this.examPoints = value;
            }
        }

        public float CoursePoints
        {
            get { return this.coursePoints; }
            private set
            {
                if (value < 0 || value > 125) throw new ArgumentException("Course result's course points should be between 0 and 125!");
                this.coursePoints = value;
            }
        }

        public Grade Grade
        {
            get { return this.grade; }
            private set
            {
                if (!Enum.IsDefined(typeof(Grade), value)) throw new ArgumentException("The provided grade is not valid!");
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return $"  * {this.Course.Name}: Points - {this.CoursePoints}, Grade - {this.Grade}";
        }
    }
}