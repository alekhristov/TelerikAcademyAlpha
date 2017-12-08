using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DefineClass
{
    class GSMTest
    {
        private static List<GSM> CreateListOfGSMs()
        {
            var listOfGSMs = new List<GSM>();

            listOfGSMs.Add(new GSM("Galaxy S6", "Samsung", 400, "Gosho", new Battery("Samsung battery", 26, 6), new Display(@"5'", 10000000)));
            listOfGSMs.Add(new GSM("Xperia Z", "Nokia", 360, "Pesho", new Battery("Nokia battery", 40, 12), new Display(@"5.5'", 20000000)));
            listOfGSMs.Add(new GSM("234", "Alcatel", 200, "Stamat", new Battery("Alcatel battery", 30, 7), new Display(@"4.7'", 5000000)));
            listOfGSMs.Add(new GSM("AK47", "Lenovo"));
            listOfGSMs.Add(new GSM("Sensation", "HTC", 300, "Robber"));

            return listOfGSMs;
        }

        public static void DisplayGSMsInformation()
        {
            var listOfGSMs = CreateListOfGSMs();

            foreach (var gsm in listOfGSMs)
            {
                Console.WriteLine(gsm);
            }
        }

        public static void DisplayIphone4SInformation()
        {
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
