using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T,T1>
    {
        public Tuple(T itrem1, T1 itrem2)
        {
            Item1 = itrem1;
            Item2 = itrem2;
        }

        public T Item1 { get; set; }
        public T1 Item2 { get; set; }

        public void GetTupleItems()
        {
            Console.WriteLine($"{Item1} -> {Item2}");       
        
        }
    }
}
