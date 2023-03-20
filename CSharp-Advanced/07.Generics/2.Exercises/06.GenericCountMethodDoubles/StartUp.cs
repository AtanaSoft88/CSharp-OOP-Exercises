using System;
using System.Linq;

namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BoxElements<double> boxElements = new BoxElements<double>();
            for (int i = 0; i < n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                boxElements.ElementList.Add(num);

            }
            double inputCheckNum = double.Parse(Console.ReadLine());

            int count = boxElements.GreatherElement(boxElements.ElementList ,inputCheckNum);

            Console.WriteLine(count);
        }
    }
}
