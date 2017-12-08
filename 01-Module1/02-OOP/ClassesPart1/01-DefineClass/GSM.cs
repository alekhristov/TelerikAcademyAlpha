using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DefineClass
{
    class GSM
    {
        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        private Battery battery;
        private Display display;
        private static GSM iPhone4S = new GSM("Iphone 4S", "Apple", 259, "Deyana Hristova", new Battery("IBattery", 12.5f, 3.0f), new Display(@"4.0'", 20000000));
        private List<Call> callsHistory = new List<Call>();

        public GSM(string model)
        {
            this.model = model;
        }

        public GSM(string model, string manufacturer)
            : this(model)
        {
            this.manufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, double price)
            : this(model, manufacturer)
        {
            this.price = price;
        }

        public GSM(string model, string manufacturer, double price, string owner)
            : this(model, manufacturer, price)
        {
            this.owner = owner;
        }

        public GSM(string model, string manufacturer, double price, string owner, Battery battery, Display display)
            : this(model, manufacturer, price, owner)
        {
            this.battery = battery;
            this.display = display;
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

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = value;
            }
        }
        public double? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }
        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }
        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        public static GSM IPhone4S
        {
            get
            {
                return GSM.iPhone4S;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callsHistory;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Model: " + this.Model);
            sb.AppendLine("Manufacturer: " + this.Manufacturer);

            if (this.Price != null) sb.AppendLine("Price: " + this.Price + " lv.");
            if (this.Owner != null) sb.AppendLine("Owner: " + this.Owner);
            if (this.battery != null && battery.Model != null) sb.AppendLine("Battery model: " + this.battery.Model);
            if (this.battery != null && battery.HoursIdls != null) sb.AppendLine("Battery hours idle: " + this.battery.HoursIdls);
            if (this.battery != null && battery.HoursTalk != null) sb.AppendLine("Battery hours talk: " + this.battery.HoursTalk);
            if (this.battery != null && battery.BatteryType != null) sb.AppendLine("Battery type: " + this.battery.BatteryType);
            if (this.display != null && display.Size != null) sb.AppendLine("Display size: " + this.display.Size);
            if (this.display != null && display.NumberOfColors != null) sb.AppendLine("Display number of colors: " + this.display.NumberOfColors);

            return sb.ToString();
        }

        public void AddCalls(Call call)
        {
            CallHistory.Add(call);
        }

        public void DeleteCalls(Call call)
        {
            CallHistory.Remove(call);
        }

        public double CalculateCallPrice(double pricePerMinute)
        {
            var callPrice = 0.0;

            foreach (var call in CallHistory)
            {
                callPrice += Math.Ceiling(call.Duration) * pricePerMinute;
            }

            return callPrice;
        }
    }
}
