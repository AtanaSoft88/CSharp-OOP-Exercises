using ChronometerNs.DataInitializer;
using ChronometerNs.Models;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ChronometerNs
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            Chronometer chrono = new Chronometer();
            Initializer.Information();
            string input = Console.ReadLine().ToLower();            
            await Initializer.Run(chrono, input);

        }

    }
}
