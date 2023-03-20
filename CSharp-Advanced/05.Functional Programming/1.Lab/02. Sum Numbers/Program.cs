using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //4, 2, 1, 3, 5, 7, 1, 4, 2, 12

            int[] numbs = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Console.WriteLine($"{numbs.Select(x => x).Count() + Environment.NewLine + numbs.Sum()}");
        }
    }
}
