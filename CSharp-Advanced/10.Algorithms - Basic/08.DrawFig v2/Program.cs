using System;

namespace draw 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Draw(1, num);

        }

        private static void Draw(int start, int row)
        {
            if (start > row)
            {
                return;
            }

            Console.WriteLine(new string('*', start));
            Draw(start + 1, row);
            Console.WriteLine(new string('#', start));
        }
    }
}