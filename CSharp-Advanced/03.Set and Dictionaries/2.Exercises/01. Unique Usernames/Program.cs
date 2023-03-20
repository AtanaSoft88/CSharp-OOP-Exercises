using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> nameSet = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                nameSet.Add(name);
            }

            foreach (var unique in nameSet)
            {
                Console.WriteLine(unique);
            }
        }
    }
}
