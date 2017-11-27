using System;

namespace _01_SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var input = double.Parse(Console.ReadLine());
                if (input < 0)
                {
                    throw new Exception();
                }
                else
                {
                    Console.WriteLine("{0:f3}", Math.Sqrt(input));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
