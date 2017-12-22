using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models
{
    class Journey : IJourney
    {
        private readonly string destination;
        public string Destination => throw new NotImplementedException();

        public int Distance => throw new NotImplementedException();

        public string StartLocation => throw new NotImplementedException();

        public IVehicle Vehicle => throw new NotImplementedException();

        public decimal CalculateTravelCosts()
        {
            throw new NotImplementedException();
        }
    }
}
