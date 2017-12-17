using Academy.Models.Contracts;
using System;
using System.Text;

namespace Academy.Models.LectureResources
{
    abstract class LectureResource : ILectureResource
    {
        private string name;
        private string url;
        private string type;

        public LectureResource(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 3 || value.Length > 15) throw new ArgumentException("Resource name should be between 3 and 15 symbols long!");
                this.name = value ?? throw new ArgumentNullException("You must enter a name!");
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                if (value.Length < 5 || value.Length > 150) throw new ArgumentException("Resource url should be between 5 and 150 symbols long!");
                this.url = value ?? throw new ArgumentNullException("You must enter a URL!");
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            protected set
            {
                this.type = value ?? throw new ArgumentNullException("You must enter a resource type!");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("    * Resource:");
            sb.AppendLine($"     - Name: {this.Name}");
            sb.AppendLine($"     - Url: {this.Url}");
            sb.AppendLine($"     - Type: {this.Type}");

            return sb.ToString().TrimEnd();
        }
    }
}
