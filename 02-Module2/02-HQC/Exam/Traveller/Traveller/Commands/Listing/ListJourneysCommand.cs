using System;
using System.Collections.Generic;
using Traveller.Commands.Abstract;
using Traveller.Commands.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : ListCommand, ICommand
    {
        public ListJourneysCommand(IDatabase database) 
            : base(database)
        {
        }

        public string Execute(IList<string> parameters)
        {
            var journeys = this.Database.Journeys;

            if (journeys.Count == 0)
            {
                return "There are no registered journeys.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, journeys);
        }
    }
}
