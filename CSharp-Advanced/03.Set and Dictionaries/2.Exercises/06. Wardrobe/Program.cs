using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothesDict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {                
                string[] items = Console.ReadLine()
                .Split(new string[] { " -> ",","}, StringSplitOptions.RemoveEmptyEntries);

                string color = items[0];
                            
               
                if (!clothesDict.ContainsKey(color))
                {
                    clothesDict.Add(color, new Dictionary<string, int>());
                }
                for (int j = 1; j < items.Length; j++)
                {
                    if (!clothesDict[color].ContainsKey(items[j]))
                    {
                        clothesDict[color].Add(items[j],0);
                    }
                    clothesDict[color][items[j]]++;

                }

            }
            string[] itemNeeded = Console.ReadLine().Split();
            string neededColor = itemNeeded[0];
            string neededItem = itemNeeded[1];
            foreach (var kvp in clothesDict)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var item in kvp.Value)
                {
                    if (item.Key == neededItem && kvp.Key == neededColor)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
