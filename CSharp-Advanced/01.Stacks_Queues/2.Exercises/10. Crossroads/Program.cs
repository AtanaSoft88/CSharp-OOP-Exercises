using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            
            int freeWindow = int.Parse(Console.ReadLine());
            
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;
            string command = Console.ReadLine();
            
            while (command != "END")
            {
                int greenLightSeconds = greenLight;
                int consumedFreeWindow = freeWindow;
                if (command == "green")
                {
                    while (cars.Count >0 && greenLightSeconds > 0)
                    {
                        string firstCarInQueue = cars.Dequeue();
                        greenLightSeconds -= firstCarInQueue.Length;
                        if (greenLightSeconds > 0)
                        {
                            passedCars++;
                        }
                        else
                        {
                            consumedFreeWindow += greenLightSeconds;
                            if (consumedFreeWindow < 0)
                            {
                                
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{firstCarInQueue} was hit at {firstCarInQueue[firstCarInQueue.Length + consumedFreeWindow]}.");
                                return;
                            }
                            passedCars++;

                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                
       

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");

        }
    }
}
