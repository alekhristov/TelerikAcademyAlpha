using System;

namespace _01_DefineClass
{
    class StartUp
    {
        static void Main(string[] args)
        {
            GSMTest.DisplayGSMsInformation();
            GSMTest.DisplayIphone4SInformation();

            GSMCallHistoryTest.DisplayCallInfo();
            GSMCallHistoryTest.CalculateCallPrices(0.37);
        }
    }
}
