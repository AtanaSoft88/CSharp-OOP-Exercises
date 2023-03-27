using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant
{
    public class Waiter
    {
        private static Waiter _instance;
        private List<string> waiters = new List<string>();
        private static readonly object _lock = new object();
        private int nextWaiter=0;
        private Waiter()
        {
            waiters.Add("Niko");
            waiters.Add("Pesho");
            waiters.Add("Emo");
            waiters.Add("Gosho");
        }
        public static Waiter GetTablesHandled() 
        {
            if (_instance==null)
            {
                lock (_lock)
                {
                    if (_instance==null)
                    {
                        _instance = new Waiter();
                        Console.WriteLine("Create instance Singleton");
                    }
                }
            }
            return _instance;
        }

        public string GetNextWaiter() 
        {
            string output = waiters[nextWaiter];
            nextWaiter++;
            if (nextWaiter >= waiters.Count())
            {
                nextWaiter = 0;
            }
            return output;
        }
    }
}
