using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClassesPart2
{
    static class PathStorage
    {
        internal static void Save(List<Point3D> listOf3DPoints)
        {
            using (var writer = new StreamWriter("../../../3DPoints.txt"))
            {
                foreach (var point in listOf3DPoints)
                {
                    writer.WriteLine($"{point.X}, {point.Y}, {point.Z}");
                }
            }
        }

        internal static void Load(List<Point3D> listOf3DPoints)
        {
            using (var reader = new StreamReader("../../../3DPoints.txt"))
            {
                Console.Write(reader.ReadToEnd());
            }
        }
    }
}
