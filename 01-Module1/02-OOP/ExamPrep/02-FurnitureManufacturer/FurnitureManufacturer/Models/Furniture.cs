using FurnitureManufacturer.Interfaces;
using System;
using System.Text;

namespace FurnitureManufacturer.Models
{
    abstract class Furniture : IFurniture
    {
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (value == null) throw new ArgumentNullException("Model can not be null!");
                if (value.Length < 3) throw new ArgumentException("Model must be at least 3 symbols!");

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material;
            }
            private set
            {
                this.material = value ?? throw new ArgumentNullException("Material can not be null!");
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
                if (value < 0) throw new ArgumentException("Price cannot be less or equal to $0.00.");

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (value < 0) throw new ArgumentException("Height cannot be less or equal to 0.00 m.");

                this.height = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            return sb.Append($"Type: {GetType().Name}, Model: {this.Model}, Material: {this.Material}, Price: {this.Price}, Height: {this.Height}, ").ToString().TrimEnd();
        }

    }
}
