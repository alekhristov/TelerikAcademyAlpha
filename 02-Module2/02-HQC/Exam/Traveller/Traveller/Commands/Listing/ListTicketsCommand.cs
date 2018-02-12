using System;
using System.Collections.Generic;
using Traveller.Commands.Abstract;
using Traveller.Commands.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListTicketsCommand : ListCommand, ICommand
    {
        public ListTicketsCommand(IDatabase database) 
            : base(database)
        {
        }

        public string Execute(IList<string> parameters)
        {
            var tickets = this.Database.Tickets;

            if (tickets.Count == 0)
            {
                return "There are no registered tickets.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, tickets);
        }
    }
}
