using System;
using System.Collections.Generic;
using Traveller.Commands.Abstract;
using Traveller.Commands.Contracts;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateTrainCommand : CreateCommand, ICommand
    {
        public CreateTrainCommand(ITravellerFactory factory, IDatabase database) 
            : base(factory, database)
        {
        }

        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            int cartsCount;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                cartsCount = int.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTrain command parameters.");
            }

            var train = this.Factory.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
            this.Database.Vehicles.Add(train);

            return $"Vehicle with ID {this.Database.Vehicles.Count - 1} was created.";
        }
    }
}
