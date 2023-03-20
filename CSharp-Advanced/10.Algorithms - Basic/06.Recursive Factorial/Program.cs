using System;

namespace _2._Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }

        public static int Factorial(int n)
        {
            if (n==1)
            {
                return n;
            }
            int resutlt = n * Factorial(n - 1);
            return resutlt;


        }
    }
}
