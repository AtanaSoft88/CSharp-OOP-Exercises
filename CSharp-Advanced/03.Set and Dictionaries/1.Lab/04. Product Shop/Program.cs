using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, Dictionary<string, double>> registerShops = new Dictionary<string, Dictionary<string, double>>();
            while (command != "Revision")
            {
                string[] shops = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shopName = shops[0];
                string product = shops[1];
                double price = double.Parse(shops[2]);

                if (!registerShops.ContainsKey(shopName))
                {
                    registerShops.Add(shopName, new Dictionary<string, double>());
                }
                if (!registerShops[shopName].ContainsKey(product))
                {
                    registerShops[shopName].Add(product, new double());
                }
                registerShops[shopName][product] = price;

                command = Console.ReadLine();
            }

            foreach (var shop in registerShops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }

        }
    }
}
