using System;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //void function
            Action<string> printName = (name)
                => Console.WriteLine(name);

            printName("Viktor");
            PrintName("Viktor");

            //bool function
            Predicate<int> isEven = x
                => x % 2 == 0;

            var resultOfIsEven = isEven(4);
            var resultOfIsEvenMethod = IsEven(4);

            //function up to 16 in param and 1 out param
            Func<int, int, int> sumNumbers = (x, y)
                => x + y;

            int result = sumNumbers(10, 15);
            int resultMethod = SumNumbers(10, 15);
        }

        public static int SumNumbers(int x, int y)
        {
            return x + y;
        }

        public static bool IsEven(int x)
        {
            return x % 2 == 0;
        }

        public static void PrintName(string name)
        {
            Console.WriteLine(name);
        }
    }
}