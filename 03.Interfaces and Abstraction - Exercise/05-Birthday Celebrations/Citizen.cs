using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IIdentible
    { // "{name} {age} {id}" 
        
        public Citizen(string name, int age, string iD, string birthdate)
        {
            Name = name;
            Age = age;
            ID = iD;
            Birthdate = birthdate;
        }
        
        public string Name { get;}
        public int Age { get; }
        public string ID { get;}
        public string Birthdate { get;}
        
        

        public void AddBirthDate(List<string> IdList)
        {
            IdList.Add(Birthdate);
        }
    }
}
