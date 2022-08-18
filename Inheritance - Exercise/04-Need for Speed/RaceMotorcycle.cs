using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle:Motorcycle
    { //•	RaceMotorcycle – DefaultFuelConsumption = 8
        private const double DefaultFuelConsumption = 8;
        public RaceMotorcycle(int horsePower, double fuel)
                : base(horsePower, fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
