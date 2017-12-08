using Bytes2you.Validation;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics
{
    public class Category
    {
        private readonly string name;
        private readonly List<Product> products;

        public Category(string name)
        {
            Guard.WhenArgument(name, "name").IsNull().Throw();
            Guard.WhenArgument(name.Length, "nameLength").IsLessThan(2).Throw();
            Guard.WhenArgument(name.Length, "nameLength").IsGreaterThan(15).Throw();
            this.name = name;
            this.products = new List<Product>();
        }

        public List<Product> Products
        {
            get
            {
                return this.products;
            }
        }

        public virtual void AddProduct(Product product)
        {
            Guard.WhenArgument(product, "product").IsNull().Throw();

            products.Add(product);

        }

        public virtual void RemoveProduct(Product product)
        {
            if (!products.Any(p => p.Name == product.Name))
            {
                throw new ArgumentNullException("Product not found");
            }
            products.Remove(product);
        }

        public string Print()
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine($"#Category: {this.name}");

            if (products.Count == 0)
            {
                strBuilder.Append(" #No product in this category");
            }

            foreach (var product in this.products.OrderBy(p => p.Name).ThenByDescending(p => p.Price).ToList())
            {
                strBuilder.AppendLine(product.Print());
            }

            return strBuilder.ToString();
        }
    }
}
