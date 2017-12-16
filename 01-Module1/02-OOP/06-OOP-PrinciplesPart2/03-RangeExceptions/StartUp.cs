using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_RangeExceptions
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a number: ");
                TestWithNumbers(1, 100);
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Range: [{ex.Min}...{ex.Max}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine();
                Console.Write("Enter a date: ");
                TestWithDateTime(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Range: [{ex.Min.ToString("dd/MM/yyyy")}...{ex.Max.ToString("dd/MM/yyyy")}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void TestWithDateTime(DateTime minDateTime, DateTime maxDateTime)
        {
            var date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (date < minDateTime || date > maxDateTime)
            {
                throw new InvalidRangeException<DateTime>("Date is out of range", new Exception($"Date must be in Range: [{minDateTime}...{maxDateTime}]"), minDateTime, maxDateTime);
            }
        }

        private static void TestWithNumbers(int minNumber, int maxNumber)
        {
            var number = int.Parse(Console.ReadLine());

            if (number < minNumber || number > maxNumber)
            {
                throw new InvalidRangeException<int>("Number out of range", minNumber, maxNumber);
            }
        }
    }
}
