namespace Cosmetics.Contracts
{
    using System.Collections.Generic;

    using Cosmetics.Common;
    using Cart;
    using Products;
	
    public interface ICosmeticsFactory
    {
        ICategory CreateCategory(string name);

        IProduct CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage);

        IProduct CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients);

        IProduct CreateCream(string name, string brand, decimal price, GenderType gender, ScentType scent);

        IShoppingCart CreateShoppingCart();
    }
}
