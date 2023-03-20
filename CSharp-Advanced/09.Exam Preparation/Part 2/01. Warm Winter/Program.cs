using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            //10 8 7 13 8 4  - Hats - Stack    if >  - sum
            //4 7 3 6 4 12   - Scarfs - Queue  if >  remove Hat only 
            // if == remove Scarf and make Hat value +1

            int[] inputFirst = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> hatsStack = new Stack<int>(inputFirst);

            int[] inputSecond = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> scarfQueue = new Queue<int>(inputSecond);

            List<int> setOfItems = new List<int>();

            while (hatsStack.Count > 0 && scarfQueue.Count > 0)
            {
                if (hatsStack.Peek() > scarfQueue.Peek())
                {
                    setOfItems.Add(hatsStack.Pop() + scarfQueue.Dequeue());

                }
                else if (hatsStack.Peek() < scarfQueue.Peek())
                {
                    hatsStack.Pop();

                }
                else if (hatsStack.Peek() == scarfQueue.Peek())
                {
                    scarfQueue.Dequeue();
                    hatsStack.Push(hatsStack.Pop() + 1);
                }                
            }
            int maxValue = 0;
            foreach (var set in setOfItems)
            {
                if (set > maxValue)
                {
                    maxValue = set;
                }
            }
            Console.WriteLine($"The most expensive set is: {maxValue}");
            //Console.WriteLine($"The most expensive set is: {setOfItems.Max()}");

            Console.WriteLine(string.Join(" ", setOfItems));
        }
    }
}
