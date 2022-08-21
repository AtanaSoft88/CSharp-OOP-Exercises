using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] CarInfo = Console.ReadLine().Split();
            string[] TruckInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(CarInfo[1]);
            double carLitersPerKm = double.Parse(CarInfo[2]);

            double truckFuelQuantity = double.Parse(TruckInfo[1]);
            double truckLitersPerKm = double.Parse(TruckInfo[2]);

            Car car = new Car(carFuelQuantity, carLitersPerKm);
            Truck truck = new Truck(truckFuelQuantity, truckLitersPerKm);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string typeCmd = input[0];
                string vechile = input[1];
                double value = double.Parse(input[2]);

                if (typeCmd == "Drive")
                {
                    if (vechile is "Car") // vechile == "Car"
                    {
                        if (car.CanDrive(value))
                        {
                            car.Drive(value);
                            Console.WriteLine($"Car travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }

                    }
                    else if (vechile is "Truck")
                    {
                        if (truck.CanDrive(value))
                        {
                            truck.Drive(value);
                            Console.WriteLine($"Truck travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }

                    }
                    
                }
                else // refuel
                {
                    if (vechile is "Car")
                    {
                        car.Refuel(value);
                    }
                    else
                    {
                        truck.Refuel(value);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
