using ConsoleApp3.Entities.Foods;
using System;

namespace ConsoleApp3.Entities.Animals
{
    public class Dog : Mammal
    {
        private const double Modifier = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
            => "Woof!";

        public override void Eat(IFood food)
        {
            if (food is Meat)
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
