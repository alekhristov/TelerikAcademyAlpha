﻿using Cosmetics.Cart;
using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Products;
using System.Collections.Generic;

namespace Cosmetics.Core.Engine
{
    public class CosmeticsFactory : ICosmeticsFactory
    {
        public ICategory CreateCategory(string name)
        {
            return new Category(name);
        }

        public Shampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            return new Shampoo(name, brand, price, gender, milliliters, usage);
        }

        public Toothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            string ingredientsString = string.Join(", ", ingredients);
            return new Toothpaste(name, brand, price, gender, ingredientsString);
        }

        public Cream CreateCream(string name, string brand, decimal price, GenderType gender, ScentType scent)
        {
            return new Cream(name, brand, price, gender, scent);
        }

        public ShoppingCart CreateShoppingCart()
        {
            return new ShoppingCart();
        }
    }
}
