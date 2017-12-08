using System;

namespace _01_SayHello
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            SayHello(name);
        }

        private static void SayHello(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
