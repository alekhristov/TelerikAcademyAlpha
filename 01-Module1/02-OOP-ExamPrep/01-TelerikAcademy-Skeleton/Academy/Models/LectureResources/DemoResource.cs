using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.LectureResources
{
    class DemoResource : LectureResource
    {
        public DemoResource(string name, string url) : base(name, url)
        {
            this.Type = "Demo";
        }

    }
}
