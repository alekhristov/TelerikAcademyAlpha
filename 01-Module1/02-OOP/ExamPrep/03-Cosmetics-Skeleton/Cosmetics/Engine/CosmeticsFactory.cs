namespace Cosmetics.Engine
{
    using System.Collections.Generic;
    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;

    public class CosmeticsFactory : ICosmeticsFactory
    {
        public ICategory CreateCategory(string name)
        {
            return new Category(name);
        }

        public IProduct CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            return new Shampoo(name, brand, price, gender, milliliters, usage);
        }

        public IProduct CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            var ingredientsStr = string.Join(", ", ingredients);
            return new Toothpaste(name, brand, price, gender, ingredientsStr);
        }

        public IShoppingCart ShoppingCart()
        {
            return new ShoppingCart();
        }
    }
}
