using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleOperations
{
    public abstract class Vehicle
    {
        protected Vehicle(string color)
        {
            Color = color;
        }

        public string Color { get; set; }
    }
}
