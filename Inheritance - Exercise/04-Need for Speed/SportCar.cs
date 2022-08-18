using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {//•	SportCar – DefaultFuelConsumption = 10
        private const double DefaultFuelConsumption = 10;
        public SportCar(int horsePower, double fuel)
               : base(horsePower, fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
