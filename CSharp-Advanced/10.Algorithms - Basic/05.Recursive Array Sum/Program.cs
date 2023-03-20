using System;
using System.Linq;

namespace _01.Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(Sum(array, array.Length-1));
        }

        public static int Sum(int[] array, int index)
        {
            if (index == 0)
            {
                return array[index];
            }
            int result = array[index] + Sum(array, --index);
            return result;
            


        }
    }
}
