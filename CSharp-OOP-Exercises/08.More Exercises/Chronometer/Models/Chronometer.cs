using ChronometerNs.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace ChronometerNs.Models
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopWatchLap;
        private Stopwatch stopWatchTime;
        public Chronometer()
        {
            Laps = new List<string>(); // return all recorded laps
            stopWatchTime = new Stopwatch();
        }
        public string GetTime => this.stopWatchTime.Elapsed.ToString("mm\\:ss\\.fff");

        public List<string> Laps { get; }

        public string Lap()
        {
            string formattedTimeSpan = this.stopWatchLap.Elapsed.ToString("mm\\:ss\\.fff");

            this.Laps.Add(formattedTimeSpan);
            return formattedTimeSpan;
        }

        public async Task Reset()
        {
            this.stopWatchLap.Reset();
            this.stopWatchTime.Reset();
            this.Laps.Clear();
        }

        public async Task Start()
        {
            this.stopWatchLap = Stopwatch.StartNew();
            this.stopWatchTime.Start();

        }

        public async Task Stop()
        {
            this.stopWatchLap.Stop();
            this.stopWatchTime.Stop();
        }

    }
}
