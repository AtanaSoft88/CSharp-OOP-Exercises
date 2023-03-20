using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string[]> namesPrint = allNames => Console.WriteLine(string.Join("\r\n",allNames.Select(x=>"Sir" + " " + x))); 
            namesPrint(names);
        }
    }
}
