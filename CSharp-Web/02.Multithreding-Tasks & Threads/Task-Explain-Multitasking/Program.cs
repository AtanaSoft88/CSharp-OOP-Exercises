using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Explain_Multitasking
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Asynchronous vs Multithreding -> Async(Task) - can use many threads or one with many Tasks, Multithreading uses many Threads
            //Waiter is an example where 1 Waiter can do 1 or many tasks or waits for 1 or many tasks while doing another task.
            //We can use Exception handling with try/catch anywhere - we are not limited as we were using Threads!

            //1) Example for Tasks - reading vicove from internet
            Stopwatch sw = Stopwatch.StartNew();
            
            List<Task> tasks = new List<Task>();
            for (int i = 1; i <= 100; i++)
            {
               var task = Task.Run( () => DownloadUrlAsync(i));
                
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine(sw.ElapsedMilliseconds / 1000.000);

            //---------------------------------------------------------------------------------------------------------------------

            //2) Example for Threads - reading vicove from internet
            //Stopwatch sw = Stopwatch.StartNew();
            //HttpClient client = new HttpClient();

            //for (int i = 0; i < 100; i++)
            //{
            //    var thread = new Thread(() => 
            //    {
            //        var url = $"https://vicove.com/vic-{i}";
            //        var httpResponse = client.GetAsync(url).GetAwaiter().GetResult();
            //        var vic = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //        Console.WriteLine($"{vic.Length} No{i+1}");
            //        //Console.WriteLine(vic);
            //    });
            //    thread.Start();
            //    thread.Join(); //for each Thred -> waiting to end with its operations 

            //}
            //Console.WriteLine(sw.ElapsedMilliseconds / 1000.000);

            //---------------------------------------------------------------------------------------------------------------------

            //3) Example for Tasks with while(true)

            //Stopwatch sw = Stopwatch.StartNew();
            //int count = 0;
            //for (int i = 0; i < 1000_000; i++)
            //{
            //    Task.Run(() => 
            //    {
            //        while (true)
            //        {

            //        }
            //    });
            //}
            //Console.WriteLine(sw.ElapsedMilliseconds/1000.000);
            //Console.ReadLine();

        }

        static async Task  DownloadUrlAsync(int i) 
        {
            HttpClient client = new HttpClient();
            var url = $"https://vicove.com/vic-6{i}";
            var httpResponse = await client.GetAsync(url);
            var vic = await httpResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"{vic.Length} No{i}");
        }
    }
}
