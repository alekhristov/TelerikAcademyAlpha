using System;
using System.Linq;

namespace _08_MajorantOccurence
{
    class MajorantOccurence
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            var newArray = array.Distinct().ToArray();

            foreach (var num in newArray)
            {
                if (array.Where(n => n == num).Count() > array.Length / 2)
                {
                    Console.WriteLine(num);
                    break;
                }
            }
        }
    }
}
