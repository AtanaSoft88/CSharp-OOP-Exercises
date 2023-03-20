using System;
using System.Linq;

namespace _07._Knight_Game
{
    class Program
    {
        static void Main(string[] args)  
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string boardChars = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = boardChars[col];
                }
            }
            int removedKnights = 0;
            while (true)
            {
                int maxAttack = 0;

                int knightRow = 0;
                int knightCol = 0;
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (board[row,col] == '0')
                        {
                            continue;
                        }

                        int currentAttacks = 0;
                        // UPleft , UPright
                        if (isInRange(board, row-2, col-1) && board[row-2,col-1]=='K')
                        {
                            currentAttacks++;
                        }

                        if (isInRange(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        // leftUp , leftDown
                        if (isInRange(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (isInRange(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        // downLeft , downRight
                        if (isInRange(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                        {
                            currentAttacks++; 
                        }

                        if (isInRange(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        //RightUp , RightDown
                        if (isInRange(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (isInRange(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (currentAttacks > maxAttack)
                        {
                            maxAttack = currentAttacks;
                            knightRow = row;
                            knightCol = col;
                        }

                    }
                }
                if (maxAttack > 0)
                {
                    removedKnights++;
                    board[knightRow, knightCol] = '0';
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }
        }

        private static bool isInRange(char[,]matrix, int rowCheck, int colCheck)
        {
            if (rowCheck >= 0 && rowCheck < matrix.GetLength(0) && colCheck >= 0 && colCheck < matrix.GetLength(1))
            {
                return true;
            }
            return false; 
        }
    }
}
