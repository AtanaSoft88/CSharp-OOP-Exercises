using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reflection_Type
{
    public abstract class Vehicle
    {
        
        public Vehicle(string engineType, int numberTyres, string color)
        {
            EngineType = engineType;
            NumberTyres = numberTyres;
            Color = color;
            
        }
        
        public string EngineType { get;}
        public int NumberTyres { get;}
        public string Color { get; private set; }
        public bool HasBeenRepainted { get; private set; } = false;
        
        public void Repaint(string newColor)
        {
            
            foreach (string color in Enum.GetNames(typeof(ColorEnum))) // this way we can iterate through all colors in enum - using Reflection
            {
                if (color == newColor && color != this.Color)
                {
                    Color = newColor;
                    HasBeenRepainted = true;
                    return;
                }
            }

            


        }
    }
}
