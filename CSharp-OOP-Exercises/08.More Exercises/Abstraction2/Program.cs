namespace Abstraction2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = {"Red-Poisonous-Octopus, 100, 180, 35", "Black-Shark, 250, 180" };
            SeaAnimal animal = null;
            for (int i = 0; i < input.Length; i++)
            {
                bool healthless = false;
                int randomFood = new Random().Next(1, 100);
                if (input[i].Split(", ").Length == 3)
                {
                    string name = input[i].Split(", ")[0];
                    int health = int.Parse(input[i].Split(", ")[1]);
                    int oxygenCapacity = int.Parse(input[i].Split(", ")[2]);
                    animal = new Shark(name, health, oxygenCapacity);
                }
                else
                {
                    string name = input[i].Split(", ")[0];
                    int health = int.Parse(input[i].Split(", ")[1]);
                    int oxygenCapacity = int.Parse(input[i].Split(", ")[2]);
                    int additionalOxygen = int.Parse(input[i].Split(", ")[3]);
                    animal = new Octopus(name, health, oxygenCapacity, additionalOxygen);
                }

                int count = 1;
                Console.WriteLine($"<***> {animal.Name}");
                while (animal.isAlive)
                {
                    if (count % 2 == 0)
                    {
                        animal.GetSick();
                        Console.WriteLine("Sickness: " + "Health: " + animal.Health + " " + "Oxigen: " + animal.OxygenCapacity);
                        if (animal.isAlive == false)
                        {
                            healthless = true;
                            continue;
                        }
                    }
                    animal.Eat(randomFood);
                    Console.WriteLine("Eating: "+"Health: " + animal.Health + " " + "Oxigen: " + animal.OxygenCapacity);
                    count++;

                }
                if (!healthless)
                {
                    Console.WriteLine($"{animal.Name} died due to lack of Oxygen and remained with {animal.Health} health");
                }
                else
                {
                    Console.WriteLine($"{animal.Name} died due to lack of Health and remained with {animal.Health} health");
                }
                
                Console.WriteLine(animal.ToString());
                Console.WriteLine();
                Console.WriteLine(new String('*', 60));
                Console.WriteLine();
            }
        }
    }
}