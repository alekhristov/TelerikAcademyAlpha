using Agency.Models.Contracts;
using System;
using System.Text;

namespace Agency.Models
{
    class Ticket : ITicket
    {
        private readonly IJourney journey;
        private readonly decimal administrativeCosts;

        public Ticket(IJourney journey, decimal administrativeCosts)
        {
            if (administrativeCosts < 0) throw new ArgumentException("Administrative costs can not be a negative number!");

            this.journey = journey ?? throw new ArgumentException("There is no such journey!");
            this.administrativeCosts = administrativeCosts;    
        }

        public IJourney Journey => this.journey;

        public decimal AdministrativeCosts => this.administrativeCosts;

        public decimal CalculatePrice()
        {
            return this.AdministrativeCosts * this.Journey.CalculateTravelCosts();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Ticket ----");
            sb.AppendLine($"Destination: {this.Journey.Destination}");
            sb.AppendLine($"Price: {this.CalculatePrice()}");


            return sb.ToString().TrimEnd();
        }
    }
}
