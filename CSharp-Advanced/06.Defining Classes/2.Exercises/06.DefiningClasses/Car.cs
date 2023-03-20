using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
       private string model;       
       private double fuelAmount;
       private double fuelConsumptionPerKilometer;
       private double travelledDistance = 0;


        public Car()
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = travelledDistance;
        }

        public string Model 
        {
            
            get 
            {
               return this.model; 
            }
            set
            {

                this.model = value;
            }
        }
        public double FuelAmount 
        {
            get
            {
                return this.fuelAmount;
            }
            set 
            {
                this.fuelAmount = value; 
            } 
        }


        public double FuelConsumptionPerKilometer { get => this.fuelConsumptionPerKilometer; set => this.fuelConsumptionPerKilometer = value; }

        public double TravelledDistance { get; set; }


        public void DriveCar(List<Car> cars, string modelDriven, double amountKm)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Model == modelDriven)
                {
                    if (cars[i].FuelAmount - (amountKm * cars[i].FuelConsumptionPerKilometer) >= 0)
                    {
                        cars[i].FuelAmount -= amountKm * cars[i].FuelConsumptionPerKilometer;
                        cars[i].TravelledDistance += amountKm;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }

                }

            }
        }
    }
}
