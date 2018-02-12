using System;

namespace _08_Flies
{
    class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public override string ToString()
        {
            return string.Format("{0:F4} {1:F4}",this.X, this.Y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var firstFly = Console.ReadLine().Split(' ');
            var A = new Point(double.Parse(firstFly[0]), double.Parse(firstFly[1]));

            var secondFly = Console.ReadLine().Split(' ');
            var B = new Point(double.Parse(secondFly[0]), double.Parse(secondFly[1]));

            var thirdFly = Console.ReadLine().Split(' ');
            var C = new Point(double.Parse(thirdFly[0]), double.Parse(thirdFly[1]));

            double yDelta_a = B.Y - A.Y;
            double xDelta_a = B.X - A.X;
            double yDelta_b = C.Y - B.Y;
            double xDelta_b = C.X - B.X;

            double aSlope = yDelta_a / xDelta_a;
            double bSlope = yDelta_b / xDelta_b;

            var center = new Point(0, 0);
            center.X = (aSlope * bSlope * (A.Y - C.Y) + bSlope * (A.X + B.X)
                        - aSlope * (B.X + C.X)) / (2 * (bSlope - aSlope));
            center.Y = -1 * (center.X - (A.X + B.X) / 2) / aSlope + (A.Y + B.Y) / 2;

            Console.WriteLine(center);
        }
    }
}
