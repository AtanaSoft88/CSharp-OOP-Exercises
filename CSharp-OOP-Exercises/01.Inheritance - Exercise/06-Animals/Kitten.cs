﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat  // Female by default
    {
        public Kitten(string name, int age)
            :base(name, age, "Female")
        {

        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
