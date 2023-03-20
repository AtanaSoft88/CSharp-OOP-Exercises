using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] sequence = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> occurrances = new Dictionary<double, int>();
            
            foreach (var num in sequence)
            {
                if (!occurrances.ContainsKey(num))
                {
                    occurrances.Add(num,0);
                }
                occurrances[num]++;
            }
            foreach (var element in occurrances)
            {
                Console.WriteLine($"{element.Key} - {element.Value} times");
            }

        }
    }
}
