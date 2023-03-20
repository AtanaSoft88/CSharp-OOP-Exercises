using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> rangeNums = new List<int>();            
            for (int i = 1; i <= n; i++)
            {
                rangeNums.Add(i);
            }
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            for (int i = 0; i < sequence.Length; i++)
            {
                rangeNums = rangeNums.FindAll(x => x % sequence[i] == 0);
            }

            
            Console.WriteLine(string.Join(" ", rangeNums));
        }
    }
}
