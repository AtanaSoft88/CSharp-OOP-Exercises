using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> listPerson = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name,age);
                listPerson.Add(person);
            }

           listPerson = listPerson.OrderBy(x => x.Name).Where(x => x.Age > 30).ToList();

            foreach (var people in listPerson)
            {
                Console.WriteLine($"{people.Name} - {people.Age}");
            }

        }
    }
}
