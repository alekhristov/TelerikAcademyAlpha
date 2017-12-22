using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Core.Contracts
{
    public interface IAgencyFactory
    {
        IVehicle CreateBus(int passengerCapacity, decimal pricePerKilometer);

        IVehicle CreateAirplane(int passengerCapacity, decimal pricePerKilometer, bool hasFreeFood);

        IVehicle CreateTrain(int passengerCapacity, decimal pricePerKilometer, int carts);

        IJourney CreateJourney(string startingLocation, string destination, int distance, IVehicle vehicle);

        ITicket CreateTicket(IJourney journey, decimal administrativeCosts);
    }
}
