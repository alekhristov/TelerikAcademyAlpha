using Dealership.Common.Enums;
using Dealership.Contracts;
using System;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity) : base(make, model, price)
        {
            this.Type = VehicleType.Truck;
            this.Wheels = (int)VehicleType.Truck;
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Weight capacity must be between 1 and 100!");
                }
                this.weightCapacity = value;
            }
        }

        public override string ToString()
        {
            return $"Weight capacity: {this.WeightCapacity}t";
        }
    }
}