using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Person person = new Person();
            
            
            Console.WriteLine($"{person.Name} , {person.Age}");
        }
    }
}
