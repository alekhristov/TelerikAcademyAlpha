using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClassesPart2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var point0 = Point3D.Point0;
            var point1 = new Point3D(2, 4, 5);
            
            //Calculating distance between two 3D points
            Console.WriteLine($"Distance between 2 points: {CalculateDistanceBetweenTwo3DPoints.CalculateDistanceBetweenTwoPoints(point0, point1)}");
            Console.Write(point1.ToString());

            Path.ListOf3DPoints.Add(point0);
            Path.ListOf3DPoints.Add(point1);

            //Testing Save & Load Methods
            PathStorage.Save(Path.ListOf3DPoints);
            PathStorage.Load(Path.ListOf3DPoints);

            //Testing Add Method
            var genericList = new GenericList<int>();
            genericList.Add(2);
            genericList.Add(3);
            genericList.Add(4);

            //Testing Indexes and Access Methods
            Console.WriteLine(genericList[2]);
            Console.WriteLine(genericList.AccessElementAt(2));

            //Testing ToString and Min/Max Methods
            Console.Write(genericList.ToString());
            Console.WriteLine(genericList.Max(2, 5));

            var matrix1 = new Matrix<int>(4, 4);
            var matrix2 = new Matrix<int>(4, 4);

            matrix1[0, 0] = 1;
            matrix2[0, 0] = 2;

            //Testing overloading of + operator
            var newMatrix = matrix1 + matrix2;
            Console.WriteLine(newMatrix[0, 0]);

            //Testing overloading of - operator
            newMatrix = matrix2 - matrix1;
            Console.WriteLine(newMatrix[0, 0]);
            
            //Testing overloading of * operator
            newMatrix = matrix1 * matrix2;
            Console.WriteLine(newMatrix[0, 0]);
        }
    }
}
