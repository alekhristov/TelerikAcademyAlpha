using System;
using System.Linq;

namespace _02_DancingMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            long sum = 0;
            var startPosition = 0;
            var counter = 0;

            while (true)
            {
                var token = Console.ReadLine().Split().ToArray();

                if (token[0] == "stop")
                {
                    break;
                }

                var times = int.Parse(token[0]);
                var direction = token[1];
                var step = int.Parse(token[2]);

                if (direction == "right")
                {
                    for (int i = 0; i < times; i++)
                    {
                        startPosition += step;

                        while (startPosition > input.Length - 1)
                        {
                            startPosition -= input.Length;
                        }
                        sum += input[startPosition];
                    }
                }
                else if (direction == "left")
                {
                    for (int i = 0; i < times; i++)
                    {
                        startPosition -= step;

                        while (startPosition < 0)
                        {
                            startPosition += input.Length;
                        }
                        sum += input[startPosition];
                    }
                }
                counter++;
            }
            decimal result = (decimal)sum / counter;
            Console.WriteLine("{0:f1}", result);
        }
    }
}