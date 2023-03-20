using System;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5

            string input = Console.ReadLine();

            Stack<int> stackResult = new Stack<int>();
            
            for (int i = 0; i < input.Length; i++)
            {
                
                if (input[i] == '(')
                {
                    stackResult.Push(i);
                }
                else if (input[i] == ')')
                {
                    int index = stackResult.Pop();
                    Console.WriteLine(input.Substring(index,i-index +1));
                }

                
            }

            
        }
    }
}
