using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;
using System;
using System.Text;

namespace Agency.Models
{
    class Journey : IJourney
    {
        private readonly string startLocation;
        private readonly string destination;
        private readonly int distance;
        private readonly IVehicle vehicle;

        public Journey(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            if (startLocation == null) throw new ArgumentException("You need to enter a start location!");
            if (startLocation.Length < 5 || startLocation.Length > 25) throw new ArgumentException("The StartingLocation's length cannot be less than 5 or more than 25 symbols long.");
            if (destination == null) throw new ArgumentException("You need to enter a final destination!");
            if (destination.Length < 5 || destination.Length > 25) throw new ArgumentException("The Destination's length cannot be less than 5 or more than 25 symbols long.");
            if (distance < 5 || distance > 5000) throw new ArgumentException("The Distance cannot be less than 5 or more than 5000 kilometers.");

            this.startLocation = startLocation;
            this.destination = destination;
            this.distance = distance;
            this.vehicle = vehicle ?? throw new ArgumentException("There is no such vehicle");
        }

        public string StartLocation => this.startLocation;

        public string Destination => this.destination;

        public int Distance => this.distance;

        public IVehicle Vehicle => this.vehicle;

        public decimal CalculateTravelCosts()
        {
            return this.Distance * vehicle.PricePerKilometer;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Journey ----");
            sb.AppendLine($"Start location: {this.StartLocation}");
            sb.AppendLine($"Destination: {this.Destination}");
            sb.AppendLine($"Distance: {this.Distance}");
            sb.AppendLine($"Vehicle type: {this.Vehicle.Type}");
            sb.AppendLine($"Travel costs: {this.CalculateTravelCosts()}");

            return sb.ToString().TrimEnd();
        }
    }
}
