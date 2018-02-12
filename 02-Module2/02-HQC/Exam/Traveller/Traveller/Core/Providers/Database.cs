﻿using System.Collections.Generic;
using Traveller.Core.Providers.Contracts;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core.Providers
{
    public class Database : IDatabase
    {
        private readonly IList<IVehicle> vehicles;
        private readonly IList<IJourney> journeys;
        private readonly IList<ITicket> tickets;

        public Database()
        {
            this.vehicles = new List<IVehicle>();
            this.journeys = new List<IJourney>();
            this.tickets = new List<ITicket>();
        }

        public IList<IVehicle> Vehicles => this.vehicles;

        public IList<IJourney> Journeys => this.journeys;

        public IList<ITicket> Tickets => this.tickets;
    }
}
