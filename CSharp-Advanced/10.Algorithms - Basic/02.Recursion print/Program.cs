using System;
using System.Linq;

namespace _01.Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Print(10);
        }

        public static void Print(int number)
        {
            if (number == 0)
            {
                return;
            }

            Console.WriteLine($"{number} before");
            Print(number - 1);
            Console.WriteLine($"{number} after");


        }
    }
}
