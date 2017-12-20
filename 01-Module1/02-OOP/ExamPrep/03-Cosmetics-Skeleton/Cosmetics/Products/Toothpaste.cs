using System;
using System.Linq;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    class Toothpaste : Product, IToothpaste
    {
        private readonly string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            : base(name, brand, price, gender)
        {
            var ingredientsList = ingredients.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            if (ingredientsList.Any(i => i.Length < 4 || i.Length > 12)) throw new ArgumentException("Each ingredient must be between 4 and 12 symbols long!");

            this.ingredients = ingredients;
        }

        public string Ingredients => this.ingredients;

        public override string Print()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.Print());
            sb.AppendLine($"  * Ingredients: {this.ingredients}");

            return sb.ToString().TrimEnd();
        }
    }
}
