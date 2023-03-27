using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChronometerNs.Contracts
{
    public interface IChronometer
    {
        public string GetTime { get; }

        List<string> Laps { get; }

        public async Task Start() { }
        public async Task Stop() { }
        public string Lap();
        public async Task Reset() { }
    }
}
