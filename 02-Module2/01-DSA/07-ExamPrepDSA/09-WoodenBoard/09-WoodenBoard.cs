using System;

namespace _09_WoodenBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var resultFront = 0;
            var resultBack = 0;

            var i = input.Length - 1;
            var j = 0;

            while (j != i && j < input.Length && i >= 0)
            {
                var start = input[j];
                var end = input[i];

                if (start != end)
                {
                    resultFront++;
                    i--;
                }
                else
                {
                    j++;
                    i--;
                }
            }

            if (resultFront == 0)
            {
                Console.WriteLine(0);
                return;
            }

            i = input.Length - 1;
            j = 0;
            while (j != i && j < input.Length && i >= 0)
            {
                var start = input[j];
                var end = input[i];

                if (start != end)
                {
                    resultBack++;
                    j++;
                }
                else
                {
                    j++;
                    i--;
                }
            }

            Console.WriteLine(Math.Min(resultFront, resultBack));
        }
    }
}
