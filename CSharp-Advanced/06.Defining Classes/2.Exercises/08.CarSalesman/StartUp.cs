using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            //•	Model: a string property.
            //•	Power: an int property.
            //•	Displacement: an int property, it is optional.
            //•	Efficiency: a string property, it is optional.
            int N = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);

                Engine engine = new Engine() 
                {
                    Model = model,
                    Power = power 
                };

                if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    string efficiency = input[3];

                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }
                else if (input.Length == 3)
                {
                    bool canParse = int.TryParse(input[2], out var result);

                    if (canParse)
                    {
                        engine.Displacement = result;
                        
                    }
                    else
                    {
                        engine.Efficiency = input[2];
                    }
                }
                engines.Add(engine);
            }

            int M = int.Parse(Console.ReadLine());

            for (int j = 0; j < M; j++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                string engine = input[1];

                Engine lookUp = engines.FirstOrDefault(x => x.Model == engine);

                Car car = new Car();
                car.Model = model;
                car.Engine = lookUp;

                if (input.Length == 4)
                {
                    int weight = int.Parse(input[2]);
                    string color = input[3];

                    car.Weight = weight;
                    car.Color = color;

                }
                else if (input.Length == 3)
                {
                    bool canParse = int.TryParse(input[2], out int resultParsed);

                    if (canParse)
                    {
                        car.Weight = resultParsed;
                    }
                    else
                    {
                        car.Color = input[2];
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");

                string dispInfo = car.Engine.Displacement.HasValue ? $"    Displacement: {car.Engine.Displacement}" : $"    Displacement: n/a";
                Console.WriteLine(dispInfo);

                string effInfo = car.Engine.Efficiency != null ? $"    Efficiency: {car.Engine.Efficiency}" : $"    Efficiency: n/a";
                Console.WriteLine(effInfo);

                string weightInfo = car.Weight.HasValue ? $"  Weight: {car.Weight}" : $"  Weight: n/a";
                Console.WriteLine(weightInfo);

                string colorInfo = car.Color != null ? $"  Color: {car.Color}" : $"  Color: n/a";
                Console.WriteLine(colorInfo);
            }

        }
    }
}
