using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];

            FillTheMatrix(matrix, sizeMatrix);

            PrintColsSum(sizeMatrix, matrix);

        }

        private static void PrintColsSum(int[] sizeMatrix, int[,] matrix)
        {
            for (int col = 0; col < sizeMatrix[1]; col++)
            {
                int sumCols = 0;
                for (int row = 0; row < sizeMatrix[0]; row++)
                {
                    sumCols += matrix[row, col];
                }
                Console.WriteLine(sumCols);
            }
        }

        private static int[,] FillTheMatrix(int[,] matrix, int[] sizeMatrix)
        {
            for (int row = 0; row < sizeMatrix[0]; row++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < sizeMatrix[1]; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
            return matrix;
        }
    }
}
