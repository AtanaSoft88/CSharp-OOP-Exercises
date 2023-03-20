using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class Program
    {
        static int[,] FillMatrix(int[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
            return matrix;

        }
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeMatrix,sizeMatrix];
            FillMatrix(matrix,sizeMatrix);

            int primaryDiagonalSum = 0;
            int secondary = 0;
            for (int row = 0; row < sizeMatrix; row++)
            {
                for (int col = 0; col < sizeMatrix; col++)
                {
                    if (row == col)
                    {
                        primaryDiagonalSum += matrix[row,col];
                        
                    }
                    
                }
            }
            Console.WriteLine(primaryDiagonalSum);

        }
    }
}
