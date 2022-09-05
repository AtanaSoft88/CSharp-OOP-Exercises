using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            try
            {
                 people = ReadPeople();
                 products = ReadProducts();
            }
            catch (ArgumentException exc)
            {

                Console.WriteLine(exc.Message);
                return;
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = parts[0];
                string productName = parts[1];

                Person person = people[personName];
                Product product = products[productName];

                try
                {
                    person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }

                
            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }
        }

        public static Dictionary<string, Person> ReadPeople()
        {
            Dictionary<string, Person> result = new Dictionary<string, Person>();
            string[] parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                string[] nameNumPair = part.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = nameNumPair[0];
                decimal money = decimal.Parse(nameNumPair[1]);
                if (!result.ContainsKey(name))
                {
                    result.Add(name, new Person(name, money));
                }
            }
            return result;
        }

        public static Dictionary<string, Product> ReadProducts()
        {
            Dictionary<string, Product> result = new Dictionary<string, Product>();
            string[] parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                string[] nameProdPair = part.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string productName = nameProdPair[0];
                decimal cost = decimal.Parse(nameProdPair[1]);
                if (!result.ContainsKey(productName))
                {
                    result.Add(productName, new Product(productName, cost));
                }
            }
            return result;
        }
    }
}
