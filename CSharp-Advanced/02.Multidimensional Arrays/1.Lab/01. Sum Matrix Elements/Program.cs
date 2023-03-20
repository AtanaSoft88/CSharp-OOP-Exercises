using System;
using System.Linq;

namespace _01._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];

            FillTheMatrix(matrix, sizeMatrix);

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            
            SumMatrixElements(matrix);
        }

        private static void SumMatrixElements(int[,] matrix)
        {
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }
            Console.WriteLine(sum);
            
        }

        private static int[,] FillTheMatrix(int[,] matrix, int[] sizeMatrix)
        {
            for (int row = 0; row < sizeMatrix[0]; row++)
            {
                int[] rowInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < sizeMatrix[1]; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
            return matrix;
        }
    }
}
