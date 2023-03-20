using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Cargo
    {
        public Cargo(int weight, string cargoType)
        {
            Weight = weight;
            CargoType = cargoType;
        }
        
        public int Weight { get; set; }

        public string CargoType { get; set; }
    }
}
