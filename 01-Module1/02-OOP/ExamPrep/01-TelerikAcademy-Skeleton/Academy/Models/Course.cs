using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Models
{
    class Course : ICourse
    {
        private string name;
        private int lecturesPerWeek;
        private DateTime startingDate;
        private DateTime endingDate;
        private IList<IStudent> onsiteStudents;
        private IList<IStudent> onlineStudents;
        private IList<ILecture> lectures;

        public Course(string name, int lecturesPerWeek, DateTime startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = lecturesPerWeek;
            this.StartingDate = startingDate;
            this.EndingDate = StartingDate.AddDays(30);
            this.OnsiteStudents = new List<IStudent>();
            this.OnlineStudents = new List<IStudent>();
            this.Lectures = new List<ILecture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 3 || value.Length > 45) throw new ArgumentException("The name of the course must be between 3 and 45 symbols!");
                this.name = value ?? throw new ArgumentNullException("You must enter a name!");
            }
        }
        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }
            set
            {
                if (value < 1 || value > 7) throw new ArgumentException("The number of lectures per week must be between 1 and 7!");
                this.lecturesPerWeek = value;
            }
        }
        public DateTime StartingDate
        {
            get
            {
                return this.startingDate;
            }
            set
            {
                this.startingDate = value;
            }
        }
        public DateTime EndingDate
        {
            get
            {
                return this.endingDate;
            }
            set
            {
                this.endingDate = value;
            }
        }
        public IList<IStudent> OnsiteStudents
        {
            get
            {
                return this.onsiteStudents;
            }
            protected set
            {
                this.onsiteStudents = value;
            }
        }
        public IList<IStudent> OnlineStudents
        {
            get
            {
                return this.onlineStudents;
            }
            protected set
            {
                this.onlineStudents = value;
            }
        }
        public IList<ILecture> Lectures
        {
            get
            {
                return this.lectures;
            }
            protected set
            {
                this.lectures = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("* Course");
            sb.AppendLine($" - Name: {this.Name}");
            sb.AppendLine($" - Lectures per week: {this.LecturesPerWeek}");
            sb.AppendLine($" - Starting date: {this.StartingDate}");
            sb.AppendLine($" - Ending date: {this.EndingDate}");
            sb.AppendLine($" - Onsite students: {this.OnsiteStudents.Count}");
            sb.AppendLine($" - Online students: {this.OnlineStudents.Count}");
            sb.AppendLine(" - Lectures:");
            if (!this.Lectures.Any())
            {
                sb.AppendLine("  * There are no lectures in this course!");
            }
            else
            {
                foreach (var lecture in this.Lectures)
                {
                    sb.AppendLine(lecture.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
