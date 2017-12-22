using Bytes2you.Validation;
using Cosmetics.Contracts;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics
{
    class Category : ICategory
    {
        private readonly string name;
        private readonly ICollection<IProduct> products;

        public Category(string name)
        {
            Guard.WhenArgument(name, "Category can not be null!").IsNull().Throw();
            Guard.WhenArgument(name.Length, "Category name must be between 2 and 15 symbols long!").IsLessThan(2).IsGreaterThan(15).Throw();
            this.name = name;
            this.products = new List<IProduct>();
        }

        public string Name => name;

        private ICollection<IProduct> Products => new List<IProduct>(this.products.Select(p => new Product(p.Name, p.Brand, p.Price, p.Gender)).ToList());

        public void AddCosmetics(IProduct cosmetics)
        {
            Guard.WhenArgument(cosmetics, "Product can not be null!").IsNull().Throw();

            this.products.Add(cosmetics);
        }

        public string Print()
        {
            var sb = new StringBuilder();

            if (products.Count == 1)
            {
                sb.AppendLine($"{this.Name} category – 1 product in total");
            }

            else
            {
                sb.AppendLine($"{this.Name} category – {products.Count} products in total");
            }

            foreach (var product in products.OrderBy(p => p.Brand).ThenByDescending(p => p.Price))
            {
                sb.AppendLine(product.Print());
            }

            return sb.ToString().TrimEnd();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            Guard.WhenArgument(cosmetics, "Product can not be null!").IsNull().Throw();

            if (!products.Any(p => p.Name == cosmetics.Name))
            {
                throw new ArgumentNullException($"Product {cosmetics.Name} does not exist in category {this.Name}!");
            }

            this.products.Remove(cosmetics);
        }
    }
}
