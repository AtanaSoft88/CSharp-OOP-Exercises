using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern.Network
{
    public class NetworkFacade
    {
        //All sub-classes combined here as private fields
        // Constructor of "NetworkFacade" containing new instances of the above sub-classes
        //void FacadeMethod calling all sub-classes methods.

        private Socket socket;
        private Packet packet;
        private Transimission transmission;

        public NetworkFacade(string protocol, string ipAddress, string port)
        {
            this.socket = new Socket(protocol,port);
            this.packet = new Packet(ipAddress);
            this.transmission = new Transimission(protocol);
        }

        private void NewtworkBuild() 
        {
            this.packet.PacketBuilt();
            this.socket.SocketBuilt();
        }
        public void SendPacketOverNetwork() 
        {
            this.NewtworkBuild();
            this.transmission.SendTransmission();
        }
    }
}
