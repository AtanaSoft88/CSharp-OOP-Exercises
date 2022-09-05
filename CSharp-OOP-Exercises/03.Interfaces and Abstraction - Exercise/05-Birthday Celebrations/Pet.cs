using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IIdentible
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; }
        public string Birthdate { get; }

        public void AddBirthDate(List<string> result)
        {
            result.Add(Birthdate);
        }
    }
}
