﻿using Agency.Core.Contracts;
using Agency.Models;
using Agency.Models.Contracts;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Core.Factories
{
    public class AgencyFactory : IAgencyFactory
    {
        private static IAgencyFactory instanceHolder = new AgencyFactory();

        private AgencyFactory()
        {
        }

        public static IAgencyFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }
        
        public IVehicle CreateBus(int passengerCapacity, decimal pricePerKilometer)
        {
            return new Bus(passengerCapacity, pricePerKilometer);
        }

        public IVehicle CreateAirplane(int passengerCapacity, decimal pricePerKilometer, bool hasFreeFood)
        {
            return new Airplane(passengerCapacity, pricePerKilometer, hasFreeFood);
        }

        public IVehicle CreateTrain(int passengerCapacity, decimal pricePerKilometer, int carts)
        {
            return new Train(passengerCapacity, pricePerKilometer, carts);
        }
        
        public IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            return new Journey(startLocation, destination, distance, vehicle);
        }

        public ITicket CreateTicket(IJourney journey, decimal administrativeCosts)
        {
            return new Ticket(journey, administrativeCosts);
        }
    }
}
