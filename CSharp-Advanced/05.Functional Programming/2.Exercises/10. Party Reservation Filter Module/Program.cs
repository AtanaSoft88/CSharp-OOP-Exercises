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
            Dictionary<string, Predicate<string>> allFilters = new Dictionary<string, Predicate<string>>();
            string command = Console.ReadLine();

            //Peter Misha Slav
            //Add filter; Starts with; P
            //Add filter; Starts with; M
            //Print

            while (command != "Print")
            {
                string[] input = command.Split(";",StringSplitOptions.RemoveEmptyEntries);
                string print = input[0];
                string operation = input[1];
                string value = input[2];

                if (print == "Add filter") 
                {
                    allFilters.Add(operation + value,GetPredicate(operation,value));
                } 
                else
                {
                    allFilters.Remove(operation + value);
                }

                command = Console.ReadLine();
            }
            foreach (var filter in allFilters)
            {
                namesList.RemoveAll(filter.Value);
            }
            Console.WriteLine(string.Join(" ",namesList));
        }

        private static Predicate<string> GetPredicate(string operation, string value)
        {

            if (operation == "Starts with")
            {
                return x => x.StartsWith(value);
            }
            if (operation == "Ends with")
            {
                return x => x.EndsWith(value);
            }
            if (operation == "Contains")
            {
                return x => x.Contains(value);
            }
            
                return x => x.Length == int.Parse(value);
                    


        }
    }
}
