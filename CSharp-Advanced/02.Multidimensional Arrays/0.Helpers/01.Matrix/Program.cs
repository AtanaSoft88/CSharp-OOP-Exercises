using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Matrix
{
    class Program
    {
        // Check if inside the Matrix Variant 1
        private static bool IsInRange2(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        // Check if inside the Matrix Variant 2
        private static bool isInRange(char[,] matrix, int rowCheck, int colCheck)
        {
            if (rowCheck >= 0 && rowCheck < matrix.GetLength(0) && colCheck >= 0 && colCheck < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        // Fill INEGER Matrix
        static int[,] FillIntMatrix(int[,] matrix, int size1, int size2)
        {
            for (int row = 0; row < size1; row++)
            {
                int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < size2; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }

        // Fill Char Matrix
        static char[,] FillCharMatrix(char[,] matrix, int size1, int size2)
        {
            for (int row = 0; row < size1; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size2; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }

        private static string[,] FillStringMatrix(string[,] matrixString, int size1, int size2)
        {
            for (int row = 0; row < size1; row++)
            {
                string[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size2; col++)
                {
                    matrixString[row, col] = inputRow[col];
                }
            }

            return matrixString;
        }
        //=========================================================================================================================

        static void Main(string[] args)
        {
            // Int Square  Matrix ============================
            int[] sizeMatrix = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];

            FillIntMatrix(matrix, sizeMatrix[0], sizeMatrix[1]);



            // Char Square Matrix  ===================================

            char[,] matrixChars = new char[sizeMatrix[0], sizeMatrix[1]];

            FillCharMatrix(matrixChars,sizeMatrix[0],sizeMatrix[1]);


            // String Square Matrix =================================

            string[,] matrixString = new string[sizeMatrix[0], sizeMatrix[1]];
            FillStringMatrix(matrixString,sizeMatrix[0],sizeMatrix[1]);

            // Print String Matrix at the end

            for (int row = 0; row < matrixString.GetLength(0); row++)
            {
                for (int col = 0; col < matrixString.GetLength(1); col++)
                {
                    Console.Write(matrixString[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        
    }
}
