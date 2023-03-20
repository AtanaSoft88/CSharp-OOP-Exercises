using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_by_Age
{
    class Program
    {
        class Student
        {
            public Student(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            public Student()
            {
                
            }

            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                students.Add(new Student(name,age));  
                
            }

            string filterInput = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string formatInput = Console.ReadLine();

            Func<Student,int, bool> filter = GetFilter(filterInput);
            students = students.Where(x => filter(x, ageFilter)).ToList();

            Action<Student> printer = GetPrinter(formatInput);
            students.ForEach(printer);
            
        }

        private static Action<Student> GetPrinter(string formatInput)
        {
            if (formatInput == "name")
            {
                return s => Console.WriteLine(s.Name);
            }
            else if (formatInput == "age")
            {
                return s => Console.WriteLine(s.Age);
            }
            else if (formatInput == "name age")
            {
                return s => Console.WriteLine($"{s.Name} - {s.Age}");
            }
            else
            {
                return null;
            }
        }

        private static Func<Student,int, bool> GetFilter(string filterInput)
        {
            if (filterInput == "older")
            {
                return (s, age) => s.Age >= age;
            }
            else if (filterInput == "younger")
            {
                return (s, age) => s.Age < age;
            }
            else
            {
                return null;
            }
        }
    }
}
