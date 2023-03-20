using System;

namespace Draw_Recursively
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            
            DrawFunction(num);


        }
        private static void DrawFunction(int row )
        {
            
            if (row == 0)
            {
                
                return;
            }
            Console.WriteLine(new string('*', row));       // pre-Action     
           
            DrawFunction(row - 1);                         // recursion Call

            Console.WriteLine(new string('#', row));      // post-Action
        }
    }
}
