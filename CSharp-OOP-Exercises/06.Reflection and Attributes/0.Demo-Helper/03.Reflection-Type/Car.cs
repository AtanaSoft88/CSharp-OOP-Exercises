using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_Type
{
    public class Car : Vehicle
    {
        private string oldColor;
        public Car(string model, int age, int hP, string engineType, int numberTyres, string color)
            : base(engineType, numberTyres, color)
        {
            Model = model;
            Age = age;
            HP = hP;
            oldColor = base.Color;
        }

        public string Model { get; }
        public int Age { get; }
        public int HP { get; }

        public override string ToString()
        {  // string model, int age, int hP, string engineType, int numberTyres,string color
            return $"Model is:{Model}, Age of car: {Age}, HP:{HP}, Type of Engine:{base.EngineType},{Environment.NewLine}How many Tires:{base.NumberTyres},First color is {oldColor},Has it been repainted?\r\n{(HasBeenRepainted == true ? $"Yes Color is now:{base.Color}" : $"No Color remains the old one which is:{oldColor}")}";
        }
    }
}
