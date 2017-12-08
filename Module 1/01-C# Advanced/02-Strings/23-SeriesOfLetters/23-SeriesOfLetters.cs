using System;

namespace _23_SeriesOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower();
            string result = input[0].ToString();
            var resultIndex = 0;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != result[resultIndex])
                {
                    result += input[i];
                    resultIndex++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
