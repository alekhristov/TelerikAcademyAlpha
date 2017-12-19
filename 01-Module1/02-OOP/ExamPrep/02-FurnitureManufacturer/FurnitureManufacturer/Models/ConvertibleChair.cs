using FurnitureManufacturer.Interfaces;
using System.Text;

namespace FurnitureManufacturer.Models
{
    class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs) : base(model, material, price, height, numberOfLegs)
        {
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
            private set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            this.IsConverted = true;
            this.Height = 0.10m;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString());

            if (this.IsConverted)
            {
                sb.Append(", State: Converted");
            }
            else
            {
                sb.Append(", State: Normal");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
