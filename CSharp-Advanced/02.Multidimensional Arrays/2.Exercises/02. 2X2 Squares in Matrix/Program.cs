using System;
using System.Linq;

namespace _02._2X2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[size[0], size[1]];
            for (int row = 0; row < size[0]; row++)
            {
                char[] letterArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = letterArray[col];
                }
            }
            int countEquals = 0;
            for (int row = 0; row < size[0] - 1; row++)
            {
                for (int col = 0; col < size[1] - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        countEquals++;
                    }
                }
            }
            Console.WriteLine(countEquals);
        }
    }
}
