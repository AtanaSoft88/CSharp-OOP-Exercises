using System;
using System.Linq;

namespace _02.JaggedMatrix
{
    class Program
    {
        private static bool isInRange(char[][] matrix, int Row, int Col)
        {
            if (Row >= 0 && Row < matrix.Length && Col >= 0 && Col < matrix[Row].Length)
            {
                return true;
            }
            return false;
        }

        private static int[][] FillJaggedArr(int[][] jagged, int n)
        {
            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            return jagged;
        }

        private static string[][] FillJaggedStringSquare(string[][] jagged, int n)
        {
            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            return jagged;
        }

        private static string[][] FillJaggedString(string[][] stringMatrix, int n)
        {
            for (int row = 0; row < stringMatrix.Length; row++)
            {
                string[] inputStringArr = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < stringMatrix[row].Length; col++)
                {
                    stringMatrix[row][col] = inputStringArr[col];
                }
            }
            return stringMatrix;
        }

        private static char[][] FillJaggedChar(char[][] jaggedCh, int size)
        {
            for (int row = 0; row < size; row++)
            {
                jaggedCh[row] = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();               

            }
            return jaggedCh;

        }
        //=======================================================================================================
        static void Main(string[] args)
        {
            //Matrix jagged used for square case of input
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            FillJaggedChar(matrix, n);
            // After reading matrix we can pass through all the matrix searching for coordinates of object.
            for (int row = 0; row < n; row++)
            {                
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        // TODO save the coordinates of row and col to find object's current position if needed
                    }

                }

            }
            

            //Matrix jagged used for input with different row length ( number of cols is different)

            string[][] stringMatrix = new string[n][];
            FillJaggedString(stringMatrix,n);


            // Print Matrix at the end

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        
    }
}
