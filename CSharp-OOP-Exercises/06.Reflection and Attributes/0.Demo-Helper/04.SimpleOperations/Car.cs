using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleOperations
{
    public class Car:Vehicle
    {
        private string oldColor;
        public Car(string model, int age, int hP,string color)
            :base(color)
            
        {
            Model = model;            
            Age = age;
            HP = hP;
            
        }

        public string Model { get;}        
        public int Age { get;}
        public int HP { get;}

        public override string ToString()
        {  
            return $"Model is:{Model}, Age of car: {Age}, HP:{HP}";
        }
    }
}
