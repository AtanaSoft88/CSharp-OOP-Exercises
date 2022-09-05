using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackStrings = new StackOfStrings();
            List<string> colors = new List<string> {"red","blue","white","black","yellow","green" };
            Console.WriteLine(stackStrings.IsEmpty());

            stackStrings.AddRange(colors);

            Console.WriteLine(stackStrings.IsEmpty());
            while (stackStrings.Count > 0)
            {
                if (stackStrings.Peek() == "yellow")
                {
                    Console.WriteLine($"Yes! You got the {stackStrings.Pop()} color found!!");
                    
                }
                Console.WriteLine(stackStrings.Pop());
            }
            if (stackStrings.IsEmpty())
            {
                Console.WriteLine(stackStrings.IsEmpty());
                Console.WriteLine("No more records inside the stack!");
            }
        }
    }
}
