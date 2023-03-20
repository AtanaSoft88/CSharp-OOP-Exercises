using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string inputCmd = Console.ReadLine().ToLower();

            Stack<int> stackNumbers = new Stack<int>(numbers);

            while (inputCmd != "end")
            {
                string[] currentCmd = inputCmd.ToLower().Split().ToArray();

                if (currentCmd[0] == "add")
                {
                    int num1 = int.Parse(currentCmd[1]);
                    int num2 = int.Parse(currentCmd[2]);

                    stackNumbers.Push(num1);
                    stackNumbers.Push(num2);

                }
                else if (currentCmd[0] == "remove")
                {
                    int numbersToRemove = int.Parse(currentCmd[1]);

                    if (int.Parse(currentCmd[1]) <= stackNumbers.Count)
                    {
                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            stackNumbers.Pop();
                        }
                    }
                    
                }
                

                inputCmd = Console.ReadLine().ToLower();
            }
            int sum = 0;
            while (stackNumbers.Count > 0)
            {
                sum += stackNumbers.Pop();
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
