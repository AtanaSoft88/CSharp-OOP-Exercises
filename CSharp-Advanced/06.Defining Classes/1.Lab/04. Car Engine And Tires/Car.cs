using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        // fields
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

                

        //Constructors
        public Car()
        {
            this.Make = "VW";

            this.Model = "Golf";

            this.Year = 2025;

            this.FuelQuantity = 200;

            this.FuelConsumption = 10;

        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;

        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {

            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;


        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }

        // Properties  " get i set " po razlichni nachini
        public string Make { get => make; set => this.make = value; }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get => this.year;
            set => this.year = value;
        }
        public double FuelQuantity  // here we can validate if the input is <= 0
        {
            get
            {
                if (this.fuelQuantity <= 0)
                {
                    // write exception for negative result 
                }
                return this.fuelQuantity;
            }
            set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption { get { return this.fuelConsumption; } set {this.fuelConsumption = value; } }
        
        public Engine Engine {get => this.engine;set => this.engine = value;}  // public type -> tova e Engine 
        public Tire[] Tires { get => this.tires; set => this.tires = value; } // public type -> tova e Tire[]



        // Methods
        public void Drive(double distance)
        {
            if (fuelQuantity - distance * fuelConsumption > 0)
            {
                fuelQuantity -= distance * fuelConsumption;
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
