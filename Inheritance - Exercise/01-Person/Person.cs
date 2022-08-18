using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    { // -	People should not be able to have a negative age
        string name;
        int age;

        public Person(string name, int age)
        {
            this.Name = name;
            if (age < 0)
            {
                this.Age = 0;
                return;
            }
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
       

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}, Age: {Age}");            
            return sb.ToString();
        }
    }
}
