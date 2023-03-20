using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int dailyFood = int.Parse(Console.ReadLine());

            int[] orderInput = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            Queue<int> queueOrders = new Queue<int>(orderInput);
            Console.WriteLine(queueOrders.Max());

            for (int i = 0; i < orderInput.Length; i++)
            {
                if (dailyFood >= orderInput[i])
                {
                    
                    dailyFood -= queueOrders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (dailyFood >= 0 && queueOrders.Count==0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write($"Orders left: ");
                while (queueOrders.Count >0)
                {

                    Console.Write($"{queueOrders.Dequeue()} ");
                }
            }

        }
    }
}
