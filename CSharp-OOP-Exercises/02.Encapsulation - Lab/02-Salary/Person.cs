using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName { get; private set; } 
        public string LastName { get; private set; }
        public int Age { get; private set; } // private set -> can't change the property but we can read it 
        public decimal Salary { get; set; }

        public void IncreaseSalary(decimal percentage) // 20 %
        {
            if (this.Age < 30)
            {
                decimal increase = Salary * percentage /100;
                Salary += increase /2;
            }
            else
            {
                Salary += Salary * percentage / 100;
            }
            
        
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        } // Andrew Williams receives 2640.00 leva.
    }
}
