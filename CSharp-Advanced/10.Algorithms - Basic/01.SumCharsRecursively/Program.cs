using System;
using System.Linq;

namespace SumCharsRecursively
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] characters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            Console.WriteLine(CharConcat(characters, 0));
            
        }
        private static string CharConcat(char[]characters, int index)
        {
            string result = string.Empty;
            if (index == characters.Length-1)
            {
                return characters[index].ToString();
            }
            result += characters[index].ToString();
            return result += CharConcat(characters, index+1);
        }

        
    }
}
