using Agency.Common;

namespace Agency.Models.Vehicles.Contracts
{
    public interface IVehicle
    {
        int PassangerCapacity { get; }

        decimal PricePerKilometer { get; }

        VehicleType Type { get;  }
    }
}