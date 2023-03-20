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

            int count = 0;
            for (int i = 0; i < nums.Sum(); i++)
            {
                int numToAdd = int.Parse(Console.ReadLine());

                if (i < firstNum)
                {
                    setFirst.Add(numToAdd);
                }
                else
                {
                    setSecond.Add(numToAdd);
                }

            }
            Console.Write(string.Join(" ", CheckSets(setFirst, setSecond)));

        }

        private static List<int> CheckSets(HashSet<int> setFirst, HashSet<int> setSecond)
        {          
            
            List<int> numsResult = new List<int>();
            foreach (var num in setFirst)
            {
                
                if (setSecond.Contains(num))
                {
                    numsResult.Add(num);
                }
            }
            return numsResult;
        }
    }
}
