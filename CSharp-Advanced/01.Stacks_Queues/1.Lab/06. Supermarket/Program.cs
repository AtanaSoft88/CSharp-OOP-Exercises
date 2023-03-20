using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> peopleQueue = new Queue<string>();
            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (peopleQueue.Count>0)
                    {
                        Console.WriteLine(peopleQueue.Dequeue());
                    }
                }
                else
                {
                    peopleQueue.Enqueue(input);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{peopleQueue.Count} people remaining.");

        }
    }
}
