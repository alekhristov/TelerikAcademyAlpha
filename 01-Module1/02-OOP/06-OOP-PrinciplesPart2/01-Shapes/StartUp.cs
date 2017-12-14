using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shapes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ICollection<IShape> listOfShapes = new List<IShape>()
            {
                new Rectangle(4, 5),
                new Triangle(6, 3),
                new Square(4)
            };

            foreach (var shape in listOfShapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
