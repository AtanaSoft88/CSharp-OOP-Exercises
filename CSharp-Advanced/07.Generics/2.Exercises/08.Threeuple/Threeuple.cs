using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<T,T1,T2>
    {
       private T item1;
       private T1 item2;
       private T2 item3;

        public Threeuple()
        {
            
        }
        public T Item1 { get => this.item1; set =>this.item1 = value; }
        public T1 Item2 { get => this.item2; set => this.item2 = value; }
        public T2 Item3 { get => this.item3; set => this.item3 = value; }

        public void GetTupleItems()
        {
            Console.WriteLine($"{Item1} -> {Item2} -> {Item3}");       
        
        }
    }
}
