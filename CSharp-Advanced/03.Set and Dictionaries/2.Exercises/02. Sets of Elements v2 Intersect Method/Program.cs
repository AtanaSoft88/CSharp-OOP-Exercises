using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstNum = nums[0];
            int secondNum = nums[1];


            HashSet<int> setFirst = new HashSet<int>();
            HashSet<int> setSecond = new HashSet<int>();
            FillSet(setFirst, firstNum);
            FillSet(setSecond, secondNum);
            
            IEnumerable<int> uniqueNums = setFirst.Intersect(setSecond);

            Console.Write(string.Join(" ",uniqueNums).TrimEnd());
        }

        private static HashSet<int> FillSet(HashSet<int> setFirst, int length)
        {
            for (int i = 0; i < length; i++)
            {
                int numToAdd = int.Parse(Console.ReadLine());
                setFirst.Add(numToAdd);               

            }

            return setFirst;
        }
    }
}
