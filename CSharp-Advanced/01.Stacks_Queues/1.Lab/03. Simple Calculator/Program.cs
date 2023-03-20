using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();

            Stack<string> stack = new Stack<string>(input);
            
            while (stack.Count > 1)
            {
                int a = int.Parse(stack.Pop());
                string op = stack.Pop();
                int b = int.Parse(stack.Pop());

                if (op == "+")
                {
                    stack.Push((a+b).ToString());
                }
                else if (op == "-")
                {
                    stack.Push((a - b).ToString());
                }
            }

            Console.WriteLine(stack.Peek());
           


        }
    }
}
