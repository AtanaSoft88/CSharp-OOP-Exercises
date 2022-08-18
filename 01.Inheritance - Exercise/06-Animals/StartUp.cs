using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string inputAnimal = Console.ReadLine();

            while (inputAnimal != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                Animal animal = new Animal(name, age, gender);  // using polymorphism can involve all animals as childs,represented by Parent Animal

                if (inputAnimal == "Cat")
                {
                    animal = new Cat(name, age, gender);
                    
                }
                else if (inputAnimal == "Dog")
                {
                    animal = new Dog(name, age, gender);


                }
                else if (inputAnimal == "Frog")
                {
                    animal = new Frog(name, age, gender);

                }
                else if (inputAnimal == "Kitten")
                {
                    animal = new Kitten(name, age);

                }
                else if (inputAnimal == "Tomcat")
                {
                    animal = new Tomcat(name, age);

                }
                if (animal.Age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    inputAnimal = Console.ReadLine();
                    continue;
                }
                Console.WriteLine(inputAnimal);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                string sountOutput = animal.ProduceSound();
                Console.WriteLine(sountOutput);

                inputAnimal = Console.ReadLine();

            }
        }
    }
}
