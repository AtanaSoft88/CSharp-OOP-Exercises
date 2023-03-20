using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //4, 2, 1, 3, 5, 7, 1, 4, 2, 12


            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

         
            Console.WriteLine(string.Join(", ",numbers.Where(x=>x % 2 ==0).OrderBy(x=>x)));

        }
    }
}
