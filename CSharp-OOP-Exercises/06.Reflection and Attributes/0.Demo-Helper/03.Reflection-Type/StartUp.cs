using System;
using System.Collections.Generic;
using System.Linq;

namespace Reflection_Type
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car("Golf", 2005, 105, "Diesel", 4, "Yellow");

            car.Repaint(Console.ReadLine());
            Console.WriteLine(car.ToString());
            Console.WriteLine();

            //Getting collection of string represented by enum values , printed by string.join and foreach
            var enumValues = Enum.GetNames(typeof(ColorEnum)).ToList();
            Console.WriteLine(string.Join(",", enumValues));

            foreach (var element in enumValues)
            {
                Console.WriteLine(element);
            }

            // using reflection to iterate an Enum class of string colors
            for (int i = 0; i < Enum.GetValues(typeof(ColorEnum)).Length; i++)
            {
                Console.WriteLine($"{Enum.GetName(typeof(ColorEnum),i)}");
            }
            Console.WriteLine();
            Console.WriteLine();

            // using reflection to join strings of an Enum class 
            Console.WriteLine("Using reflection to join strings of an Enum class");
            Console.WriteLine($"{string.Join(",", Enum.GetNames(typeof(ColorEnum)))}");
            Console.WriteLine();
            Console.WriteLine();

            // We can add to an empty List of string all enum colors
            Console.WriteLine("We can add to an empty List of string all enum colors");
            List<string> listedColors = Enum.GetNames(typeof(ColorEnum)).ToList();
            Console.WriteLine("Listed colors :");
            Console.WriteLine(string.Join("/", listedColors));
            Console.WriteLine();
            Console.WriteLine();

            //access to indexes of the enum colors in the class
            Console.WriteLine("Gain access to indexes of the enum colors in the class");
            foreach (int item in Enum.GetValues(typeof(ColorEnum)))
            {
                Console.Write(item + " ");
            }            
        }
    }
}
