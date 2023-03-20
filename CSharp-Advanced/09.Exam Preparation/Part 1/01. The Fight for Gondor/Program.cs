using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int line = int.Parse(Console.ReadLine());
            int[] platesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> plates = new Queue<int>(platesInput);
            Stack<int> orcWarriors = new Stack<int>();
            for (int i = 1; i <= line; i++)
            {
                if (plates.Count <=0)
                {
                    break;
                }
                orcWarriors = new Stack<int>(Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse));
                if (i % 3 ==0)
                {
                    int AdditionalNumber = int.Parse(Console.ReadLine());

                    plates.Enqueue(AdditionalNumber);                                     
               
                }
                while (orcWarriors.Count >0 && plates.Count > 0)
                {
                    int currentPlate = plates.Peek();
                    int currentOrcWarrior = orcWarriors.Peek();

                    if (currentPlate > currentOrcWarrior)
                    {
                        plates.Dequeue();
                        plates = new Queue<int>(plates.Reverse());
                        plates.Enqueue(currentPlate - currentOrcWarrior);
                        plates = new Queue<int>(plates.Reverse());
                        orcWarriors.Pop();
                    }
                    else if (currentPlate < currentOrcWarrior)
                    {
                        plates.Dequeue();
                        orcWarriors = new Stack<int>(orcWarriors.Reverse());
                        orcWarriors.Pop();
                        orcWarriors.Push(currentOrcWarrior - currentPlate);

                    }
                    else
                    {
                        plates.Dequeue();
                        orcWarriors.Pop();
                    }

                    if (plates.Count == 0 || orcWarriors.Count == 0)
                    {
                        break;
                    }
                }
                

               
            }
            if (plates.Count <= 0 && orcWarriors.Count > 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcWarriors)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
