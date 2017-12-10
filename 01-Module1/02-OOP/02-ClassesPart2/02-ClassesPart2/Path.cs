using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClassesPart2
{
   class Path
    {
        private static readonly List<Point3D> listof3DPoints;

        static Path()
        {
            Path.listof3DPoints = new List<Point3D>();
        }

        internal static List<Point3D> ListOf3DPoints
        {
            get
            {
                return Path.listof3DPoints;
            }
        }
    }
}
