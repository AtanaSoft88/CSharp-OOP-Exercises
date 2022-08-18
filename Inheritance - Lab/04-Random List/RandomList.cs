using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        Random rnd = new Random();
        public string RandomString()
        {            
            int index = rnd.Next(0, this.Count);
            string element = this[index];
            RemoveAt(index);
            
            return element;


        }
    }
}
