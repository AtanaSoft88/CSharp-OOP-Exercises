using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Mocking
{
    public class PrettyWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(new String('=',60));
            Console.WriteLine($"*** {message} ***");
            Console.WriteLine(new String('=', 60));
        }
    }
}
