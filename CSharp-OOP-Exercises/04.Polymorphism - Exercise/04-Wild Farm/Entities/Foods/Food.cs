namespace ConsoleApp3.Entities.Foods
{
    public class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; }
    }
}
