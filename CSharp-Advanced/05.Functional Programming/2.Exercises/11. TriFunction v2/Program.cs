using System;
using System.Linq;

namespace _11._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string[] arrNames = Console.ReadLine().Split();

            var result = arrNames.ToList().FirstOrDefault(x => x.Sum(y => y) >= num);

            Console.WriteLine(result);


        }
    }
}