using System;
using System.Linq;

namespace _04_TheRingsOfTheAcademy
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var rings = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                int element = int.Parse(Console.ReadLine());
                rings[element]++;
            }

            var factorials = new long[rings.Max() + 1];
            factorials[0] = 1;

            for (int i = 1; i < factorials.Length; i++)
            {
                factorials[i] = factorials[i - 1] * i;
            }

            long total = 1;
            for (int i = 1; i < rings.Length; i++)
            {
                total *= factorials[rings[i]];
            }

            Console.WriteLine(total);
        }
    }
}
