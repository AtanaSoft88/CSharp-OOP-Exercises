using ConsoleApp3.Entities.Foods;
using System;

namespace ConsoleApp3.Entities.Animals
{
    public class Mouse : Mammal
    {
        private const double Modifier = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
            => "Squeak";

        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Fruit)
            {
                this.Weight += Modifier * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ToString()
            => $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
