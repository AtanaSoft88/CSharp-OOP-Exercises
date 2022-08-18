using System;

namespace Restaurant
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Fish fishOne = new Fish("Barakuda",55.5M);
            Console.WriteLine($"Fish as grams: {fishOne.Grams}");

            Dessert dessert = new Dessert("IceCream",5.2M, 200, 700);
            Console.WriteLine($"Dessert as grams: {dessert.Grams}");

            Cake cake = new Cake("ChocoPie");
            Console.WriteLine($"Cake as grams: {cake.Grams}");
        }
    }
}
