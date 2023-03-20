using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        public Tire(double pressure, double age)
        {
            Pressure = pressure;
            Age = age;
        }

        public double Pressure { get; set; }

        public double Age { get; set; }
    }
}
