using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType}
            //{tire1Pressure} {tire1Age}
            //{tire2Pressure} {tire2Age}
            //{tire3Pressure} {tire3Age}
            //{tire4Pressure} {tire4Age}"
                        
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Tire[] tires = new Tire[4];
                int tireCounter = 0;
                for (int j = 5; j < 12; j += 2)
                {
                    double tire1Pressure = double.Parse(input[j]);
                    int tire1Age = int.Parse(input[j + 1]);

                    Tire tire = new Tire(tire1Pressure, tire1Age);
                    tires[tireCounter] = tire;
                    tireCounter++;
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);



            }
            string typeCommand = Console.ReadLine();
            List<string> resultCars = new List<string>();
            if (typeCommand == "fragile")
            {
                resultCars = GetCarFragileType(cars, typeCommand, resultCars);

            }
            else if (typeCommand == "flammable")
            {
                resultCars = GetCarFlammableType(cars, typeCommand, resultCars);
            }
            
            Console.WriteLine(string.Join("\r\n", resultCars));

        }

        public static List<string> GetCarFragileType(List<Car> cars, string typeCommand, List<string> resultCars)
        {
            foreach (var currCar in cars)
            {
                if (currCar.Cargo.CargoType == typeCommand && currCar.Tires.Any(x=>x.Pressure < 1))
                {
                    resultCars.Add(currCar.Model);
                }
            }

            return resultCars;
        }

        public static List<string> GetCarFlammableType(List<Car> cars, string typeCommand, List<string> resultCars)
        {
            foreach (var currCar in cars)
            {
                if (currCar.Cargo.CargoType == typeCommand && currCar.Engine.Power > 250)
                {
                    resultCars.Add(currCar.Model);
                }
            }

            return resultCars;
        }
    }
}
