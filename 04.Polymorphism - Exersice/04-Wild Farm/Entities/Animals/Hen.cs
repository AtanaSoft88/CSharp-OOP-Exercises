using ConsoleApp3.Entities.Foods;

namespace ConsoleApp3.Entities.Animals
{
    public class Hen : Bird
    {
        private const double Modifier = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
            => "Cluck";

        public override void Eat(IFood food)
        {
            this.Weight += Modifier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }
    }
}
