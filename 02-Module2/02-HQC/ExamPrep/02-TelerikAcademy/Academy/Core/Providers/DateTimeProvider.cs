using System;

namespace Academy.Core.Providers
{
    internal abstract class DateTimeProvider
    {
        public static DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
