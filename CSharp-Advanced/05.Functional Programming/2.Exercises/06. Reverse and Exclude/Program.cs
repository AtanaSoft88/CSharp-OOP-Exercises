using System;
using System.Linq;

namespace _06._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 2 3 4 5 6         => 5 3 1
            //2     

            int[] nums = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
            int n = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = x => x % n != 0;
            nums = nums.Where(x => isDivisible(x)).ToArray();
            nums.ToList().ForEach(x => Console.Write(string.Join(" ",x + " ")));
        }
    }
}
