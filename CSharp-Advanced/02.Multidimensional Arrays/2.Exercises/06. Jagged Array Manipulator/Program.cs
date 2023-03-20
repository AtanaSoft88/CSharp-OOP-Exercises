using System;
using System.Linq;

namespace _6Ex._Jagged_Array_Manipulator
{
    class Program
    {
        private static double[][] FillJaggedArr(double[][] jagged, int n)
        {
            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().Split().Select(double.Parse).ToArray();
            }
            return jagged;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jaggedArr = new double[n][];
            FillJaggedArr(jaggedArr, n);
            for (int row = 0; row < jaggedArr.Length - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int i = 0; i < jaggedArr[row].Length; i++)
                    {
                        jaggedArr[row][i] *= 2;
                        jaggedArr[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jaggedArr[row].Length; i++)
                    {
                        jaggedArr[row][i] /= 2;
                    }
                    for (int i = 0; i < jaggedArr[row + 1].Length; i++)
                    {
                        jaggedArr[row + 1][i] /= 2;
                    }
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] inputCmd = command.Split();
                int row = int.Parse(inputCmd[1]);
                int col = int.Parse(inputCmd[2]);
                int value = int.Parse(inputCmd[3]);
                bool areAllIndexesValid = row >= 0 && row < jaggedArr.Length && col >= 0 && col < jaggedArr[row].Length;
                if (areAllIndexesValid)
                {
                    if (inputCmd[0] == "Add")
                    {
                        jaggedArr[row][col] += value;

                    }
                    else if (inputCmd[0] == "Subtract")
                    {
                        jaggedArr[row][col] -= value;
                    }
                }



                command = Console.ReadLine();
            }
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.Write(string.Join(" ", jaggedArr[i]));
                Console.WriteLine();
            }
        }
    }
}