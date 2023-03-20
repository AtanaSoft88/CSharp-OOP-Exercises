using System;
using System.Linq;

namespace _06._Jagged_Array_Modification_v2
{
    class Program
    {
        static int[][] FillMatrix(int[][] jagged, int n)
        {
            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            return jagged;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedMatrix = new int[n][];

            FillMatrix(jaggedMatrix, n);

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] input = command.Split();

                int currRow = int.Parse(input[1]);
                int currCol = int.Parse(input[2]);
                int value = int.Parse(input[3]);
                if (input[0] == "Add")
                {
                    if (currRow >= 0 && currRow < jaggedMatrix.Length && currCol >= 0 && currCol < jaggedMatrix[currRow].Length)
                    {
                        jaggedMatrix[currRow][currCol] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else
                {
                    if (currRow >= 0 && currRow < jaggedMatrix.Length && currCol >= 0 && currCol < jaggedMatrix[currRow].Length)
                    {
                        jaggedMatrix[currRow][currCol] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var item in jaggedMatrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }

        }
    }
}
