using System;

namespace _03_SumFirstNElements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumElements(1, 10, 0));
        }

        private static int SumElements(int start, int num, int sum)
        {
            if (start > num)
            {
                return sum;
            }

            sum += start;
            return SumElements(start + 1, num, sum);
        }
    }
}
