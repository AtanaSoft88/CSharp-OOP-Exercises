using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 4 3 2 1 7 13
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> funcIsSmallest = nums =>
             {
                 int minValue = int.MaxValue;

                 foreach (var item in nums)
                 {
                     if (item < minValue)
                     {
                         minValue = item;
                     }
                 }
                 return minValue;


             };

            int minNum = funcIsSmallest(numbers);

            Console.WriteLine(minNum);

            
        }
    }
}
