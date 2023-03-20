using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<int, int> dictNums = new Dictionary<int, int>();
            
            for (int i = 0; i < lines; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!dictNums.ContainsKey(num))
                {
                    dictNums.Add(num,0);
                }
                dictNums[num]++;
                
            }
            // Вариант 1 принтиране
            foreach (var item in dictNums.Where(item => item.Value % 2 == 0))
            {
                Console.WriteLine(item.Key);
            }

             // Вариант 2 принтиране
            //foreach (var item in dictNums)
            //{
            //    if (item.Value % 2 == 0)
            //    {
            //        Console.WriteLine(item.Key);
            //    }
            //}


        }
    }
}
