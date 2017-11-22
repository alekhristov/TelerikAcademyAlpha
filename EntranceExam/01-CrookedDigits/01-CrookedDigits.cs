using System;

namespace _01_CrookedDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int num;
            int sum = 0;

            while (true)
            {
                foreach (var digit in input)
                {
                    if (int.TryParse(digit.ToString(), out num))
                    {
                        sum += num;
                    }
                }

                if (sum < 10)
                {
                    break;
                }
                input = sum.ToString();
                sum = 0;
            }
            Console.WriteLine(sum);
        }
    }
}
