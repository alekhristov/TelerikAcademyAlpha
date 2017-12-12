using Cosmetics.Contracts;
using System;
using Cosmetics.Common;
using Bytes2you.Validation;

namespace Cosmetics.Products
{
    public class Cream : Product, ICream
    {
        private ScentType scent;
        private string name;
        private string brand;

        public Cream(string name, string brand, decimal price, GenderType gender, ScentType scent) : base(name, brand, price, gender)
        {
            this.Scent = scent;
        }

        public override string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Guard.WhenArgument(value, "You need to enter a product name!").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Invalid name length!").IsLessThan(3).IsGreaterThan(15).Throw();
                this.name = value;
            }
        }

        public override string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                Guard.WhenArgument(value, "You need to enter a product brand!").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Invalid brand length!").IsLessThan(3).IsGreaterThan(15).Throw();
                this.brand = value;
            }
        }
        public ScentType Scent
        {
            get
            {
                return this.scent;
            }
            set
            {
                if (!Enum.IsDefined(typeof(ScentType), value)) throw new ArgumentException("Invalid scent");
                this.scent = value;
            }
        }
    }
}
