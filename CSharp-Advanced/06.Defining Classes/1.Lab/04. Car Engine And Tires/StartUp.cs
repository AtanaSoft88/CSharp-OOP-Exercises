using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car carBlue = new Car();

            Car carRed = new Car(make, model, year);

            Car carGreen = new Car(make, model, year, fuelQuantity, fuelConsumption);

            Tire[] tires = new Tire[4];
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.5),                          

            //};

            for (int i = 0; i < tires.Length; i++)
            {
                Random rnd = new Random();
                int numYear = rnd.Next(2000, 2022);
                double numPress = Math.Round((rnd.NextDouble() * (3.0 - 0.0) + 0.0), 2); // задавам рандъм дабъл от 0.0 до 3.0 , закръглен със Мат раунд до 2 знак.

                tires[i] = new Tire(numYear, numPress);
            }

            Engine engine = new Engine(560, 6300);
            Car car = new Car("FW", " Golf" , 2005 ,250, 9 ,engine,tires);

           
            
            carBlue.Drive(50);
            carRed.Drive(150);
            carGreen.Drive(333);
            Console.WriteLine($"...{carBlue.WhoAmI()}\r\n...{carRed.WhoAmI()}\r\n...{carGreen.WhoAmI()}");
        }
    }
}
