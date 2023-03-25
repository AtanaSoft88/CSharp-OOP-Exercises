using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace How_Slow_Stopwatch
{
    internal class Program
    {
        public const int n = 10_000_000;
        static void Main(string[] args)
        {
            //The Thread is doing his work on the method ,while console is free for usage in the while cycle below!
            //Thread 1
            Thread thread1 = new Thread(GetPrimeNumbers);         

            //Thread 2
            Thread thread2 = new Thread(() => 
            {                
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    if (i%2==0)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Thread 2 -> For loop i to {n} , if [i%2==0] -> count = {count}");
            });           

            //Thread 3
            Thread thread3 = new Thread(() =>
            {                
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 != 0)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Thread 3 -> For loop i to {n} , if [ i%2 != 0 ] -> count = {count}");
            });            

            //Thread 4
            Thread thread4 = new Thread(() =>
            {                
                int count = 0;
                for (int i = 1; i < n; i++)
                {
                    bool isPrimeNumber = false;
                    for (int j = 2; j <= Math.Sqrt(i); j++)
                    {
                        if (i%j!=0)
                        {
                            isPrimeNumber = true;
                            break; 
                        }
                    }

                    if (!isPrimeNumber)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Thread 4 -> Nested loop i to {n} , if i%j==0 -> count = {count}");
            });
            List<Thread> threadList = new List<Thread>() {thread1,thread2,thread3,thread4 };

            foreach (var thread in threadList)
            {
                thread.Start();
            }
            //Main Thread
            while (true)
            {
                Console.WriteLine("Main Thread responds!");
                string input = Console.ReadLine();
                Console.WriteLine(input);
            }

        }

        private static void GetPrimeNumbers() 
        {
            Stopwatch sw = Stopwatch.StartNew();
            List<int> primeNumbersCollection = new List<int>();            
            int countPrimeNumbers = 0;
            for (int i = 1; i < n; i++)
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
                    countPrimeNumbers++;
                }
            }
            Console.WriteLine("Thread 1 below:");
            Console.WriteLine($"Number of prime numbers = [{countPrimeNumbers}]");
            Console.WriteLine($"Time needed for algorithm to determine all prime numbers: [{sw.Elapsed} ms]");
            Console.WriteLine($"Time measured in seconds = [{sw.ElapsedMilliseconds / 1000.00} s]");
            Console.WriteLine(new String('*', 60));
            //Console.WriteLine(String.Join("/ ", primeNumbersCollection));
        }
    }
}
