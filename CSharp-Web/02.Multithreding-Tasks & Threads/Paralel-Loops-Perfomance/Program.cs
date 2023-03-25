using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Paralel_Loops_Perfomance
{

    public class Program
    {
        public static object obj = new object();
        public static int Count = 0;
        public static Stopwatch sw = new Stopwatch();
        public static int min = 1;
        public static int max = 10_000_000;
        static void Main(string[] args)
        {   
            //Get only Prime numbers
            Console.WriteLine(string.Join("\r\n", Enumerable.Range(1, 1000).Where(y => y % 2 == 0).Select(y => y)));
            
            //Regular finding Prime numbers
            sw.Start();
            for (int i = min; i < max; i++)
            {
                bool isPrimeNumber = true;
                for (int j = 2; j <= Math.Sqrt(i); j++) // Algorithm for finding Prime numbers
                {
                    if (i % j == 0)
                    {
                        isPrimeNumber = false;
                        break;
                    }

                }

                if (isPrimeNumber)
                {   //We must lock The active Thread so that other Threads wont get in conflict with the first one
                    lock (obj)
                    {
                        Count++;
                    }
                }
            }
            Console.WriteLine("Regular for loops");
            Console.WriteLine($"Prime numbers amogs {max} using regular algorithm: <|: {Count} :>|");
            Console.WriteLine($"Seconds needed to solve prime number count: {sw.ElapsedMilliseconds / 1000.000} seconds");
            
            Count = 0;
            sw.Reset();
            // Time needed: 6,719 sec
            // 664580 Prime numbers within 10_000_000

            Delimiter();
            //------------------------------------------------------------------------------------------



            // Paralel Foreach Loop - for perfomance increase
            sw.Start();
            var elements = Enumerable.Range(min, max).ToList();
            Parallel.ForEach(elements, item => 
            {
                bool isPrimeNumber = true;
                for (int j = 2; j <= Math.Sqrt(item); j++) // Algorithm for finding Prime numbers
                {
                    if (item % j == 0)
                    {
                        isPrimeNumber = false;
                        break;
                    }

                }

                if (isPrimeNumber)
                {   //We must lock The active Thread so that other Threads wont get in conflict with the first one
                    lock (obj)
                    {
                        Count++;
                    }
                }
            });
            Console.WriteLine("ForEach Parallel LOOP");
            Console.WriteLine($"Prime numbers amogs {max} using Parallel.For Loop to gain performance: <|: {Count} :>|");
            Console.WriteLine($"Seconds needed to solve prime number count: {sw.ElapsedMilliseconds / 1000.000} seconds");
            sw.Reset();
            Delimiter();
            Count = 0;

            //------------------------------------------------------------------------------------------

            //Using Paralel For Loop we must know: CPU is utilized for better performance by using different Threads, but Lock-ing must be used in order to avoid problem in results ( incorrect result due to different Threads modifying the end result)
            // Paralel For Loop - for perfomance increase
            sw.Start();

            Parallel.For(min, max + 1, i =>
            {
                bool isPrimeNumber = true;
                for (int j = 2; j <= Math.Sqrt(i); j++) // Algorithm for finding Prime numbers
                {
                    if (i % j == 0)
                    {
                        isPrimeNumber = false;
                        break;
                    }

                }

                if (isPrimeNumber)
                {   //We must lock The active Thread so that other Threads wont get in conflict with the first one
                    lock (obj)
                    {
                        Count++;
                    }
                }
            });
            Console.WriteLine("For Parallel LOOP");
            Console.WriteLine($"Prime numbers amogs {max} using Parallel.For Loop to gain performance: <|: {Count} :>|");
            Console.WriteLine($"Seconds needed to solve prime number count: {sw.ElapsedMilliseconds / 1000.000} seconds");            
            sw.Stop();
            sw.Reset();
            // Time needed: 1.467 sec
            // 664580 Prime numbers within 10_000_000

            Delimiter();
            //------------------------------------------------------------------------------------------
            //Parallel LINQ Operations to Collections ( Multy-Tasking principle) - fast calculation using Tasks
            sw.Start();
            List<int> collection = Enumerable.Range(1, 50_000_000).ToList();
            var parallelLinq = from num in collection.AsParallel() where num % 2 != 0 select num;

            Console.WriteLine("Parallel LINQ Operations to Collection");
            Console.WriteLine($"Found total Odd numbers :{parallelLinq.Count()}");            
            Console.WriteLine($"Seconds needed to find all odd numbers within 50_000_000 :  {sw.ElapsedMilliseconds / 1000.000} seconds");
            sw.Stop();
            sw.Reset();
        }


        private static void Delimiter() 
        {
            Console.WriteLine($"\r\n{new String('*', 65)}\r\n");
        }
    }
}
