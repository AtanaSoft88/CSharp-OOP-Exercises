using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Race_Condition
{
    internal class Program
    {
        public const int n = 10_000_000;
        static int Count = 0;
        static object lockObj = new object(); // We make isnstance of the object which will help us to lock the Thread we need
        
        static void Main(string[] args)
        {                         
               
            OneThreadResult();

            //Here we push 4 Threads (4 iterations) to work on one Method  
            FourThreadsResult();           
            

            //This WOULD ends up with Error if no Lock used to push in only the first Thread reached the piece of code. Other Threads are waiting the first one to end with this piece of code which is Locked! 
            //We usually lock a piece of Code which will be modified/calculated ,so We ensure only 1 Thread to modify at a time . And until the first one Thread is done with the calculation/modification ,no onther Threads are let inside the lock ( this piece of code) .
            //Threads cant handle exceptions but , you can use try/catch block inside the Thread 
            List<int> numbers = Enumerable.Range(1, 1_000_000).ToList();
            bool isCollectionEmpty = false;
            
            for (int i = 0; i < 6; i++) // we are pushing 6 Threads to take care of this piece of code below
            {
                new Thread(() =>
                {
                    while (numbers.Count > 0)
                    {
                        lock (lockObj)
                        {
                            if (numbers.Count == 0)
                            {
                                isCollectionEmpty = true;
                                
                                break;
                            }
                            int lastIndex = numbers.Count - 1;
                            numbers.RemoveAt(lastIndex);
                        }

                    }

                }).Start();

                if (isCollectionEmpty)
                {
                    Console.WriteLine("No more elements inside the array!");
                    Console.WriteLine($"Collection remained with [{numbers.Count}] numbers!");
                    break;
                }
            } 
            
            
            
        }
        private static void OneThreadResult()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Thread thread1 = new Thread(() => GetPrimeNumbersAsync(1, 10_000_000));
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
            
            Thread thread1 = new Thread(() => GetPrimeNumbersAsync(1, 2_500_000));
            thread1.Start();
            Thread thread2 = new Thread(() => GetPrimeNumbersAsync(2_500_001, 5_000_000));
            thread2.Start();
            Thread thread3 = new Thread(() => GetPrimeNumbersAsync(5_000_001, 7_500_000));
            thread3.Start();
            Thread thread4 = new Thread(() => GetPrimeNumbersAsync(7_500_001, 10_000_000));
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
        private static void GetPrimeNumbersAsync(int min,int max)
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
                    lock (lockObj) 
                    {
                        Count++;
                    }
                }
            }
            
            //Console.WriteLine(String.Join("/ ", primeNumbersCollection));
        }
    }
}
