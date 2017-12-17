using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.LectureResources
{
    class VideoResource : LectureResource
    {
        private DateTime uploadedOn;

        public VideoResource(string name, string url) : base(name, url)
        {
            this.Type = "Video";
        }

        public DateTime UploadedOn
        {
            get
            {
                return this.uploadedOn;
            }
            private set
            {
                this.uploadedOn = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"     - Uploaded on: {this.UploadedOn}");

            return sb.ToString().TrimEnd();
        }
    }
}
