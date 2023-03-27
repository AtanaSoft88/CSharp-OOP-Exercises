using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern.Network
{
    public class Transimission
    {
        public int Id { get; set; }
        public string ProtocolName { get; set; }
        
        public Transimission(string protocolName)
        {
            this.ProtocolName = protocolName;
        }
        public void SendTransmission()
        {
            Console.WriteLine($"Transimission with protocol: <{ProtocolName}> Sent.");
        }
    }
}
