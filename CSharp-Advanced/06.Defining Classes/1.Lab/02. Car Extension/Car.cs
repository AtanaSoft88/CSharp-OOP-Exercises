using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        //•make: string
        //•	model: string
        //•	year: int
        //•	fuelQuantity: double
        //•	fuelConsumption: double
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
               
        public Car()
        {
            
        }

        // dolu sa nachinite da napravq properties sus " get i set " po razlichni nachini
        public string Make { get => make; set =>this.make = value; }
        public string Model
        {
            get {return this.model;}
            set {this.model=value;}
        }
        public int Year 
        {
            get=>this.year;
            set=>this.year = value;
        }
        public double FuelQuantity  // here we can validate if the input is <= 0
        {
            get 
            {
                if (this.fuelQuantity <= 0)
                {
                    Console.WriteLine("no negative values permissible");
                }
                return this.fuelQuantity; 
            }
            set 
            {
                this.fuelQuantity=value;  
            } 
        }
        
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }


        public void Drive(double distance)
        {
            if (fuelQuantity - distance*fuelConsumption > 0)
            {
                fuelQuantity -= distance*fuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            

        
        
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:f2}");

            return sb.ToString();
        
        
        }

    }
}
