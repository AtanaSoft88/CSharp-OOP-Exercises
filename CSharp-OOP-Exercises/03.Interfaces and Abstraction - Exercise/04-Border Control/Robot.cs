using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IEqualAdd
    {
        public Robot(string name, string iD)
        {
            Name = name;            
            ID = iD;
            
        }
        
        public string Name { get; }        
        public string ID { get; }              

        
        public void AddiD(List<string> result)
        {
            result.Add(ID);

        }
    }
}
