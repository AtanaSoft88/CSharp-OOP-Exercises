using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class MainDish : Food
    { //string name, decimal price, double grams. Reuse the base class constructor.
        public MainDish(string name, decimal price, double grams)
            :base(name,price,grams)
        {

        }

    }
}
