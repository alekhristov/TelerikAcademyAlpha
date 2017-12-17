using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.LectureResources
{
    class HomeworkResource : LectureResource
    {
        private DateTime dueDate;

        public HomeworkResource(string name, string url, DateTime creationDate) : base(name, url)
        {
            this.Type = "Homework";
            this.DueDate = creationDate.AddDays(7);
        }

        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
            private set
            {
                this.dueDate = value;
            }
        }

        public override string Print()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.Print());
            sb.AppendLine($"   - Due date: {this.DueDate}");

            return sb.ToString().TrimEnd();
        }
    }
}
