using ConsoleApp3.Entities.Foods;

namespace ConsoleApp3.Entities.Animals
{
    public interface IAnimal
    {
        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public string ProduceSound();

        void Eat(IFood food);
    }
}
