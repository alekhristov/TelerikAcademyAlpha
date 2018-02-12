using System;
using System.Collections.Generic;
using Traveller.Commands.Abstract;
using Traveller.Commands.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListVehiclesCommand : ListCommand, ICommand
    {
        public ListVehiclesCommand(IDatabase database) 
            : base(database)
        {
        }

        public string Execute(IList<string> parameters)
        {
            var vehicles = this.Database.Vehicles;

            if (vehicles.Count == 0)
            {
                return "There are no registered vehicles.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, vehicles);
        }
    }
}
