using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbersStack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (sequence[0] == 1)
                {
                    int elementToPush = sequence[1];
                    numbersStack.Push(elementToPush);

                }
                else if (sequence[0] == 2)
                {
                    if (numbersStack.Count > 0)
                    {
                        numbersStack.Pop();
                    }
                }
                else if (sequence[0] == 3)
                {
                    if (numbersStack.Count > 0)
                    {
                        Console.WriteLine(numbersStack.Max());
                    }
                }
                else if (sequence[0] == 4)
                {
                    if (numbersStack.Count > 0)
                    {
                        Console.WriteLine(numbersStack.Min());
                    }
                }
            }
            List<int> listed = new List<int>();
            while (numbersStack.Count > 0)
            {
                int numPop = numbersStack.Pop();
                listed.Add(numPop);

            }
            Console.Write(string.Join(", ", listed));
        }
    }
}
