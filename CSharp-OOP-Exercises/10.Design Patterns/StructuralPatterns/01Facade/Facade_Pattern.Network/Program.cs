namespace Facade_Pattern.Network
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //We only instantiate the facadeClass with needed parameters which constructor requres, and call the single Method which calls other sub-classes methods at once.
            var facadeNetwork = new NetworkFacade("8.8.8.8","192.168.1.1", "80");
            facadeNetwork.SendPacketOverNetwork();
        }
    }
}