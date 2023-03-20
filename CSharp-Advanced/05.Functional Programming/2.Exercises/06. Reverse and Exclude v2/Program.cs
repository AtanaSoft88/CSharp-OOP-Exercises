using System;
using System.Linq;

namespace _06._Reverse_and_Exclude_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split().Select(int.Parse).Reverse().Where(x => x % 2 == 0).ToList().ForEach(Console.WriteLine);
        }
    }
}
