using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Text;

namespace Cosmetics.Products
{
     class Product : IProduct
    {
        private readonly string name;
        private readonly string brand;
        private readonly decimal price;
        private readonly GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            Guard.WhenArgument(name, "Name can not be null!").IsNull().Throw();
            Guard.WhenArgument(brand, "Brand can not be null!").IsNull().Throw();
            Guard.WhenArgument(name.Length, "Product name must be between 3 and 10 symbols long!").IsLessThan(3).IsGreaterThan(10).Throw();
            Guard.WhenArgument(brand.Length, "Product brand must be between 2 and 10 symbols long!").IsLessThan(2).IsGreaterThan(10).Throw();
            Guard.WhenArgument(price, "Price can not be negative!").IsLessThan(0).Throw();
            if (!Enum.IsDefined(typeof(GenderType), gender)) throw new ArgumentException("The provided gender is not valid!");

            this.name = name;
            this.brand = brand;
            this.price = price;
            this.gender = gender;
        }

        public string Name => this.name;

        public string Brand => this.brand;

        public decimal Price
        {
            get
            {
                return this.price;
            }
            //protected set
            //{
            //    this.price = value;
            //}
        }

        public GenderType Gender => this.gender;

        public virtual string Print()
        {
            var sb = new StringBuilder();

            sb.AppendLine( $"- {this.Brand} – {this.Name}:");
            sb.AppendLine($"  * Price: ${this.Price}");
            sb.AppendLine($"  * For gender: {this.Gender}");

            return sb.ToString().TrimEnd();
        }
    }
}
