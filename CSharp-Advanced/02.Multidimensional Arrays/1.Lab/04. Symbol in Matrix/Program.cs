using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size,size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            int rowFound = 0;
            int colFound = 0;
            bool isCharFound = false;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row,col] == symbol)
                    {
                        rowFound = row;
                        colFound = col;
                        isCharFound = true;
                        break;
                    }
                }
                if (isCharFound)
                {
                    break;
                }
            }

            if (isCharFound)
            {
                Console.WriteLine($"({rowFound}, {colFound})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
