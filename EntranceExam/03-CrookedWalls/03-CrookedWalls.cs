using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CrookedWalls
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(a => long.Parse(a)).ToArray();
            var listResult = new List<long>();
            long evenSum = 0;

            for (int i = 1; i < input.Length; i++)
            {
                var greaterNumber = Math.Max(input[i], input[i - 1]);
                var smallerNumber = Math.Min(input[i], input[i - 1]);
                var difference = Math.Abs(greaterNumber - smallerNumber);

                if (difference % 2 != 0)
                {
                    if (i == 1)
                    {
                        listResult.Add(input[i - 1]);
                        listResult.Add(input[i]);
                    }
                    else
                    {
                        listResult.Add(input[i]);
                    }
                }
                else
                {
                    evenSum += difference;
                    i++;
                }
            }
            Console.WriteLine(evenSum);
        }
    }
}
