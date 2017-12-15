using Bytes2you.Validation;
using Dealership.Common.Enums;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle, ICommentable, IPriceable
    {
        private string make;
        private int wheels;
        private VehicleType type;
        private string model;
        private IList<IComment> comments;
        private decimal price;

        protected Vehicle(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Comments = new List<IComment>();
        }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }
            protected set
            {
                this.wheels = value;
            }
        }

        public VehicleType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (!Enum.IsDefined(typeof(VehicleType), value)) throw new ArgumentException("Invalid vehicle type");
                this.type = value;
            }
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                if (value.Length < 2 || value.Length > 15)
                {
                    throw new ArgumentException("Make must be between 2 and 15 characters long!");
                }
                Guard.WhenArgument(value, "You need to enter a make").IsNull().Throw();
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                Guard.WhenArgument(value, "You need to enter a model").IsNull().Throw();
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Model must be between 1 and 15 characters long!");
                }
                this.model = value;
            }
        }

        public IList<IComment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                Guard.WhenArgument(value, "You need to enter a comment").IsNull().Throw();
                this.comments = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0 || value > 100000)
                {
                    throw new ArgumentException("Price must be between 0.0 and 1000000.0!");
                }
                this.price = value;
            }
        }
    }
}
