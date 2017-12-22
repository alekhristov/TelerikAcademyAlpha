using System;
using Agency.Common;
using Agency.Models.Vehicles.Contracts;
namespace Agency.Models.Vehicles
{
    class Train : Vehicle, ITrain
    {
        private readonly int carts;
        public Train(int passangerCapacity, decimal pricePerKilometer, int carts) 
            : base(passangerCapacity, pricePerKilometer, VehicleType.Land)
        {
            if (passangerCapacity < 30 || passangerCapacity > 150) throw new ArgumentException("A train cannot have less than 30 passengers or more than 150 passengers.");
            if (carts < 1 || carts > 15) throw new ArgumentException("A train cannot have less than 1 cart or more than 15 carts.");

            this.carts = carts;
        }

        public int Carts => this.carts;

        protected override string AdditionalInfo()
        {
            return $"Carts amount: {this.Carts}";
        }
    }
}
