using System;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Core.Providers
{
    public class Writer : IWriter
    {
        public void Write(string toPrint)
        {
            Console.Write(toPrint);
        }

        public void WriteLine(string toPrint)
        {
            Console.WriteLine(toPrint);
        }
    }
}
