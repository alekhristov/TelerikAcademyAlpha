using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Text;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        private uint size;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint size, UsageType usage) : base(name, brand, price, gender)
        {
            this.Size = size;
            this.Usage = usage;
        }

        public uint Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            set
            {
                if (!Enum.IsDefined(typeof(UsageType), value)) throw new ArgumentException("Invalid usage");
                this.usage = value;
            }
        }

        public override string Print()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.Print());
            sb.AppendLine($" #Milliliters: {this.Size}");
            sb.AppendLine($" #Usage: {this.Usage}");
            sb.Append(" ===");

            return sb.ToString();
        }
    }
}
