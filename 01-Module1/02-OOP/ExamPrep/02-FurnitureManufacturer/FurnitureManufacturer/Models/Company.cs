using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null) throw new ArgumentNullException("Name can not be null!");
                if (value.Length < 5) throw new ArgumentException("Name can not be less than 5 symbols");
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                if (value == null) throw new ArgumentNullException("Registration number can not be null!");
                if (value.Length != 10) throw new ArgumentException("Registration number must be exactly 10 symbols!");

                foreach (var c in value)
                {
                    if (!char.IsDigit(c)) throw new ArgumentException("Registration number must contain only digits!");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
            private set
            {
                this.furnitures = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            if (furniture == null) throw new ArgumentNullException("Furniture can not be null");
            this.Furnitures.Add(furniture);
        }

        public string Catalog()
        {
            var sb = new StringBuilder();

            if (!this.Furnitures.Any())
            {
                sb.AppendLine($"{this.Name} - {this.RegistrationNumber} - no furnitures");
                return sb.ToString().TrimEnd();
            }

            if (this.Furnitures.Count == 1) sb.AppendLine($"{this.Name} - {this.RegistrationNumber} - 1 furniture");
            else sb.AppendLine($"{this.Name} - {this.RegistrationNumber} - {this.Furnitures.Count} furnitures");

            foreach (var furniture in this.Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model))
            {
                sb.AppendLine(furniture.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public IFurniture Find(string model)
        {
            if (model == null) throw new ArgumentNullException("Model can not be null");

            foreach (var furniture in this.Furnitures)
            {
                if (furniture.Model.ToLower() == model.ToLower())
                {
                    return furniture;
                }
            }

            return null;
        }

        public void Remove(IFurniture furniture)
        {
            if (furniture == null) throw new ArgumentNullException("Furniture can not be null");

            if (this.Furnitures.Any(f => f.Model == furniture.Model))
            {
                this.Furnitures.Remove(furniture);
            }
        }
    }
}
