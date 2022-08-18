using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Starter : Food
    { //string name, decimal price, double grams. Reuse the base class constructor.
        public Starter(string name, decimal price, double grams)
            : base(name, price, grams)
        {

        }

    }
}
