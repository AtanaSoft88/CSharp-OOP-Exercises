using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDateInput = Console.ReadLine();
            string secondDateInput = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();
                        
            int result = Math.Abs(DateModifier.CalcolateDifference(firstDateInput, secondDateInput));

            Console.WriteLine(result);


        }
    }
}
