using System;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> gameQueue = new Queue<string>(children);
            while (gameQueue.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    gameQueue.Enqueue(gameQueue.Dequeue());
                }
                Console.WriteLine($"Removed {gameQueue.Dequeue()}");
            }
            Console.WriteLine($"Last is {gameQueue.Dequeue()}");

        }
    }
}
