using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputTxt = Console.ReadLine();

            SortedDictionary<char, int> letterDict = new SortedDictionary<char, int>();

            foreach (var ch in inputTxt)
            {
                if (!letterDict.ContainsKey(ch))
                {
                    letterDict.Add(ch,0);
                }
                letterDict[ch]++;
            }

            foreach (var kvp in letterDict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
