using System;
using System.Linq;

namespace _02._Warships___Matrix
{

    class Program
    {
        private static bool isInRange(string[][] matrix, int Row, int Col)
        {
            if (Row >= 0 && Row < matrix.Length && Col >= 0 && Col < matrix[Row].Length)
            {
                return true;
            }
            return false;
        }
        private static string[][] FillJaggedString(string[][] jaggedString, int size)
        {
            
            for (int row = 0; row < size; row++)
            {
                jaggedString[row] = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                
            }
            return jaggedString;

        }
        static void Main(string[] args)
        {
            int firstPlayerCount = 0;
            int secondPlayerCount = 0;
            int n = int.Parse(Console.ReadLine());
            int[] coordinatesInput = Console.ReadLine().
                Split(new char[] {' ',','},StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            string[][] warshipsField = new string[n][];

            FillJaggedString(warshipsField, n);

            for (int row = 0; row < n; row++)
            {
                
                for (int col = 0; col < warshipsField[row].Length; col++)
                {
                    if (warshipsField[row][col] == "<")
                    {
                        firstPlayerCount++;
                    }
                    else if (warshipsField[row][col] == ">")
                    {
                        secondPlayerCount++;
                    }
                }
            }
            int totalShipsCount = firstPlayerCount + secondPlayerCount;
            bool isFinalResulDraw = true;
            for (int i = 0; i < coordinatesInput.Length-1; i+=2)
            {
                int currentRow = coordinatesInput[i];
                int currentCol = coordinatesInput[i + 1];

                if (isInRange(warshipsField,currentRow,currentCol))
                {
                    if (warshipsField[currentRow][currentCol] == "#")
                    {
                        warshipsField[currentRow][currentCol] = "X";
                        // Up
                        if (isInRange(warshipsField,currentRow-1,currentCol))
                        {
                            if (warshipsField[currentRow - 1][currentCol] == "<")
                            {
                                warshipsField[currentRow - 1][currentCol] = "X";
                                firstPlayerCount--;
                            }
                            else if (warshipsField[currentRow - 1][currentCol] == ">")
                            {
                                warshipsField[currentRow - 1][currentCol] = "X";
                                secondPlayerCount--;
                            }
                        }
                        //Down
                        if (isInRange(warshipsField, currentRow+1 , currentCol))
                        {
                            if (warshipsField[currentRow + 1][currentCol] == "<")
                            {
                                warshipsField[currentRow + 1][currentCol] = "X";
                                firstPlayerCount--;
                            }
                            else if (warshipsField[currentRow + 1][currentCol] == ">")
                            {
                                warshipsField[currentRow + 1][currentCol] = "X";
                                secondPlayerCount--;
                            }
                        }
                        //Left
                        if (isInRange(warshipsField, currentRow, currentCol-1))
                        {
                            if (warshipsField[currentRow][currentCol-1] == "<")
                            {
                                warshipsField[currentRow][currentCol - 1] = "X";
                                firstPlayerCount--;
                            }
                            else if (warshipsField[currentRow][currentCol - 1] == ">")
                            {
                                warshipsField[currentRow][currentCol - 1] = "X";
                                secondPlayerCount--;
                            }
                        }
                        //Right
                        if (isInRange(warshipsField, currentRow, currentCol+1))
                        {
                            if (warshipsField[currentRow][currentCol + 1] == "<")
                            {
                                warshipsField[currentRow][currentCol + 1] = "X";
                                firstPlayerCount--;
                            }
                            else if (warshipsField[currentRow][currentCol + 1] == ">")
                            {
                                warshipsField[currentRow][currentCol + 1] = "X";
                                secondPlayerCount--;
                            }
                        }
                        //UP LEFT
                        if (isInRange(warshipsField, currentRow-1, currentCol-1))
                        {
                            if (warshipsField[currentRow-1][currentCol - 1] == "<")
                            {
                                warshipsField[currentRow - 1][currentCol - 1] = "X";
                                firstPlayerCount--;
                            }
                            else if (warshipsField[currentRow - 1][currentCol - 1] == ">")
                            {
                                warshipsField[currentRow - 1][currentCol - 1] = "X";
                                secondPlayerCount--;
                            }
                        }
                        //UP RIGHT
                        if (isInRange(warshipsField, currentRow-1, currentCol+1))
                        {
                            if (warshipsField[currentRow - 1][currentCol + 1] == "<")
                            {
                                warshipsField[currentRow - 1][currentCol + 1] = "X";
                                firstPlayerCount--;
                            }
                            else if (warshipsField[currentRow - 1][currentCol + 1] == ">")
                            {
                                warshipsField[currentRow - 1][currentCol + 1] = "X";
                                secondPlayerCount--;
                            }
                        }
                        //DOWN LEFT
                        if (isInRange(warshipsField, currentRow+1, currentCol-1))
                        {
                            if (warshipsField[currentRow + 1][currentCol - 1] == "<")
                            {
                                warshipsField[currentRow + 1][currentCol - 1] = "X";
                                firstPlayerCount--;
                            }
                            else if (warshipsField[currentRow + 1][currentCol - 1] == ">")
                            {
                                warshipsField[currentRow + 1][currentCol - 1] = "X";
                                secondPlayerCount--;
                            }
                        }
                        //DOWN RIGHT
                        if (isInRange(warshipsField, currentRow+1, currentCol+1))
                        {
                            if (warshipsField[currentRow + 1][currentCol + 1] == "<")
                            {
                                warshipsField[currentRow + 1][currentCol + 1] = "X";
                                firstPlayerCount--;
                            }
                            else if (warshipsField[currentRow + 1][currentCol + 1] == ">")
                            {
                                warshipsField[currentRow + 1][currentCol + 1] = "X";
                                secondPlayerCount--;
                            }
                        }
                    }
                    else if (warshipsField[currentRow][currentCol] == "<") // first
                    {
                        warshipsField[currentRow][currentCol] = "X";
                        firstPlayerCount--;
                    }
                    else if (warshipsField[currentRow][currentCol] == ">") // first
                    {
                        warshipsField[currentRow][currentCol] = "X";
                        secondPlayerCount--;
                    }

                    if (firstPlayerCount <= 0 || secondPlayerCount <= 0)
                    {
                        isFinalResulDraw = false;
                        break;
                    }
                }

            }
            int totalRemaining = firstPlayerCount + secondPlayerCount;

            if (isFinalResulDraw)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerCount} ships left. Player Two has {secondPlayerCount} ships left.");
            }
            else 
            {
                if (firstPlayerCount <= 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalShipsCount - totalRemaining} ships have been sunk in the battle.");
                }
                else
                {
                    Console.WriteLine($"Player One has won the game! {totalShipsCount - totalRemaining} ships have been sunk in the battle.");
                }
            }

            //Console.WriteLine("======================================================");
            // ONLY FOR CHECK FINAL MATRIX OVERVIEW
            //for (int i = 0; i < warshipsField.Length; i++)
            //{
            //    for (int j = 0; j < warshipsField[i].Length; j++)
            //    {
            //        Console.Write(warshipsField[i][j]+ " ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
