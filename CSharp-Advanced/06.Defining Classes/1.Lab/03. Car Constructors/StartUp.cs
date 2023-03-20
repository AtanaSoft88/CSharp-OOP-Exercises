using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());



            Car carBlue = new Car();

            Car carRed = new Car(make,model,year);

            Car carGreen = new Car(make,model,year,fuelQuantity,fuelConsumption);

            carBlue.Drive(50);
            carRed.Drive(150);
            carGreen.Drive(333);
            Console.WriteLine($"...{carBlue.WhoAmI()}\r\n...{carRed.WhoAmI()}\r\n...{carGreen.WhoAmI()}");
        }
    }
}
