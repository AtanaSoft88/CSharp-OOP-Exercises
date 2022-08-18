using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        string firstName;
        string lastName;
        int age;
        decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName 
        {
            get 
            {
               return this.firstName ; 
            }
            private set 
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                else
                {
                    this.firstName = value;
                }
               
            }
        } 
        public string LastName { get => this.lastName;

            private set 
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                else
                {
                    this.lastName = value;
                }
            } 
        }
        public int Age 
        {
            get 
            {
               return this.age ; 
            }
            private set 
            {
                if (value <=0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                else
                {
                    this.age = value;
                }
               
            } 
        } // private set -> can't change the property but we can read it 
        
        public decimal Salary
        {
            get 
            {
                return this.salary; 
            }
            set 
            {
                if (value < 650)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                this.salary = value; 
            }
        }


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
