using System;
using System.Linq;

namespace _08._Bombs
{
    class Program
    {
        private static bool isInRange(int[,] matrix, int rowCheck, int colCheck)
        {
            if (rowCheck >= 0 && rowCheck < matrix.GetLength(0) && colCheck >= 0 && colCheck < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int[] indexes = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < indexes.Length; i+=2)
            {
                int row = indexes[i];
                int col = indexes[i+1];

                if (matrix[row,col] <=0)
                {
                    continue;
                }
                int value = matrix[row, col];
                if (isInRange(matrix, row-1, col) && matrix[row - 1,col]>0)  // up
                {
                    matrix[row - 1, col] -= value;
                }
                if (isInRange(matrix, row + 1, col) && matrix[row + 1, col] > 0) // down
                {
                    matrix[row + 1, col] -= value;
                }
                if (isInRange(matrix, row, col-1) && matrix[row, col -1] > 0) // Left
                {
                    matrix[row, col - 1] -= value;
                }
                if (isInRange(matrix, row, col + 1) && matrix[row, col + 1] > 0) // Left
                {
                    matrix[row, col + 1] -= value;
                }

                if (isInRange(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0) // UPLeft
                {
                    matrix[row - 1, col - 1 ] -= value;
                }
                if (isInRange(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0) // UPRight
                {
                    matrix[row - 1, col + 1] -= value;
                }

                if (isInRange(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0) // DownLeft
                {
                    matrix[row + 1, col + 1] -= value;
                }
                if (isInRange(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0) // DownRight
                {
                    matrix[row + 1, col - 1] -= value;
                }

                matrix[row, col] = 0;
            }
            int aliveCount = 0;
            int aliveSum = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row,col] >0)
                    {
                        aliveCount++;
                        aliveSum += matrix[row, col];
                                              
                    }
                    
                }
            }
            Console.WriteLine($"Alive cells: {aliveCount}");
            Console.WriteLine($"Sum: {aliveSum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                    
                }
                Console.WriteLine();
            }

            

        }
    }
}
