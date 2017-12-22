using Cosmetics.Contracts;
using Cosmetics.Engine;
using Cosmetics.Products;
using System.Collections.Generic;

namespace Cosmetics
{
    public class CosmeticsProgram
    {
        public static void Main()
        {
            var product = new Product("soft", "nivea", 2.55m, Common.GenderType.Men);
            var category = new Category("cat");

            category.AddCosmetics(product);
            foreach (var item in category.Products)
            {
                System.Console.WriteLine(item.Name);
            }

            category.Products.Clear();
            foreach (var item in category.Products)
            {
                System.Console.WriteLine(item.Name);
            }

            var list = new List<IProduct>(category.Products);

            foreach (var item in list)
            {
                System.Console.WriteLine(item.Name);
            }
            foreach (var item in category.Products)
            {
                System.Console.WriteLine(item.Name == list[0].Name);
                System.Console.WriteLine(item.Brand == list[0].Brand);
                System.Console.WriteLine(item.Price == list[0].Price);

            }
            CosmeticsEngine.Instance.Start();
        }
    }
}
