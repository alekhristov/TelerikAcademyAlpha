using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _03_RangeExceptions
{
    class InvalidRangeException<T> : Exception
    {
        private T min;
        private T max;

        public InvalidRangeException(T min, T max) : this(null, null, min, max)
        {
        }

        public InvalidRangeException(string message, T min, T max) : this(message, null, min, max)
        {
        }

        public InvalidRangeException(string message, Exception innerException, T min, T max) : base(message, innerException)
        {
            this.Min = min;
            this.Max = max;
        }

        public T Min { get; }

        public T Max { get; }
    }
}
