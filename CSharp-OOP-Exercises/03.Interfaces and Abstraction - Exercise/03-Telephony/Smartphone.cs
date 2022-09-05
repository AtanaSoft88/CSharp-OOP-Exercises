using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        private string phoneNumOrWeb;
        

        public Smartphone(string phone)
        {
            this.phoneNumOrWeb = phone;
        }
        

        public void Browse()
        {
            Console.WriteLine($"Browsing: {this.phoneNumOrWeb}!");
        }

        public void Calling() 
        {
            Console.WriteLine($"Calling... {this.phoneNumOrWeb}");
        }
        
    }
}
