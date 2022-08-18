using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(160,70);
            vehicle.Drive(10);
            Console.WriteLine($"Vehicle Fuel left: {vehicle.Fuel}");

            Car car = new Car(150,50);
            car.Drive(15);
            Console.WriteLine($"Car Fuel left: {car.Fuel}");

            RaceMotorcycle raceMoto = new RaceMotorcycle(190,85);
            raceMoto.Drive(5.5);
            Console.WriteLine($"RaceMotorcycle Fuel left: {raceMoto.Fuel}");

            CrossMotorcycle crossM = new CrossMotorcycle(130,95);
            crossM.Drive(15);
            Console.WriteLine($"CrossMotorcycle Fuel left: {crossM.Fuel}");
        }
    }
}
