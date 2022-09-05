using ConsoleApp3.Entities.Animals;
using ConsoleApp3.Entities.Foods;
using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<IAnimal> animals = new List<IAnimal>();

            while (input != "End")
            {
                try
                {
                    string[] animalInfo = input.Split();
                    string[] foodInfo = Console.ReadLine().Split();

                    string type = animalInfo[0];
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);

                    IAnimal animal = null;

                    if (type == "Cat" || type == "Tiger")
                    {
                        //"{Type} {Name} {Weight} {LivingRegion} {Breed}"
                        string livingRegion = animalInfo[3];
                        string breed = animalInfo[4];

                        if (type == "Cat")
                        {
                            animal = new Cat(name, weight, livingRegion, breed);
                        }
                        else
                        {
                            animal = new Tiger(name, weight, livingRegion, breed);
                        }
                    }
                    else if (type == "Hen" || type == "Owl")
                    {
                        double wingSize = double.Parse(animalInfo[3]);

                        if (type == "Hen")
                        {
                            animal = new Hen(name, weight, wingSize);
                        }
                        else
                        {
                            animal = new Owl(name, weight, wingSize);
                        }
                    }
                    else
                    {
                        string livingRegion = animalInfo[3];

                        if (type == "Dog")
                        {
                            animal = new Dog(name, weight, livingRegion);
                        }
                        else
                        {
                            animal = new Mouse(name, weight, livingRegion);
                        }
                    }

                    Console.WriteLine(animal.ProduceSound());
                    animals.Add(animal);

                    string foodType = foodInfo[0];
                    int qty = int.Parse(foodInfo[1]);

                    IFood food = null;

                    if (foodType == "Vegetable")
                    {
                        food = new Vegetable(qty);
                    }
                    else if (foodType == "Fruit")
                    {
                        food = new Fruit(qty);
                    }
                    else if (foodType == "Meat")
                    {
                        food = new Meat(qty);
                    }
                    else if (foodType == "Seeds")
                    {
                        food = new Seeds(qty);
                    }

                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
