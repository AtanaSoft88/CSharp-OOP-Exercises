
namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm) // when abstract class is used - constructor is protected ( not public!)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity { get; set; }
        public virtual double FuelConsumptionPerKm { get; set; }//we need to set different value for truck and car - so virtual can be overriden in other class

        public bool CanDrive(double km) => this.FuelQuantity - (this.FuelConsumptionPerKm * km) >= 0;  //true /false
        public void Drive(double km)
        {  // 100L  - > 100km * 1 = true
            if (CanDrive(km))
            {
                this.FuelQuantity -= (km * FuelConsumptionPerKm);
            }
            
        }
        public virtual void Refuel(double amount) //we need to set different value for truck and car - so virtual can be overriden in other class
        {
            this.FuelQuantity += amount;
        }


    }
}
