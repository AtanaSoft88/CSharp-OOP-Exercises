using System;
namespace T02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());

            char[][] field = new char[rows][];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                field[i] = row;
            }

            int MarioRow = 0;
            int MarioCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int cols = 0; cols < field[row].Length; cols++)
                {
                    if (field[row][cols] == 'M')
                    {
                        MarioRow = row;
                        MarioCol = cols;
                        break;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];
                int broRow = int.Parse(commands[1]);
                int broCol = int.Parse(commands[2]);

                health--;
                field[broRow][broCol] = 'B';
                field[MarioRow][MarioCol] = '-';
                if (command == "W" && MarioRow - 1 >= 0)
                {
                    //up
                    MarioRow--;
                }
                else if (command == "S" && MarioRow + 1 < rows)
                {
                    //down
                    MarioRow++;
                }
                else if (command == "A" && MarioCol - 1 >= 0)
                {
                    //left
                    MarioCol--;
                }
                else if (command == "D" && MarioCol + 1 < field[MarioRow].Length)
                {
                    //right
                    MarioCol++;
                }

                if (field[MarioRow][MarioCol] == 'B')
                {
                    health -= 2;
                }

                if (field[MarioRow][MarioCol] == 'P')
                {
                    field[MarioRow][MarioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {health}");
                    break;
                }

                if (health <= 0)
                {
                    field[MarioRow][MarioCol] = 'X';
                    Console.WriteLine($"Mario died at {MarioRow};{MarioCol}.");
                    break;
                }

                field[MarioRow][MarioCol] = 'M';
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    Console.Write(field[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}