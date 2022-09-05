using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IEqualAdd
    { // "{name} {age} {id}" 
        
        public Citizen(string name, int age, string iD)
        {
            Name = name;
            Age = age;
            ID = iD;
            
        }
        
        public string Name { get;}
        public int Age { get; }
        public string ID { get;}
        
        

        public void AddiD(List<string> result)
        {
            result.Add(ID);
        }
    }
}
