using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsAllowedToPass = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            string command = Console.ReadLine();
            
            
            int totalPassed = 0;
                                    
            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < carsAllowedToPass; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        totalPassed++;
                    }
                    
                }
                else
                {
                    cars.Enqueue(command);

                }
                command = Console.ReadLine();
            }
           
            
            Console.WriteLine($"{totalPassed} cars passed the crossroads.");

        }
    }
}
