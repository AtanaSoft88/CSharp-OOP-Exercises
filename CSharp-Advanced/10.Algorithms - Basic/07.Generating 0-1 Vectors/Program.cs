using System;

namespace _3._Generating_0_1_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            GenCombinations01(array, 0);
        }
        private static void GenCombinations01(int[]array, int index)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(string.Join("", array));
                return;
            }
            for (int i = 0; i < 2; i++)
            {
                array[index] = i;
                GenCombinations01(array, index+1);
            }
        }
    }
}
