using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string cmd = Console.ReadLine();
            Action<int[]> addNumber = inputArray =>
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    inputArray[i] += 1;
                }
            };

            Action<int[]> subtractNumber = inputArray =>
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    inputArray[i] -= 1;
                }
            };

            

            Func<int[], int[]> multiply = inputArray =>
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    inputArray[i] *= 2;
                }
                return inputArray;
            };
            Action<int[]> print = x => Console.WriteLine(string.Join(" ",x));


            while (cmd!="end")
            {
                if (cmd == "add")
                {
                    addNumber(nums);
                }
                else if (cmd == "subtract")
                {
                    subtractNumber(nums);
                }
                else if (cmd == "multiply")
                {
                    multiply(nums);
                }
                else
                {
                    print(nums);
                }


                cmd = Console.ReadLine();
            }
        }
    }
}
