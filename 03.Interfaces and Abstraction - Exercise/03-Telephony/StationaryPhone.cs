using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICalling
    {
        private string number;

        public StationaryPhone(string number)
        {
            this.number = number;
        }

        public void Calling()
        {
            Console.WriteLine($"Dialing... {this.number}");
        }

         
    }
}
