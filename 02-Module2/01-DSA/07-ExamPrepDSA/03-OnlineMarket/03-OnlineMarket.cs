using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace _03_OnlineMarket
{
    class Product : IComparable<Product>
    {
        public Product()
        {
        }

        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public int CompareTo(Product other)
        {
            if (this.Price.CompareTo(other.Price) == 0)
            {
                if (this.Name.CompareTo(other.Name) == 0)
                {
                    return this.Type.CompareTo(other.Type);
                }
                return this.Name.CompareTo(other.Name);
            }
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price.ToString());
        }
    }

    class Program
    {
        static Set<string> productsByName = new Set<string>();
        static Dictionary<string, OrderedSet<Product>> productsByType = new Dictionary<string, OrderedSet<Product>>();
        static OrderedSet<Product> productsByPrice = new OrderedSet<Product>();
        const string END_COMMAND = "end";
        static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {

            while (true)
            {
                var input = Console.ReadLine().Split().ToArray();
                var command = input[0];

                if (command == END_COMMAND)
                {
                    Console.Write(result);
                    break;
                }

                switch (command)
                {
                    case "add":
                        var product = new Product(input[1], double.Parse(input[2]), input[3]);
                        Add(product);
                        break;

                    case "filter":
                        if (input.Length > 5)
                        {
                            FilterByPriceFromTo(double.Parse(input[4]), double.Parse(input[6]));
                        }
                        else
                        {
                            if (input[2] == "type")
                            {
                                FilterByType(input[3]);
                            }
                            else if (input[3] == "from")
                            {
                                FilterByPriceFrom(double.Parse(input[4]));
                            }
                            else if (input[3] == "to")
                            {
                                FilterByPriceTo(double.Parse(input[4]));
                            }
                        }
                        break;

                    default: throw new InvalidOperationException("Invalid command!");
                }
            }
        }

        private static void FilterByType(string type)
        {
            if (productsByType.ContainsKey(type))
            {
                result.Append("Ok: ");
                foreach (var product in productsByType[type].Take(10))
                {
                    result.Append(product + ", ");
                }
                result.Length -= 2;
            }
            else
            {
                result.AppendFormat("Error: Type {0} does not exists", type);
            }
            result.AppendLine();
        }

        private static void FilterByPriceTo(double toPrice)
        {
            result.Append("Ok: ");

            var filteredToPrice = productsByPrice
                .RangeTo(new Product() { Price = toPrice }, true)
                .Take(10);

            if (filteredToPrice.Any())
            {
                foreach (var product in filteredToPrice)
                {
                    result.Append(product + ", ");
                }
                result.Length -= 2;
            }
            result.AppendLine();
        }

        private static void FilterByPriceFrom(double fromPrice)
        {
            result.Append("Ok: ");

            var filteredFromPrice = productsByPrice
                .RangeFrom(new Product() { Price = fromPrice }, true)
                .Take(10);

            if (filteredFromPrice.Any())
            {
                foreach (var product in filteredFromPrice)
                {
                    result.Append(product + ", ");
                }
                result.Length -= 2;
            }
            result.AppendLine();
        }

        private static void FilterByPriceFromTo(double fromPrice, double toPrice)
        {
            result.Append("Ok: ");

            var filteredProducts = productsByPrice
                .Range(new Product() { Price = fromPrice}, true, new Product() { Price = toPrice }, true)
                .Take(10);

            if (filteredProducts.Any())
            {
                foreach (var product in filteredProducts)
                {
                    result.Append(product + ", ");
                }
                result.Length -= 2;
            }
            result.AppendLine();
        }

        private static void Add(Product product)
        {
            if (!productsByName.Contains(product.Name))
            {
                productsByName.Add(product.Name);
                if (!productsByType.ContainsKey(product.Type))
                {
                    productsByType.Add(product.Type, new OrderedSet<Product>());
                }
                productsByType[product.Type].Add(product);
                productsByPrice.Add(product);

                result.AppendFormat("Ok: Product {0} added successfully", product.Name);
                result.AppendLine();
            }
            else
            {
                result.AppendFormat("Error: Product {0} already exists", product.Name);
                result.AppendLine();
            }
        }
    }
}
