using System;
using System.Text;

namespace _02_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var cards = new string[]
            {
                "2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "Tc", "Jc", "Qc", "Kc", "Ac",
                 "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "Td", "Jd", "Qd", "Kd", "Ad",
                  "2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "Th", "Jh", "Qh", "Kh", "Ah",
                   "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "Ts", "Js", "Qs", "Ks", "As"
            };
            var handsValue = new int[52];

            for (int i = 0; i < input; i++)
            {
                var n = long.Parse(Console.ReadLine());
                string binaryNum = string.Empty;

                if (n == 1)
                {
                    binaryNum = n.ToString().PadRight(52, '0');
                }
                else
                {
                    binaryNum = Convert.ToString(n, 2).PadLeft(52, '0');
                }

                for (int j = 0; j < binaryNum.Length; j++)
                {
                    if (binaryNum[j] == '1')
                    {
                        handsValue[j]++;
                    }
                }
            }
            var fullDeck = true;
            var sb = new StringBuilder();

            for (int i = 0; i < handsValue.Length; i++)
            {
                if (handsValue[i] == 0)
                {
                    fullDeck = false;
                }
                if (handsValue[i] % 2 != 0)
                {
                    sb.Append(cards[i] + " ");
                }
            }
            if (fullDeck)
            {
                Console.WriteLine("Full deck");
                Console.WriteLine(sb);
            }
            else
            {
                Console.WriteLine("Wa wa!");
                Console.WriteLine(sb);
            }
        }
    }
}
