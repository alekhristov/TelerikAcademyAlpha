using System;
using System.Collections.Generic;

namespace _02_EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new List<int>();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    result.Add(int.Parse(Console.ReadLine()));
                }
                if (result.Count != 10 || result[0] <= 1 || result[9] >= 100)
                {
                    throw new Exception();
                }
                for (int i = 1; i < 10; i++)
                {
                    if (result[i] <= result[i-1])
                    {
                        throw new Exception();
                    }
                }
                Console.WriteLine("1 < " + string.Join(" < ", result) + " < 100");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }
        }
    }
}
