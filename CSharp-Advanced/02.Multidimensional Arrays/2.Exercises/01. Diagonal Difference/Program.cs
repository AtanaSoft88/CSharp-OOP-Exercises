using System;
using System.Linq;

namespace _01._Diagonal_Difference
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
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];

            FillMatrix(matrix,n);
            int sumPrimary = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row == col)
                    {
                        sumPrimary += matrix[row, col];
                    }
                }
            }
            int sumSecondary = 0;
            int currentMaxCol = n;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (col == currentMaxCol-1)
                    {
                        sumSecondary += matrix[row, col];
                        currentMaxCol--;
                    }
                }
            }
            int diff = Math.Abs(sumPrimary - sumSecondary);
            Console.WriteLine(diff);


        }
    }
}
