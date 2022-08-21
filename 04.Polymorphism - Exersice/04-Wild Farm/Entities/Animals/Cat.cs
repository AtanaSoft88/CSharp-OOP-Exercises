using ConsoleApp3.Entities.Foods;
using System;

namespace ConsoleApp3.Entities.Animals
{
    public class Cat : Feline
    {
        private const double Modifier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
            => "Meow";

        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Meat)
            {
                this.Weight += Modifier * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
