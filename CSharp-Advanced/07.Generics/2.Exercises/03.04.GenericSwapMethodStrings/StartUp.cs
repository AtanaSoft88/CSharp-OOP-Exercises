using System;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());


                box.Items.Add(input);

            }
            int[] positions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstPosition = positions[0];
            int secondPosition = positions[1];

            box.SwapMeth<int>(firstPosition, secondPosition);

            Console.WriteLine(box);
           
        }
    }
}
