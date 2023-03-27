using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern.Network
{
    public class Packet
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string IpAddress { get; set; }
        public Packet(string ipAddress)
        {
            this.IpAddress = ipAddress;
        }
        public void PacketBuilt() 
        {
            Console.WriteLine($"Packet with IP: {IpAddress} was built");
        }
    }
}
