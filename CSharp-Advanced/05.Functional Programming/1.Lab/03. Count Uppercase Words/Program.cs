using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            //The following example shows how to use Function
            //The
            //Function
            
            string text = Console.ReadLine();
            string[] wordsArray = text.Split(" ",StringSplitOptions.RemoveEmptyEntries);


            Func<string, bool> func = s =>
            s.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(s => char.IsUpper(s[0])).All(s => s);

            Console.WriteLine(string.Join(Environment.NewLine, wordsArray.Where(s => func(s))).ToArray());


            // Вариант 2 - предикат ( bool)

            string txt = Console.ReadLine();
            string[] wordsArraySplit = txt.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> isCharUpper = x => char.IsUpper(x[0]);

            Console.WriteLine(string.Join(Environment.NewLine, wordsArray.Where(x => isCharUpper(x))));
        }
    }
}
