using System;
using System.Linq;

namespace _4Ex._Matrix_Shuffling
{

    class Program
    {
        private static string[,] ReadMatrix(string[,] matrix, int first, int second)
        {
            for (int row = 0; row < first; row++)
            {
                string[] colReading = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < second; col++)
                {
                    matrix[row, col] = colReading[col];
                }

            }
            return matrix;
        }

        private static void MatrixPrint(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[size[0], size[1]];
            ReadMatrix(matrix, size[0], size[1]);

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "swap" && input.Length == 5)
                {
                    int row1 = int.Parse(input[1]);
                    int col1 = int.Parse(input[2]);
                    int row2 = int.Parse(input[3]);
                    int col2 = int.Parse(input[4]);

                    if (row1 >=0 && row1 < size[0] 
                        && col1 >=0 && col1 < size[1] 
                        && row2 >= 0 && row2 < size[0] 
                        && col2 >=0 && col2 < size[1])
                    {
                        string tempColRow = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2,col2];
                        matrix[row2, col2] = tempColRow;
                        MatrixPrint(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                command = Console.ReadLine();
            }
        }
    }

}