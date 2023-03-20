using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queuePumps = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] petrolPump = Console.ReadLine().Split().Select(int.Parse).ToArray();

                queuePumps.Enqueue(petrolPump);
                                
            }
            int index = 0;

            while (true)
            {
                int totalFuel = 0;
                foreach (int[] pump in queuePumps)
                {
                    int petrolAmount = pump[0];
                    int distanceToPump = pump[1];

                    totalFuel += petrolAmount - distanceToPump;

                    if (totalFuel <0)
                    {
                        queuePumps.Enqueue(queuePumps.Dequeue());
                        index++;
                        break;
                    }
                }
                if (totalFuel >=0)
                {
                    break;
                }
            }

            Console.WriteLine(index);

        }
    }
}
