using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            // 20 30
            //even
            //-> 20 22 24 26 28 30

            int[] limits = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string cmd = Console.ReadLine();

            List<int> sequenceNums = new List<int>();
            for (int i = limits[0]; i <= limits[1]; i++)
            {
                sequenceNums.Add(i);
            }

            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;

            List<int> resultNumbers = cmd == "even" ? sequenceNums = sequenceNums.FindAll(n => isEven(n)) :
                                                      sequenceNums = sequenceNums.FindAll(n => isOdd(n));

            Console.WriteLine(string.Join(" ", resultNumbers));

        }
    }
}
