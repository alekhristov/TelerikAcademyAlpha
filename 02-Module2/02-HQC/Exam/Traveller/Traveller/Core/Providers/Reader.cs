using System;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Core.Providers
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
