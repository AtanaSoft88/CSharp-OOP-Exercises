using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_of_Predicates_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> rangeNums = Enumerable.Range(1,n).ToList();  // taka si pulnim list kato imame granicite mu
            
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<Predicate<int>> predicatesNum = new List<Predicate<int>>();

            foreach (var num in sequence)
            {
                predicatesNum.Add(x => x % num == 0);
            }

            foreach (var number in rangeNums)
            {
                bool isDivisible = true;
                foreach (var predicate in predicatesNum)
                {
                    if (!predicate(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    Console.Write(number + " ");
                }
            }
            
        }
    }
}
