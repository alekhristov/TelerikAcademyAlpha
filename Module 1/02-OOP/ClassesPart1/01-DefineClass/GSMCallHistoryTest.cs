using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DefineClass
{
    class GSMCallHistoryTest
    {
        private static GSM TestCallHistory()
        {
            var gsm = new GSM("X", "Apple", 2500, "Atanas");

            gsm.AddCalls(new Call("07/12/2017", "01:36am", "0800 18 100", 3.4));
            gsm.AddCalls(new Call("06/10/2016", "09:36am", "0800 18 188", 5.6));

            return gsm;
        }

        public static void DisplayCallInfo()
        {
            var gsm = TestCallHistory();

            var counter = 1;
            foreach (var item in gsm.CallHistory)
            {
                Console.WriteLine("Call " + counter++ + ":");
                Console.WriteLine("Call date: " + item.Date);
                Console.WriteLine("Call time: " + item.Time);
                Console.WriteLine("Dialled call number: " + item.DialledPhoneNumber);
                Console.WriteLine("Call duration: " + item.Duration + "m");
            }
        }

        public static void CalculateCallPrices(double pricePerMinute)
        {
            var gsm = TestCallHistory();

            //RemoveTheLongestCall(gsm.CallHistory);
            //gsm.CallHistory.Clear();
            Console.WriteLine("Calls Total Price: " + gsm.CalculateCallPrice(pricePerMinute) + " lv.");
        }

        private static void RemoveTheLongestCall(List<Call> callHistory)
        {
            callHistory.OrderByDescending(c => c.Duration);
            callHistory.RemoveAt(0);
        }
    }
}
