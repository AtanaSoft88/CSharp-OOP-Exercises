using System;
using System.Collections.Generic;
using System.Text;

namespace _00.Demo_Json
{
    public class Car
    {
        public Car()
        {
            Extras = new List<string>();
            Engine = new Engine();
        }
        
        public string Model { get; set; }

        public string Description { get; set; }

        public DateTime ManufacturedOn { get; set; }
        
        public string Color { get; set; }

        public decimal Price { get; set; }
        public List<string> Extras { get; set; }

        public Engine Engine { get; set; }


    }
}
