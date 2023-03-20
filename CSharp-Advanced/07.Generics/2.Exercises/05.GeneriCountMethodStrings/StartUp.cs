using System;

namespace GeneriCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BoxElements<string> boxOfAny = new BoxElements<string>();
            for (int i = 0; i < n; i++)
            {
                string txt = Console.ReadLine();

                boxOfAny.ElementList.Add(txt);
            }

            string input = Console.ReadLine();

            int count = boxOfAny.GreatherElement(boxOfAny.ElementList , input);

            Console.WriteLine(count);
        }
    }
}
