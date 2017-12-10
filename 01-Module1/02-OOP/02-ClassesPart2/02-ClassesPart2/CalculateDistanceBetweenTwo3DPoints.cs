using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClassesPart2
{
    static class CalculateDistanceBetweenTwo3DPoints
    {
        internal static long CalculateDistanceBetweenTwoPoints(Point3D point1, Point3D point2)
        {
            var dimension1 = (int)Math.Pow((point1.X - point2.X), 2);
            var dimension2 = (int)Math.Pow((point1.Y - point2.Y), 2);
            var dimension3 = (int)Math.Pow((point1.Z - point2.Z), 2);

            return (long)Math.Sqrt(dimension1 + dimension2 + dimension3);
        }
    }
}
