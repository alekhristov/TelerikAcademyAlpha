using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.LectureResources
{
    class PresentationResource : LectureResource
    {
        public PresentationResource(string name, string url) : base(name, url)
        {
            this.Type = "Presentation";
        }
    }
}
