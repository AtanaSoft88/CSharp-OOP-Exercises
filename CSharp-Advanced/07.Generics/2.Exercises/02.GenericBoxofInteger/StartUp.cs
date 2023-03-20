using System;

namespace GenericBoxofString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                box.Items.Add(num);
            }


            Console.WriteLine(box);
        }
    }
}
