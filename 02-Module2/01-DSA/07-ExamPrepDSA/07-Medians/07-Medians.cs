using System;
using System.Text;
using Wintellect.PowerCollections;

namespace _07_Medians
{
    public class Program
    {
        static OrderedBag<long> numbers = new OrderedBag<long>();

        static void Main(string[] args)
        {
            var result = new StringBuilder();

            while (true)
            {
                var input = Console.ReadLine().Split(' ');
                var command = input[0];

                switch (command)
                {
                    case "ADD": Add(long.Parse(input[1])); break;
                    case "FIND": result.AppendLine(Find()); break;
                    case "EXIT": Console.Write(result); return;
                }
            }
        }

        static void Add(long number)
        {
            numbers.Add(number);
        }

        static string Find()
        {
            if (numbers.Count % 2 == 1)
            {
                return numbers[numbers.Count / 2].ToString();
            }

            return ((numbers[numbers.Count / 2 - 1] + numbers[numbers.Count / 2]) / (double)2).ToString();
        }
    }
}
