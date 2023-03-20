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
            Func<string[], int, string> func = (argArray, argNum) =>
            {
                string resultName = argArray.ToList().FirstOrDefault(x => x.Sum(y => y) >= argNum);
                return resultName;
            };

            Console.WriteLine(func(arrNames,num));
            
          

        }
    }
}
