using System;

namespace _01_DefineClass
{
    class Call
    {
        private string date;
        private string time;
        private string dialledPhoneNumber;
        private double duration;

        public Call(string date, string time, string dialledPhoneNumber, double duration)
        {
            this.date = date;
            this.time = time;
            this.dialledPhoneNumber = dialledPhoneNumber;
            this.duration = duration;
        }

        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }
        public string DialledPhoneNumber
        {
            get
            {
                return this.dialledPhoneNumber;
            }
            set
            {
                this.dialledPhoneNumber = value;
            }
        }
        public double Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }
    }
}
