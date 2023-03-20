using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> namesList = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] input = command.Split();
                string criteria = input[0];
                string operation = input[1];
                string value = input[2];

                if (criteria == "Double")
                {
                    List<string> allNamesDoubled = namesList.FindAll(GetPredicate(operation, value));

                    if (allNamesDoubled.Count()==0)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    int index = namesList.FindIndex(GetPredicate(operation, value));

                   namesList.InsertRange(index, allNamesDoubled);
                }
                else 
                {
                    namesList.RemoveAll(GetPredicate(operation, value));
                }


                command = Console.ReadLine();
            }

            if (namesList.Any())
            {
                Console.WriteLine($"{string.Join(", ", namesList)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string operation, string value)
        {
            
            if (operation == "StartsWith")
            {
                return x => x.StartsWith(value);
            }
            if (operation == "EndsWith")
            {
                return x => x.EndsWith(value);
            }

            return x => x.Length == int.Parse(value);


        }
    }
}
