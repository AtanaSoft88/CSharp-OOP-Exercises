using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Creating Data-Base without Migrations :)
            StudentSystemContext context = new StudentSystemContext();
            context.Database.EnsureDeleted();
            Console.WriteLine("Deleted");
            
            Console.WriteLine("Do you want to create it again? - y / n");
            string answer = Console.ReadLine();
            if (answer=="y")
            {
                context.Database.EnsureCreated();
                Console.WriteLine("Db created again successfully! :)");
            }
            else if (answer=="n")
            {
                Console.WriteLine("Ok we will not create this db :(");
            }

            Console.WriteLine("Bye bye!");
        }
    }
}
