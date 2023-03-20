using System;
using System.Linq;

namespace _05._Square_with_Maximum_Sum_v2
{
    class Program
    {
        static int[,] FillMatrix(int[,] matrix, int size1, int size2)
        {
            for (int row = 0; row < size1; row++)
            {
                int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < size2; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }
        static void Main(string[] args)
        {
            //            3, 6
            //7, 1, 3, 3, 2, 1
            //1, 3, 9, 8, 5, 6
            //4, 6, 7, 9, 1, 0

            int[] sizeMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];

            FillMatrix(matrix, sizeMatrix[0], sizeMatrix[1]);

            int maxValue = int.MinValue;
            int sum = 0;
            int first = 0;
            int second = 0;
            int third = 0;
            int forth = 0;

            for (int row = 0; row < sizeMatrix[0] - 1; row++)
            {
                for (int col = 0; col < sizeMatrix[1] - 1; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > maxValue)
                    {
                        maxValue = sum;
                        first = matrix[row, col];
                        second = matrix[row, col + 1];
                        third = matrix[row + 1, col];
                        forth = matrix[row + 1, col + 1];
                    }
                }

            }
            Console.WriteLine($"{first} {second}");
            Console.WriteLine($"{third} {forth}");
            Console.WriteLine(maxValue);
        }
    }
}
