using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            numbers = numbers.OrderByDescending(x=>x).ToArray();
            Queue<int> numsQueue = new Queue<int>(numbers.Take(3));
            
            while (numsQueue.Count >0)
            {
                Console.Write(numsQueue.Dequeue() + " ");
            }
            
        }
    }
}
