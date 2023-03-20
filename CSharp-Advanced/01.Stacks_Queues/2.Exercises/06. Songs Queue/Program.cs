using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputSong = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songQueue = new Queue<string>(inputSong);
            while (songQueue.Count > 0)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Play")
                {
                    songQueue.Dequeue();
                }
                else if (command[0] == "Add")
                {
                    Adding(songQueue, command);

                }
                else if (command[0] == "Show")
                {
                    List<string> listOfSongs = songQueue.ToList();
                    
                    Console.WriteLine(string.Join(", ", listOfSongs));

                }
            }
            Console.WriteLine("No more songs!");
        }

        private static void Adding(Queue<string> songQueue, string[] command)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < command.Length; i++)
            {
                sb.Append(command[i] + " ");
            }
            string trimmed = sb.ToString().TrimEnd();
            if (!songQueue.Contains(trimmed))
            {
                songQueue.Enqueue(trimmed);
            }
            else
            {
                Console.WriteLine($"{trimmed} is already contained!");
            }
        }
    }
}
