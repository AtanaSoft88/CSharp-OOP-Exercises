using System;
using System.Numerics;

namespace _00.DemoSumRecursive
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());  // number = 10?
            
            //Console.WriteLine(SumElements(n));            
            //Console.WriteLine(FactorialCalc(n));

            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(ArrayElementsSum1(numbers, numbers.Length-1));

            Console.WriteLine(ArrayElementsSum2(numbers, 0));
        }

        private static int ArrayElementsSum1(int[] arr ,int index)
        {
            if (index == 0)
            {
                return arr[index];
            }
            
            return arr[index] + ArrayElementsSum1(arr, --index);
            
        }

        private static int ArrayElementsSum2(int[] arr, int index)
        {
            if (index == arr.Length-1)
            {
                return arr[index];
            }
            
            return arr[index] + ArrayElementsSum2(arr, index+1);

        }

        private static BigInteger FactorialCalc(BigInteger n)
        {
            if (n==0)
            {
                return 1;
            }
            BigInteger totalSum = n * FactorialCalc(n - 1);
            return totalSum;
        }

        private static int SumElements(int n)
        {
            if (n==0)
            {
                return 0;
            }
            int currentSum = n + SumElements(n - 1);
            return currentSum;
            
        }
    }   
}
