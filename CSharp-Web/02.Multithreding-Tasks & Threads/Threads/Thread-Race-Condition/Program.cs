using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Race_Condition
{
    internal class Program
    {
        public const int n = 10_000_000;
        static int Count = 0;
        static void Main(string[] args)
        {
            //Here All Threads dont wait for each other to make calculations - so the mistakes are surely done !
            //When we force more than 1 thread to do something on one and the same method or piece of code in order to save time  we can get to the point where all threads are messing with the result because of the simultaneous operations made by these threads.
            //As a result we can get error exception ( out ot array bound) or just incorrecet result!

            
            //Here we push 4 Threads (4 iterations) to work on one Method            

            OneThreadResult();           
                        
            FourThreadsResult();

           
            return;

            //This ends up with Error !
            //Error for the end result when more than 1 Thread works in one Method which executes math operations (+,-,*,/) etc.
            List<int> numbers = Enumerable.Range(1, 10_000_000).ToList();           
           
            for (int i = 0; i < 6; i++) // we are pushing 6 Threads to take care of this piece of code below
            {
                new Thread(() => 
                {
                    while (numbers.Any())
                    {
                        
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                }).Start();
               
            }
            
        }
        private static void OneThreadResult()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Thread thread1 = new Thread(() => GetPrimeNumbers(1, 10_000_000));
            thread1.Start();

            //We use Join method to tell -> until end of the threads tasks we dont go further with the code next
            thread1.Join();
            Console.WriteLine("One thread Result!");
            Console.WriteLine($"Total Prime Numbers =>> / {Count} /");
            Console.WriteLine($"Time needed for algorithm to determine all prime numbers: [{sw.Elapsed} ms]");
            Console.WriteLine($"Time measured in seconds = [{sw.ElapsedMilliseconds / 1000.00} s]");            
            Console.WriteLine(new String('*', 60));
            Count = 0;
        }
        private static void FourThreadsResult() 
        {
            Stopwatch sw = Stopwatch.StartNew();
            
            Thread thread1 = new Thread(() => GetPrimeNumbers(1, 2_500_000));
            thread1.Start();
            Thread thread2 = new Thread(() => GetPrimeNumbers(2_500_001, 5_000_000));
            thread2.Start();
            Thread thread3 = new Thread(() => GetPrimeNumbers(5_000_001, 7_500_000));
            thread3.Start();
            Thread thread4 = new Thread(() => GetPrimeNumbers(7_500_001, 10_000_000));
            thread4.Start();

            //We use Join method to tell -> until end of the threads tasks we dont go further with the code next
            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            Console.WriteLine("Four threads Result!");
            Console.WriteLine($"Total Prime Numbers =>> / {Count} /");
            Console.WriteLine($"Time needed for algorithm to determine all prime numbers: [{sw.Elapsed} ms]");
            Console.WriteLine($"Time measured in seconds = [{sw.ElapsedMilliseconds / 1000.00} s]");
            Count = 0;
            Console.WriteLine(new String('*', 60));
        }
        private static void GetPrimeNumbers(int min,int max)
        {
            
            List<int> primeNumbersCollection = new List<int>();
            
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
                {   //if u want to print each number uncomment the below code + Console Writeline!!
                    //primeNumbersCollection.Add(i);
                    Count++;
                }
            }
            
            //Console.WriteLine(String.Join("/ ", primeNumbersCollection));
        }
    }
}
