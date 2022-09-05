using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robot 
    {
        public Robot(string model, string iD)
        {
            Model = model;            
            ID = iD;
            
        }
        
        public string Model { get; }        
        public string ID { get; }       
        
    }
}
