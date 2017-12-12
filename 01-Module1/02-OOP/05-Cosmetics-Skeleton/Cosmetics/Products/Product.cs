using System;
using Cosmetics.Common;
using Cosmetics.Contracts;
using Bytes2you.Validation;
using System.Text;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Guard.WhenArgument(value, "You need to enter a product name!").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Invalid name length!").IsLessThan(3).IsGreaterThan(10).Throw();
                this.name = value;
            }
        }

        public virtual string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                Guard.WhenArgument(value, "You need to enter a brand name!").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Invalid brand name length!").IsLessThan(2).IsGreaterThan(10).Throw();
                this.brand = value;
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
                Guard.WhenArgument(value, "You need to enter a valid price!").IsLessThan(0).Throw();
                this.price = value;
            }
        }
        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (!Enum.IsDefined(typeof(GenderType), value)) throw new ArgumentException("Invalid gender");
                this.gender = value;
            }
        }

        public virtual string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine($" #{this.Name} {this.Brand}");
            sb.AppendLine($" #Price: {this.Price}");
            sb.Append($" #Gender: {this.Gender}");

            return sb.ToString();
        }
    }
}
