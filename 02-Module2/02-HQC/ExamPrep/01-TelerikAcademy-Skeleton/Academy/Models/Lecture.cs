using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Models.Contracts
{
    class Lecture : ILecture
    {
        private string name;
        private DateTime date;
        private ITrainer trainer;
        private IList<ILectureResource> resources;

        public Lecture(string name, DateTime date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = date;
            this.Trainer = trainer;
            this.Resources = new List<ILectureResource>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length < 5 || value.Length > 30) throw new ArgumentException("Lecture's name should be between 5 and 30 symbols long!");
                this.name = value ?? throw new ArgumentNullException("You must enter a name!");
            }
        }

        public DateTime Date
        {
            get { return this.date; }
            set
            {
                this.date = value;
            }
        }

        public ITrainer Trainer
        {
            get { return this.trainer; }
            set
            {
                this.trainer = value;
            }
        }

        public IList<ILectureResource> Resources
        {
            get { return this.resources; }
            private set
            {
                this.resources = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("  * Lecture:");
            sb.AppendLine($"   - Name: {this.Name}");
            sb.AppendLine($"   - Date: {this.Date}");
            sb.AppendLine($"   - Trainer username: {this.Trainer.Username}");
            sb.AppendLine("   - Resources:");

            if (!this.Resources.Any())
            {
                sb.AppendLine("    * There are no resources in this lecture.");
            }
            else
            {
                foreach (var resource in this.Resources)
                {
                    sb.AppendLine(resource.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
