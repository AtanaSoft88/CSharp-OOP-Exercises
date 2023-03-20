using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> countriesDict = new Dictionary<string, Dictionary<string, List<string>>>();
            CheckingInfo(n, countriesDict);
            PrintTheDictionary(countriesDict);

        }

        private static void PrintTheDictionary(Dictionary<string, Dictionary<string, List<string>>> countriesDict)
        {
            foreach (var country in countriesDict)
            {
                Console.WriteLine($"{country.Key}:");
                foreach (var city in country.Value)
                {
                    Console.WriteLine($"  {city.Key} -> {string.Join(", ", city.Value)}");
                }
            }
        }

        private static void CheckingInfo(int n, Dictionary<string, Dictionary<string, List<string>>> countriesDict)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!countriesDict.ContainsKey(continent))
                {
                    countriesDict.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!countriesDict[continent].ContainsKey(country))
                {
                    countriesDict[continent].Add(country, new List<string>());
                }
                countriesDict[continent][country].Add(city);
            }
        }
    }
}
