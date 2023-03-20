using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesNumber = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            int capacityRack = int.Parse(Console.ReadLine());
            int emptyRack = 0;

            Stack<int> stackClothes = new Stack<int>(clothesNumber);
            
            int sum = 0;
            while (stackClothes.Count>0)
            {
                if (capacityRack >= sum + stackClothes.Peek())
                {
                    sum += stackClothes.Pop();
                    if (stackClothes.Count == 0 && sum != 0)
                    {
                        emptyRack++;
                        break;
                    }
                }
                else
                {
                    emptyRack++;
                    sum = 0;
                }
            }
            Console.WriteLine(emptyRack);

        }
    }
}
