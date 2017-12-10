using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClassesPart2
{
    struct Point3D
    {
        private static readonly Point3D point0 = new Point3D(0, 0, 0);  

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        internal static Point3D Point0 => point0;

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"3D-coordinate {{{X}, {Y}, {Z}}}");

            return sb.ToString();   
        }
    }
}
