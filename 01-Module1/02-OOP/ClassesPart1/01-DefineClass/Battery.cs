using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DefineClass
{
    class Battery
    {
        private string model;
        private float? hoursIdle;
        private float? hoursTalk;
        private BatteryType? batteryType;

        public Battery()
        {

        }

        public Battery(string model)
        {
            this.model = model;
        }

        public Battery(string model, float hoursIdle)
            : this (model)
        {
            this.hoursIdle = hoursIdle;
        }

        public Battery(string model, float hoursIdle, float hoursTalk)
            : this (model, hoursIdle)
        {
            this.hoursTalk = hoursTalk;
        }

        public Battery(string model, float hoursIdle, float hoursTalk, BatteryType batteryType)
    : this(model, hoursIdle, hoursTalk)
        {
            this.batteryType = batteryType;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public float? HoursIdls
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                this.hoursIdle = value;
            }
        }
        public float? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                this.hoursTalk = value;
            }
        }

        public BatteryType? BatteryType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                this.batteryType = value;
            }
        }
    }
}
