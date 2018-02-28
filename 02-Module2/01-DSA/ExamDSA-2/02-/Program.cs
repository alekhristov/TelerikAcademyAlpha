using System;
using System.Text;
using Wintellect.PowerCollections;

namespace _02_
{
    public struct Order : IComparable<Order>
    {
        public Order(string name, double price, string consumer)
        {
            this.Name = name;
            this.Price = price;
            this.Consumer = consumer;
            this.ToStringProperty = $"{"{"}{this.Name};{this.Consumer};{this.Price:f2}{"}"}";
        }

        public string Name { get; private set; }

        public double Price { get; internal set; }

        public string Consumer { get; private set; }

        public string ToStringProperty { get; set; }

        public int CompareTo(Order other)
        {
            return this.ToString().CompareTo(other.ToString());
        }

        public override string ToString()
        {
            return this.ToStringProperty;
        }
    }

    public class OrdersSystem
    {
        static MultiDictionary<string, Order> ordersByConsumer = new MultiDictionary<string, Order>(true);
        static OrderedMultiDictionary<double, Order> ordersByPrice = new OrderedMultiDictionary<double, Order>(true);
        static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var firstWhitespaceIndex = input.IndexOf(' ');

                if (input.StartsWith("AddOrder"))
                {
                    var commandParams = input.Substring(firstWhitespaceIndex + 1).Split(';');

                    AddOrder(commandParams);
                }
                else if (input.StartsWith("DeleteOrders"))
                {
                    var consumer = input.Substring(firstWhitespaceIndex + 1);

                    DeleteOrders(consumer);
                }
                else if (input.StartsWith("FindOrdersByPriceRange"))
                {
                    var commandParams = input.Substring(firstWhitespaceIndex + 1).Split(';');
                    var fromPrice = double.Parse(commandParams[0]);
                    var toPrice = double.Parse(commandParams[1]);

                    FindOrdersByPriceRange(fromPrice, toPrice);
                }
                else if (input.StartsWith("FindOrdersByConsumer"))
                {
                    var consumer = input.Substring(firstWhitespaceIndex + 1);

                    FindOrdersByConsumer(consumer);
                }
            }

            Console.Write(result);
        }

        private static void FindOrdersByConsumer(string consumer)
        {
            if (ordersByConsumer.ContainsKey(consumer) && ordersByConsumer[consumer].Count > 0)
            {
                var bag = new OrderedBag<string>();

                foreach (var order in ordersByConsumer[consumer])
                {
                    bag.Add(order.ToString());
                }

                result.AppendLine(string.Join("\n", bag));
            }
            else
            {
                result.AppendLine("No orders found");
            }
        }

        private static void FindOrdersByPriceRange(double fromPrice, double toPrice)
        {
            var ordersInPriceRange = ordersByPrice
                .Range(fromPrice, true, toPrice, true);

            if (ordersInPriceRange.Count > 0)
            {
                var bag = new OrderedBag<string>();

                foreach (var pair in ordersInPriceRange)
                {
                    foreach (var item in pair.Value)
                    {
                        bag.Add(item.ToString());
                    }
                }

                result.AppendLine(string.Join("\n", bag));
            }
            else
            {
                result.AppendLine("No orders found");
            }
        }

        private static void DeleteOrders(string consumer)
        {
            if (ordersByConsumer.ContainsKey(consumer) && ordersByConsumer[consumer].Count > 0)
            {
                var numberOfOrdersFound = ordersByConsumer[consumer].Count;

                foreach (var item in ordersByConsumer[consumer])
                {
                    ordersByPrice.Remove(item.Price, item);
                }

                ordersByConsumer.Remove(consumer);

                result.AppendLine($"{numberOfOrdersFound} orders deleted");
            }
            else
            {
                result.AppendLine("No orders found");
            }
        }

        private static void AddOrder(string[] commandParams)
        {
            var name = commandParams[0];
            var price = double.Parse(commandParams[1]);
            var consumer = commandParams[2];

            var order = new Order(name, price, consumer);

            ordersByConsumer[consumer].Add(order);
            ordersByPrice[price].Add(order);

            result.AppendLine("Order added");
        }
    }
}
