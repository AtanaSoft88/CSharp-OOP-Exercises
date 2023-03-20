using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string[][] matrix = new string[size[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string cmd = Console.ReadLine();
            while (cmd !="END")
            {
                string[] input = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "swap" && input.Length == 5)
                {
                    int oldRow1 = int.Parse(input[1]);
                    int oldCol1 = int.Parse(input[2]);

                    int newRow1 = int.Parse(input[3]);
                    int newCol1 = int.Parse(input[4]);

                    if (oldRow1 >= 0 && oldRow1 < matrix.Length && oldCol1 >= 0 && oldCol1 < matrix[oldRow1].Length && newRow1 >= 0 && newRow1 < matrix.Length && newCol1 >=0 && newCol1 < matrix[newRow1].Length)
                    {
                        string tempRC = matrix[oldRow1][oldCol1];
                        matrix[oldRow1][oldCol1] = matrix[newRow1][newCol1];
                        matrix[newRow1][newCol1] = tempRC;
                        PrintMatrix(matrix);
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

                cmd = Console.ReadLine();
            }          

        }

        private static void PrintMatrix(string[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
                
            }
        }
    }
}
