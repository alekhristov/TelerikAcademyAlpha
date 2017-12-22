using Agency.Common;
using Agency.Models.Vehicles.Contracts;
using System;

namespace Agency.Models.Vehicles
{
    class Bus : Vehicle, IBus
    {
        public Bus(int passangerCapacity, decimal pricePerKilometer) : base(passangerCapacity, pricePerKilometer, VehicleType.Land)
        {
            if (passangerCapacity < 10 || passangerCapacity > 50) throw new ArgumentException("A bus cannot have less than 10 passengers or more than 50 passengers.");
        }

        protected override string AdditionalInfo()
        {
            return string.Empty;
        }
    }
}
