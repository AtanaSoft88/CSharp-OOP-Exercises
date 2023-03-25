namespace Restorant
{
    internal class Program
    {
        static Waiter tableWaiter1 = Waiter.GetTablesHandled();
        static Waiter tableWaiter2 = Waiter.GetTablesHandled();
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                ClientOneGetNextWaiter();
                ClientTwoGetNextWaiter();
            }
        }
        private static void ClientOneGetNextWaiter() 
        {
            Console.WriteLine($"The next waiter is: {tableWaiter1.GetNextWaiter()}");
        }

        private static void ClientTwoGetNextWaiter()
        {
            Console.WriteLine($"The next waiter is: {tableWaiter2.GetNextWaiter()}");
        }
    }
}