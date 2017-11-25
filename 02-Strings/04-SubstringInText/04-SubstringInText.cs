using System;

namespace _04_SubstringInText
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = Console.ReadLine().ToLower();
            var text = Console.ReadLine().ToLower();
            var counter = 0;

            //for (int i = 0; i < text.Length - pattern.Length + 1; i++)
            //{
            //    if (text.Substring(i, pattern.Length) == pattern)
            //    {
            //        counter++;
            //        i += pattern.Length - 1;
            //    }
            //}
            var start = 0;

            while (true)
            {
                if (text.Substring(start, pattern.Length) == pattern)
                {
                    counter++;
                    start += pattern.Length;
                }
                else
                {
                    start++;
                }

                if (start + pattern.Length > text.Length)
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
