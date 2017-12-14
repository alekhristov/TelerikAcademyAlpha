using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shapes
{
    class Square : IShape
    {
        public Square(double width)
        {
            this.Width = width;
            this.Height = width;
        }

        public double Width { get; }

        public double Height { get; }

        public double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
