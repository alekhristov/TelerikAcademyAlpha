using Agency.Common;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles
{
    class Airplane : Vehicle, IAirplane
    {
        private readonly bool hasFreeFood;

        public Airplane(int passangerCapacity, decimal pricePerKilometer, bool hasFreeFood) 
            : base(passangerCapacity, pricePerKilometer, VehicleType.Air)
        {
            this.hasFreeFood = hasFreeFood;
        }

        public bool HasFreeFood => this.hasFreeFood;

        protected override string AdditionalInfo()
        {
            return $"Has free food: {this.hasFreeFood}";
        }
    }
}
