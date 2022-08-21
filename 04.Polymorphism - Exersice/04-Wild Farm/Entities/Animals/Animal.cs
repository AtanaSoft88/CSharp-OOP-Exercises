using ConsoleApp3.Entities.Foods;

namespace ConsoleApp3.Entities.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public abstract string ProduceSound();

        public abstract void Eat(IFood food);
    }
}
