using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneriCountMethodStrings
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
            int count = 0;
            list = ElementList;

            count = list.Where(x => x.CompareTo(inputArg) > 0).Count();

            return count;
        
        }
    }
}
