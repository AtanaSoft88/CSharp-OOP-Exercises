using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public static class Validator
    {
        public static void ThrowExceptionStringNullOrEmpty(string str, string exceptMsg)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(exceptMsg);
            }
        }

        public static void ThrowExceptionValueNegative(decimal num, string exceptMsg)
        {
            if (num < 0)
            {
                throw new ArgumentException(exceptMsg);
            }
        }
    }
}
