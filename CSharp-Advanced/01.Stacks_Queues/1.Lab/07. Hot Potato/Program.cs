using System;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            //Alva James William  - 2

            string[] potatoParticipants = Console.ReadLine().Split();
            int turn = int.Parse(Console.ReadLine());
            Queue<string> gameQueue = new Queue<string>(potatoParticipants);
            int count = 0;
            while (gameQueue.Count > 1)
            {
                count++;
                if (count == turn)
                {
                    Console.WriteLine($"Removed {gameQueue.Dequeue()}");
                    count = 0;
                }
                else
                {
                    gameQueue.Enqueue(gameQueue.Dequeue());
                }
                
            }
            Console.WriteLine($"Last is {gameQueue.Dequeue()}");
            
        }
    }
}
