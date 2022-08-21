using System;

namespace _1.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(CalcRoot(inputNum));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Goodbye.");
        }
        public static int CalcRoot(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }
            return (int)Math.Sqrt((double)number);
        }
    }
}
