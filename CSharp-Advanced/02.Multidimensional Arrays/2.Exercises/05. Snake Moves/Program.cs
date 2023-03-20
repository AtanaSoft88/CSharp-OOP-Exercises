using System;
using System.Linq;

namespace _05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string snakeInput = Console.ReadLine();

            char[,] matrix = new char[size[0],size[1]];
            int indexOfSymbol = 0;
            bool rightToLeft = true;
            for (int row = 0; row < size[0]; row++)
            {

                if (rightToLeft)
                {
                    for (int col = 0; col < size[1]; col++)
                    {
                        matrix[row, col] = snakeInput[indexOfSymbol++];
                        if (indexOfSymbol == snakeInput.Length)
                        {
                            indexOfSymbol = 0;
                        }
                    }
                    rightToLeft = false;

                    
                }
                else
                {
                    for (int col = size[1] - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snakeInput[indexOfSymbol++];
                        if (indexOfSymbol == snakeInput.Length)
                        {
                            indexOfSymbol = 0;
                        }
                    }
                    
                    rightToLeft = true;
                }
            }

            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
