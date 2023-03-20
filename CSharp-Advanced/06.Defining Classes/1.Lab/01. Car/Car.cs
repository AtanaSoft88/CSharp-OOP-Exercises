
namespace CarManufacturer
{
    public class Car
    {

        public Car(string make, string model, int year)
        {
            this.Make = make = "VW";
            this.Model = model = "MK3";
            this.Year = year = 1992;
        }
        public Car()
        {
            
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

    }
}
