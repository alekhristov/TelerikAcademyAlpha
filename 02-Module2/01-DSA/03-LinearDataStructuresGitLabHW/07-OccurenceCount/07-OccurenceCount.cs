using System;
using System.Linq;

namespace _07_OccurenceCount
{
    class OccurenceCount
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var newArray = array.Distinct().ToArray();

            foreach (var num in newArray.OrderBy(n => n))
            {
                Console.WriteLine($"{num} -> {array.Where(n => n == num).Count()} times");
            }
        }
    }
}
