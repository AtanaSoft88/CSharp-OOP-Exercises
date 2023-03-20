using System;
using System.Linq;

namespace _01._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string[]> printNames = x => Console.WriteLine(string.Join("\r\n",x));

            printNames(names);
            
        }
    }
}
