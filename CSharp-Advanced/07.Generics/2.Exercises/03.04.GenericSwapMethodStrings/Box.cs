using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
    {
        public Box()
        {
            Items = new List<T>();
        }
        public List<T> Items { get; set; }

        public void SwapMeth<T>(int first,int second)
        {
            
            if (first >= 0 && first < Items.Count && second >= 0 && second < Items.Count)
            {
                //Swap Вариант 1
                //var temp = Items[first];
                //Items[first] = Items[second];
                //Items[second] = temp;

                //Swap Вариант 2
                (Items[first], Items[second]) = (Items[second], Items[first]);
            }
            
        }

        public override string ToString()
        => string.Join("\r\n", Items.Select(x => $"{typeof(T)}: {x}"));
    }
}
