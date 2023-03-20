using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> boxOfClothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int neededRack = 0;
            int curRack = 0;
            while (boxOfClothes.Count > 0)
            {
                if (curRack + boxOfClothes.Peek() <= rackCapacity)
                {
                    curRack += boxOfClothes.Pop();
                    if (curRack != 0 && boxOfClothes.Count == 0)
                    {
                        neededRack += 1;
                        break;
                    }
                }
                else
                {
                    neededRack += 1;
                    curRack = 0;
                }
            }
            Console.WriteLine(neededRack);
        }
    }
}