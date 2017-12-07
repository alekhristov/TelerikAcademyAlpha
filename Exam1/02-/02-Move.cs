using System;
using System.Linq;

namespace _02_
{
    class Program
    {
        static void Main(string[] args)
        {
            var startPosition = int.Parse(Console.ReadLine());

            var input = Console.ReadLine()
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            long forwardSum = 0;
            long backwardsSum = 0;
            var counter = 0;

            while (true)
            {
                var token = Console.ReadLine().Split().ToArray();

                if (token[0] == "exit")
                {
                    break;
                }

                var times = int.Parse(token[0]);
                var direction = token[1];
                var step = int.Parse(token[2]);

                if (direction == "forward")
                {
                    for (int i = 0; i < times; i++)
                    {
                        startPosition += step;

                        while (startPosition > input.Length - 1)
                        {
                            startPosition -= input.Length;
                        }
                        forwardSum += input[startPosition];
                    }
                }
                else if (direction == "backwards")
                {
                    for (int i = 0; i < times; i++)
                    {
                        startPosition -= step;

                        while (startPosition < 0)
                        {
                            startPosition += input.Length;
                        }
                        backwardsSum += input[startPosition];
                    }
                }
                counter++;
            }
            Console.WriteLine($"Forward: {forwardSum}");
            Console.WriteLine($"Backwards: {backwardsSum}");
        }
    }
}
