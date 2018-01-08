using System;
using System.Collections.Generic;

namespace LinkedListExercise
{
    class PrimeNumbersBetween200and300
    {
        static void Main(string[] args)
        {
            var result = new List<int>();

            for (int i = 200; i <= 300; i++)
            {
                bool isPrime = true;

                for (int divisor = 2; divisor <= Math.Sqrt(i); divisor++)
                {
                    if (i % divisor == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
