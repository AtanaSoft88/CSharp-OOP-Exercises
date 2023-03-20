using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximal_Sum
{
    class Program
    {
        static int[,] FillMatrix(int[,] matrix, int[] dimension)
        {
            for (int row = 0; row < dimension[0]; row++)
            {
                int[] inputRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); 
                for (int col = 0; col < dimension[1]; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }
            return matrix;

        }

        private static int[,] CurrentSubMatrix(int[,] subMatrix3x3, int[] currentSequence)
        {
            Queue<int> input = new Queue<int>(currentSequence);
            for (int row = 0; row < 3; row++)
            {                
                for (int col = 0; col < 3; col++)
                {
                    if (input.Count > 0)
                    {
                        subMatrix3x3[row, col] = input.Dequeue();
                    }
                }
            }
            return subMatrix3x3;
        }
        static void Main(string[] args)
        {
            //4 5
            //1 5 5 2 4
            //2 1 4 14 3
            //3 7 11 2 8
            //4 8 12 16 4

            int[] sizeMatrix = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];

            FillMatrix(matrix,sizeMatrix);

            int[,] subMatrix3x3 = new int[3,3];
            int max3x3Sum = int.MinValue;
            for (int row = 0; row < sizeMatrix[0] - 2; row++)
            {
                for (int col = 0; col < sizeMatrix[1] - 2; col++)
                {
                    int[] currentSum = new int[] { matrix[row, col],matrix[row, col + 1],matrix[row, col + 2],matrix[row + 1, col], matrix[row + 1, col + 1], matrix[row + 1, col + 2], matrix[row + 2, col], matrix[row + 2, col + 1], matrix[row + 2, col + 2] } ;

                    if (currentSum.Sum() > max3x3Sum)
                    {
                        max3x3Sum = currentSum.Sum();

                        CurrentSubMatrix(subMatrix3x3, currentSum);
                    }
                }
            }
            Console.WriteLine($"Sum = {max3x3Sum}");
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(subMatrix3x3[row, col] + " ");
                }
                Console.WriteLine();
            }

        }

        
    }
}
