using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public static class Validator
    {
        public static void ThrowExceptionNotInRange(int min, int max, int num, string exceptMsg)
        {
            if (num < min || num > max)
            {
                throw new ArgumentException(exceptMsg);
            }
        }

        

    }
}
