using System;
using System.Linq;

namespace _05_GoldFever
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var goldPrices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var index = goldPrices.Length - 1;
            var lastDayGoldPrice = goldPrices[index];

            long maxProfit = 0;

            for (int i = n - 2; i >= 0; i--)
            {
                if (lastDayGoldPrice > goldPrices[i])
                {
                    maxProfit += lastDayGoldPrice - goldPrices[i];
                }
                else
                {
                    lastDayGoldPrice = goldPrices[i];
                }
            }
            Console.WriteLine(maxProfit);
        }
    }
}
