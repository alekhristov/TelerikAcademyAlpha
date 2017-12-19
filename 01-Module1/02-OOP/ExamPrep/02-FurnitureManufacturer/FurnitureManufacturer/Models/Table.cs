using FurnitureManufacturer.Interfaces;
using System;
using System.Text;

namespace FurnitureManufacturer.Models
{
    class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;
        private decimal area;

        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width) : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
            this.Area = length * width;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value < 0) throw new ArgumentException("Length can not be less than 0!");
                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value < 0) throw new ArgumentException("Width can not be less than 0!");
                this.width = value;
            }
        }

        public decimal Area
        {
            get
            {
                return this.area;
            }
            private set
            {
                this.area = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine($" Length: {this.Length}, Width: {this.Width}, Area: {this.Area}");

            return sb.ToString().TrimEnd();
        }
    }
}
