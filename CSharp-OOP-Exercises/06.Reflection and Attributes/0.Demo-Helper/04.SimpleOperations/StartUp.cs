using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleOperations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Reflection - getting data from instance of a class
            Car car = new Car("GolfV+", 2005, 105, "Blue");
            Console.WriteLine(car.GetType().Name);
            Console.WriteLine(car.GetType().FullName); // fully qualified name
            Console.WriteLine(car.GetType().BaseType.Name);  //Vehicle is the base class         

            Vehicle veh = new Car("Golf4", 2001, 90, "Red");

            // Reflection showing All about class Car , using Type class .
            Type type = typeof(Car);
            Console.WriteLine($"Name of type :|: {type.Name}");
            Console.WriteLine($"Fully qualified name:|: {type.FullName}");  // gets fully qualified name of the type!
            Console.WriteLine($"Gets Assembly :|: {type.Assembly.Location}");
            Console.WriteLine($"Gets Base class : {type.BaseType.Name}");  // => Vehicle is the base class and we know it

            //Reflection if input is UNKNOWN and comes from outside World
            string input = Console.ReadLine(); //  we should enter -> "Namespace.ClassName" in this case -> "SimpleOperations.Car"
            Type typeOutside = Type.GetType(input); // GetType expects fully qualified name "Namespace.ClassName".
            Console.WriteLine(typeOutside?.BaseType?.Name);

            // If we want "if" construction to ask about null condition =>> 
            //if (typeOutside != null)  
            //{
            //    Console.WriteLine(typeOutside.BaseType.Name);
            //}

            
            
        }
    }
}
