using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;

namespace Academy.Models
{
    public class Student : IStudent
    {
        private string username;
        private Track track;
        private IList<ICourseResult> courseResults;

        public Student(string username, Track track)
        {
            this.Username = username;
            this.Track = track;
            this.CourseResults = new List<ICourseResult>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("You must enter a username!");
                if (value.Length < 3 || value.Length > 16) throw new ArgumentException("User's username should be between 3 and 16 symbols long!");
                this.username = value;
            }
        }

        public Track Track
        {
            get
            {
                return this.track;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Track), value)) throw new ArgumentException("The provided track is not valid!");
                this.track = value;
            }
        }

        public IList<ICourseResult> CourseResults
        {
            get
            {
                return this.courseResults;
            }

            set
            {
                this.courseResults = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("* Student:");
            sb.AppendLine($" - Username: {this.Username}");
            sb.AppendLine($" - Track: {this.Track}");
            sb.AppendLine(" - Course results:");

            if (!CourseResults.Any())
            {
                sb.AppendLine("  * User has no course results!");
            }
            else
            {
                foreach (var courseResult in CourseResults)
                {
                    sb.AppendLine(courseResult.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
