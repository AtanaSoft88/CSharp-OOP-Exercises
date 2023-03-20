using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] operators = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int toPush = operators[0];
            int toDel = operators[1];
            int lookFor = operators[2];

            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> nums = new Queue<int>();
            for (int i = 0; i < toPush; i++)
            {
                nums.Enqueue(sequence[i]);
            }
            for (int i = 0; i < toDel; i++)
            {
                nums.Dequeue();
            }
            if (nums.Count > 0 && nums.Contains(lookFor))
            {
                Console.WriteLine("true");
            }
            else if (nums.Count > 0)
            {
                Console.WriteLine(nums.Min());
            }
            else
            {
                Console.WriteLine("0");
            }

        }
    }
}
