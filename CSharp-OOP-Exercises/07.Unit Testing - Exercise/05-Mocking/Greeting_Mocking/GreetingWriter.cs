using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Mocking
{
    public class GreetingWriter
    {
        private IWriter writer;

        public GreetingWriter(IWriter _writer)
        {
            this.writer = _writer;
        }
        // This trick - using overload of this method with empty brackets, so if a user don't pass argument even then our method will work
        //This method calls the method with same name but with argument in brackets
        public void WriteGreeting() 
        { 
            WriteGreeting(DateTime.Now);
        }
        // According to Dependency Inversion - this example is injecting variable into a method as argument , coming from outside.
        public void WriteGreeting(DateTime dateTime) 
        {
            if (dateTime.Hour < 12)
            {
                writer.Write($"Good morning, time is: {dateTime.ToString("dd/MM/yyyy |>-<| [HH:mm]")}");
            }
            else if (dateTime.Hour < 17)
            {
                writer.Write($"Good afternoon, time is: {dateTime.ToString("dd/MM/yyyy |>-<| [HH:mm]")}");
            }
            else
            {
                writer.Write($"Good evening, time is: {dateTime.ToString("dd/MM/yyyy |>-<| [HH:mm]")}");
            }
        }
    }
}
