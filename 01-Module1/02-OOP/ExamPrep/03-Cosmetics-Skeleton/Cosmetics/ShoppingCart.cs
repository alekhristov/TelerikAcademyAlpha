using Bytes2you.Validation;
using Cosmetics.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics
{
    class ShoppingCart : IShoppingCart
    {
        private readonly ICollection<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public ICollection<IProduct> Products => this.products;

        public void AddProduct(IProduct product)
        {
            Guard.WhenArgument(product, "Product can not be null!").IsNull().Throw();
            this.Products.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            Guard.WhenArgument(product, "Product can not be null!").IsNull().Throw();

            return this.Products.Any(x => x.Name == product.Name);
        }

        public void RemoveProduct(IProduct product)
        {
            Guard.WhenArgument(product, "Product can not be null!").IsNull().Throw();
            this.Products.Remove(this.Products.FirstOrDefault(p => p.Name == product.Name));
        }

        public decimal TotalPrice()
        {
            return this.Products.Sum(p => p.Price);
        }
    }
}
