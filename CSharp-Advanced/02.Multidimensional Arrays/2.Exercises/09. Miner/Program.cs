using System;
using System.Linq;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[size, size];

            int coalsCount = 0;
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'c')
                    {
                        coalsCount++;
                    }
                    else if (matrix[row, col] == 's')
                    {
                        playerRow = row;
                        playerCol = col;

                    }
                }
            }

            foreach (var direction in directions)
            {
                int nextRow = 0;
                int nextCol = 0;
                if (direction == "left")
                {
                    nextCol = -1;
                }
                else if (direction == "right")
                {
                    nextCol = 1;
                }
                else if (direction == "down")
                {
                    nextRow = 1;
                }
                else if (direction == "up")
                {
                    nextRow = -1;
                }

                if (!IsInRange(matrix,playerRow + nextRow,playerCol + nextCol))
                {
                    continue; 
                }

                playerRow += nextRow;
                playerCol += nextCol;

                if (matrix[playerRow,playerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    Environment.Exit(0);
                }

                if (matrix[playerRow, playerCol] == 'c')
                {
                    matrix[playerRow, playerCol] = '*';
                    coalsCount--;
                    if (coalsCount == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                        Environment.Exit(0);
                    }
                }
                // if nextRow = e 
                // if nextCell =  coal ,while c>0
            }

            Console.WriteLine($"{coalsCount} coals left. ({playerRow}, {playerCol})");
        }

        private static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row>=0 && row < matrix.GetLength(0) && col>=0 && col < matrix.GetLength(1);
        }
    }
}
