using Bytes2you.Validation;
using Cosmetics.Common;
using System;

namespace Cosmetics.Products
{
    public class Product
    {
        private readonly decimal price;
        private readonly string name;
        private readonly string brand;
        private readonly GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            Guard.WhenArgument(name, "name").IsNull().Throw();
            Guard.WhenArgument(name.Length, "nameLength").IsLessThan(3).Throw();
            Guard.WhenArgument(name.Length, "nameLength").IsGreaterThan(10).Throw();
            Guard.WhenArgument(brand, "brand").IsNull().Throw();
            Guard.WhenArgument(brand.Length, "brandLength").IsLessThan(2).Throw();
            Guard.WhenArgument(brand.Length, "brandLength").IsGreaterThan(10).Throw();
            Guard.WhenArgument(price, "price").IsLessThan(0).Throw();
            if (!Enum.IsDefined(typeof(GenderType), gender)) throw new ArgumentException("Invalid gender");

            this.name = name;
            this.brand = brand;
            this.price = price;
            this.gender = gender;
        }

        public decimal Price => price;

        public string Name => name;

        public string Brand => brand;

        public GenderType Gender => gender;

        public string Print()
        {
            return $" #{this.Name} {this.Brand}\r\n #Price: ${this.Price}\r\n #Gender: {this.Gender}\r\n ===";
        }
    }
}
