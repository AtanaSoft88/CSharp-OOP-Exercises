using System;
using System.Collections.Generic;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
                        
            Stack<char> stackChars = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stackChars.Push(input[i]);
            }

            while (stackChars.Count > 0)
            {
                Console.Write(stackChars.Pop());
            }
        }
    }
}
