using System;
using System.Collections.Generic;

namespace _08._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string brackets = Console.ReadLine();
            int count = 0;
            Stack<char> bracketsStack = new Stack<char>();
            bool isBalanced = true;
            for (int i = 0; i < brackets.Length; i++)
            {

                if (brackets[i] == '(' || brackets[i] == '[' || brackets[i] == '{')
                {
                    bracketsStack.Push(brackets[i]);
                }                        
                else
                {
                    if (bracketsStack.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    if (brackets[i] == ')' && bracketsStack.Peek() == '(')
                    {
                        bracketsStack.Pop();
                    }
                    else if (brackets[i] == '}' && bracketsStack.Peek() == '{')
                    {
                        bracketsStack.Pop();
                    }
                    else if (brackets[i] == ']' && bracketsStack.Peek() == '[')
                    {
                        bracketsStack.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                        
                    }
                }
                
            }
            if (!isBalanced)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
            
        }
    }
}
