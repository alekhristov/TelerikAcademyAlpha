using Agency.Common;
using Agency.Models.Vehicles.Contracts;
using System;
using System.Text;

namespace Agency.Models
{
    abstract class Vehicle : IVehicle
    {
        private readonly int passangerCapacity;
        private readonly decimal pricePerKilometer;
        private readonly VehicleType type;

        public Vehicle(int passangerCapacity, decimal pricePerKilometer, VehicleType type)
        {
            if (passangerCapacity < 1 || passangerCapacity > 800) throw new ArgumentException("A vehicle with less than 1 passengers or more than 800 passengers cannot exist!");
            if (pricePerKilometer < 0.10m || pricePerKilometer > 2.50m) throw new ArgumentException("A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!");
            if (!Enum.IsDefined(typeof(VehicleType), type)) throw new ArgumentException("The provided vehicle is not valid!");

            this.passangerCapacity = passangerCapacity;
            this.pricePerKilometer = pricePerKilometer;
            this.type = type;

        }
        public int PassangerCapacity => this.passangerCapacity;

        public decimal PricePerKilometer => this.pricePerKilometer;

        public VehicleType Type => this.type;

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} ----");
            sb.AppendLine($"Passenger capacity: {this.PassangerCapacity}");
            sb.AppendLine($"Price per kilometer: {this.PricePerKilometer}");
            sb.AppendLine($"Vehicle type: {this.Type}");
            sb.AppendLine(AdditionalInfo());

            return sb.ToString().TrimEnd();
        }

        protected abstract string AdditionalInfo();
    }
}
