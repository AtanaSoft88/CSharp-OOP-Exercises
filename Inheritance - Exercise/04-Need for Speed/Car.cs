using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car:Vehicle
    { // •	Car – DefaultFuelConsumption = 3
        private const double DefaultFuelConsumption = 3;
        public Car(int horsePower, double fuel)
                : base(horsePower, fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
