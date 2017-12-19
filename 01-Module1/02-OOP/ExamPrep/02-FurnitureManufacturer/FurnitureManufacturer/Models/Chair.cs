using FurnitureManufacturer.Interfaces;
using System;
using System.Text;

namespace FurnitureManufacturer.Models
{
    class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs) : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
            private set
            {
                if (value < 1) throw new ArgumentException("Number of legs can not be 0!");
                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine($" Legs: {this.NumberOfLegs}");

            return sb.ToString().TrimEnd();

        }
    }
}
