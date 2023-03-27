using ChronometerNs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronometerNs.DataInitializer
{
    public static class Initializer
    {
        public static void Information()
        {
            StringBuilder sb = new StringBuilder();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("       - -=========- - ");
            Console.WriteLine("--=====|  STOPWATCH  |=====--");
            Console.WriteLine("       - -=========- - \r\n\r\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            sb.AppendLine("Commands Available:");
            sb.AppendLine("======================\r\n");
            sb.AppendLine("-- Start - Starting the Stopwatch");
            sb.AppendLine("-- Stop - Stops the Stopwatch");
            sb.AppendLine("-- Lap - Current lap record");
            sb.AppendLine("-- Laps - All current lap records if not stopped/reset");
            sb.AppendLine("-- Time - current total Time if watch not stopped/reset");
            sb.AppendLine("-- Reset - resets all times/laps");
            sb.AppendLine("-- Exit - exits the program\r\n");
            sb.AppendLine("Stopwatch format: mm:ss:ms ");            
            Console.WriteLine(sb.ToString());
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Please enter the command: Start");
            Console.ResetColor();

        }
        public static async Task Run(Chronometer chrono, string input)
        {

            bool alreadyStarted = false;
            bool isStopped = false;
            int count = 0;
            while (input != "start")
            {
                Console.WriteLine($"\"{input}\" is invalid command, you must first Start!");
                input = Console.ReadLine().ToLower();
                count++;
                if (count == 3)
                {
                    Console.Clear();
                    count = 0;
                    Information();
                }
            }
            while (input != "exit")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                               - -=========- - ");
                Console.WriteLine("                        --=====|  STOPWATCH  |=====-- ");
                Console.WriteLine("                               - -=========- - \r\n\r\n");
                Console.WriteLine("||> Start <-|-> Stop <-|-> Lap <-|-> Laps <-|-> Time <-|-> Reset <-|-> Exit <||");
                Console.WriteLine("==============================================================================\r\n");
                Console.ResetColor();
                if (input == "start")
                {

                    isStopped = false;
                    if (alreadyStarted)
                    {
                        Console.WriteLine("You can not start twice or more at a time!");
                        input = Console.ReadLine().ToLower();
                        continue;
                    }
                    Console.WriteLine("Started :)");
                    alreadyStarted = true;
                    await chrono.Start();
                }
                else if (input == "lap")
                {
                    if (isStopped)
                    {
                        Console.WriteLine("Can not make a record, Stopwatch has been stopped!");
                        Console.WriteLine("Please Start again!");
                        input = Console.ReadLine().ToLower();
                        continue;
                    }
                    Console.WriteLine(chrono.Lap());
                }
                else if (input == "laps")
                {
                    await LapsRegister(chrono);
                }
                else if (input == "time")
                {
                    Console.WriteLine(chrono.GetTime);
                }
                else if (input == "stop")
                {
                    isStopped = true;
                    alreadyStarted = false;
                    Console.WriteLine("Stopped!");
                    await chrono.Stop();
                }
                else if (input == "reset")
                {
                    await chrono.Reset();
                    Console.WriteLine("Time has been reset!");
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }

                input = Console.ReadLine().ToLower();
            }
        }

        public static async Task LapsRegister(Chronometer chrono)
        {
            if (!chrono.Laps.Any())
            {
                Console.WriteLine("Laps: no laps");
                return;
            }
            int lapNum = 1;
            Console.WriteLine("Laps:  min/s/ms\r\n");
            foreach (string lap in chrono.Laps)
            {
                Console.WriteLine($"No{lapNum}: < {lap} >");
                lapNum++;
            }
        }
    }
}
