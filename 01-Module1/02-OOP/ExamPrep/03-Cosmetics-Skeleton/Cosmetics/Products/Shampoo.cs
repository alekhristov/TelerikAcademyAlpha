using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Text;

namespace Cosmetics.Products
{
    class Shampoo : Product, IShampoo
    {
        private readonly uint milliliters;
        private readonly UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            if (!Enum.IsDefined(typeof(UsageType), usage)) throw new ArgumentException("The provided usage is not valid!");
            this.milliliters = milliliters;
            this.usage = usage;
            this.Price = price * milliliters;
        }

        public uint Milliliters => this.milliliters;

        public UsageType Usage => this.usage;

        public override string Print()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.Print());
            sb.AppendLine($"  * Quantity: {this.Milliliters} ml");
            sb.AppendLine($"  * Usage: {this.Usage}");

            return sb.ToString().TrimEnd();
        }
    }
}
