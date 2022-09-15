using System;

namespace P03_FootballBetting
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //1)This Startup project should have reference of the Project with DbContext
            //2)The project with DbContext should have reference of the project with Models
            //3)The project with Models should not have any reference for now.
        }
    }
}
