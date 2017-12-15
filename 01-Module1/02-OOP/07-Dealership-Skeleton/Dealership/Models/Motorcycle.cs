using System.Collections.Generic;
using Bytes2you.Validation;
using Dealership.Common.Enums;
using Dealership.Contracts;
using System;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        private string category;

        public Motorcycle(string make, string model, decimal price, string category) : base(make, model, price)
        {
            this.Type = VehicleType.Motorcycle;
            this.Wheels = (int)VehicleType.Motorcycle;
            this.Category = category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                Guard.WhenArgument(value, "You need to enter a category!").IsNull().Throw();
                if (value.Length < 3 || value.Length > 10)
                {
                    throw new ArgumentException("Category must be between 3 and 10 characters long!");
                }
                this.category = value;
            }
        }

        public override string ToString()
        {
            return $"Category: {this.Category}";
        }
    }
}