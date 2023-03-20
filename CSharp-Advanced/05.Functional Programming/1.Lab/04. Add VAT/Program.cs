using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.38, 2.56, 4.4

            double[] prices = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Func<double, double> func = f => f * 1.20;
            prices = prices.Select(x=> func(x)).ToArray();

            //Variant 1
            //Console.WriteLine(string.Join("\r\n",prices.Select(x=>x.ToString("f2").TrimEnd())));

            //Variant 2
            prices.ToList().ForEach(x => Console.WriteLine($"{x:f2}"));

            // Variant 3
            prices.ToList().ForEach(x => Console.WriteLine(string.Join("\r\n",x.ToString("f2"))));
        }
    }
}
