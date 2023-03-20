using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericCountMethodDoubles
{
    public class BoxElements<T> where T : IComparable
    {
        public BoxElements()
        {
            ElementList = new List<T>();
        }
        public List<T> ElementList { get; set; }


        public int GreatherElement(List<T> list , T inputArg)
        {
            list = ElementList;

            int count = 0;
            count = list.Where(x => x.CompareTo(inputArg) > 0).Count();

            return count;
        
        }
    }
}
