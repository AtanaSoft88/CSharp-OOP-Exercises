using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern.Network
{
    public class Socket
    {
        public int Id { get; set; }
        public string Port { get; set; }
        public string Protocol { get; set; }
        public Socket(string protocol, string port)
        {
            this.Protocol = protocol;
            this.Port = port;
        }
        public void SocketBuilt()
        {
            Console.WriteLine($"Socket at Port: {Port} was built with protocol: {Protocol}");
        }
    }
}
