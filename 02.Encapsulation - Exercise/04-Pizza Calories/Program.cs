using System;
using System.Linq;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaName = Console.ReadLine().Split()[1];
            var doughData = Console.ReadLine().Split();

            var flourType = doughData[1];
            var bakingTechnique = doughData[2];
            var weight = int.Parse(doughData[3]);
            try
            {

                Dough dough = new Dough(flourType, bakingTechnique, weight);

                var pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    var line = Console.ReadLine();

                    if (line == "END")
                    {
                        break;
                    }

                    var parts = line.Split();
                    var toppingName = parts[1];
                    var toppingWeight = int.Parse(parts[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);

                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():f2} Calories.");
            }
            catch (Exception ex)
            when (ex is ArgumentException || ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
                
            }
            
        }
    }
}
