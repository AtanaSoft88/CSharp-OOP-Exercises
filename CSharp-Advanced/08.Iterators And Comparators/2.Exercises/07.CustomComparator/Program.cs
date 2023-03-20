using System;
using System.Linq;

namespace _07.CustomComparator
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // even -> ods - as functions
            //1 2 3 4 5 6 -> 2 4 6 1 3 5
            Func<int, int, int> customComparer = (x, y) =>
            {
                return (x % 2 == 0 && y % 2 != 0) ? -1 :    // put number to the left
                       (x % 2 != 0 && y % 2 == 0) ? 1 :     // put number to the right
                        x > y ? 1 :                         // put number to the right
                        x < y ? -1 :                        // put number to the left
                        0;                                  // dont move the number                    

            };
            Array.Sort(numbers, (x, y) => customComparer(x, y));

            Console.WriteLine(string.Join(" ", numbers));

            //numbers = numbers.OrderBy(x => x % 2 != 0).ThenBy(x => x % 2 == 0).ToArray();
            //Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
