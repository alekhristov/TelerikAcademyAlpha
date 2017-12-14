using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shapes
{
    interface IShape
    {
        double Width { get; }

        double Height { get; }

        double CalculateSurface();
    }
}
