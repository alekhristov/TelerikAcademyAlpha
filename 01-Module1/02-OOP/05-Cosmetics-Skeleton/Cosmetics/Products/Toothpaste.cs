using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System.Linq;
using System.Text;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingridients) : base(name, brand, price, gender)
        {
            this.Ingredients = ingridients;
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            set
            {
                Guard.WhenArgument(value, "You need to enter some ingridients!").IsNull().Throw();
                this.ingredients = value;
            }
        }

        public override string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendLine($" #Ingredients: {this.Ingredients.ToString()}");
            sb.Append(" ===");
            return sb.ToString();
        }

        public override string ToString()
        {
            var list = this.Ingredients.Split(',').ToList();
            var result = string.Join(", ", list);

            return result;
        }
    }
}