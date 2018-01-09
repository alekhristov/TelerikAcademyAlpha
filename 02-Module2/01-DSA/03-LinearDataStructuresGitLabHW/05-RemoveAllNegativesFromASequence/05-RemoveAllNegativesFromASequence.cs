using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_RemoveAllNegativesFromASequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = new List<int>() { -1, 2, -2, -3, 4, -4, -4, 5, -5, 5, -5, 6, -6 };

            Console.WriteLine(string.Join(" ", sequence.Where(n => n > 0)));
        }
    }
}
