using System;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input !="End")
            {
                string[] inputCmd = input.Split();
                string name = inputCmd[0];
                string country = inputCmd[1];
                int age = int.Parse(inputCmd[2]);
                IPerson person = new Citizen(name, country,age);
                IResident resident = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
                input = Console.ReadLine();
            }

        }
    }
}
