using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            HashSet<string> uniqueSet = new HashSet<string>();

            FillingTheSet(uniqueSet,lines);
            PrintUniqueElements(uniqueSet);

        }

        private static void PrintUniqueElements(HashSet<string> set)
        {
            foreach (var item in set.OrderBy(x=>x))
            {
                Console.Write(item + " ");
            }
        }

        private static HashSet<string> FillingTheSet(HashSet<string> uniqueSet, int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] chemicalElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                chemicalElements.ToList().ForEach(x=>uniqueSet.Add(x));
            }

            return uniqueSet;

        }
    }
}
