using System;
using System.Linq;

namespace _3Ex._Maximal_Sum
{
    class Program
    {
        private static int[,] GetMatrixFilled(int[,] matrix, int n, int m)
        {
            for (int row = 0; row < n; row++)
            {
                int[] colFill = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = colFill[col];
                }
            }

            return matrix;
        }
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstDim = sizeMatrix[0];
            int secondDim = sizeMatrix[1];

            int[,] matrix = new int[firstDim, secondDim];
            GetMatrixFilled(matrix, firstDim, secondDim);

            int bestRow = 0;
            int bestCol = 0;
            int maxValue = int.MinValue;

            for (int row = 0; row < firstDim - 2; row++)
            {
                for (int col = 0; col < secondDim - 2; col++)
                {

                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                         matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                         matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum > maxValue)
                    {
                        maxValue = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxValue}");
            for (int row = bestRow; row <= bestRow + 2; row++)
            {
                for (int col = bestCol; col <= bestCol + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
