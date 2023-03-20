using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            Car car = new Car();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                car = new Car();
                string[] inputCar = Console.ReadLine().Split();
                string model = inputCar[0];
                double fuelAmount = double.Parse(inputCar[1]);
                double fuelConsumptionFor1km = double.Parse(inputCar[2]);
                if (!cars.Any(x=>x.Model == model))
                {
                    car.Model = model;
                    car.FuelAmount = fuelAmount;
                    car.FuelConsumptionPerKilometer = fuelConsumptionFor1km;
                    cars.Add(car);
                }                                
                
            }                    

            string cmd = Console.ReadLine();
            while (cmd!="End")
            {
                string[] commands = cmd.Split();
                string modelDriven = commands[1];
                double amountKm = double.Parse(commands[2]);

                car.DriveCar(cars, modelDriven, amountKm);
                                    

                cmd = Console.ReadLine();
            }

            foreach (var currentCar in cars)
            {
                Console.WriteLine($"{currentCar.Model} {currentCar.FuelAmount:f2} {currentCar.TravelledDistance}");
            }

        }
    }
}
