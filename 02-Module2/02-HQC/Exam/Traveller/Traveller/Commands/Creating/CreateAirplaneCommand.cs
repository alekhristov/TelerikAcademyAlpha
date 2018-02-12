using System;
using System.Collections.Generic;
using Traveller.Commands.Abstract;
using Traveller.Commands.Contracts;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateAirplaneCommand : CreateCommand, ICommand
    {
        public CreateAirplaneCommand(ITravellerFactory factory, IDatabase database) 
            : base(factory, database)
        {
        }

        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            bool hasFreeFood;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                hasFreeFood = bool.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
            }

            var airplane = this.Factory.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);
            this.Database.Vehicles.Add(airplane);

            return $"Vehicle with ID {this.Database.Vehicles.Count - 1} was created.";
        }
    }
}
