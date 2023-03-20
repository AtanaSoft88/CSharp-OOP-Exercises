using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> evenQueue = new Queue<int>();

            Filling(numbers,evenQueue);

            Printing(evenQueue);
        }

        private static void Printing(Queue<int> evenQueue)
        {
            while (evenQueue.Count > 0)
            {
                Console.Write(evenQueue.Dequeue());
                if (evenQueue.Count != 0 )
                {
                    Console.Write(", ");
                }
            }
        }

        public static Queue<int> Filling(int[] numbers, Queue<int> evenQueue)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenQueue.Enqueue(numbers[i]);
                }
            }
            return evenQueue;
        }
    }
}
