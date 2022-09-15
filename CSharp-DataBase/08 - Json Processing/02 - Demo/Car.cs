using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Demo_Json_Newton
{
    public class Car
    {
        public Car()
        {
            Extras = new List<string>();
            Engine = new Engine();
        }

        [JsonProperty("CarModel")] // hit Ctrl+Shitft + Space to see All local settings for this property
        public string ModelName { get; set; }

        
        public string Description { get; set; }
        
        public DateTime ManufacturedOn { get; set; }
        
        public string ColorOfTheCar { get; set; }

        public decimal Price { get; set; }

        [JsonIgnore] // It is not included in Json file / Ignored
        public List<string> Extras { get; set; }

        public Engine Engine { get; set; }


    }
}
