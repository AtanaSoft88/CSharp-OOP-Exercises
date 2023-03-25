namespace Greeting_Mocking
{
    public class Program
    {
        static void Main(string[] args)
        {
            var writer = new GreetingWriter(new ConsoleWriter());
            // Current DateTime comes from outside, passed as argument to the method "WriteGreeting" , Dependency Inversion principle is applied.
            writer.WriteGreeting(new DateTime(2023, 11, 25, 15, 30, 0));
            writer.WriteGreeting(new DateTime(2023, 11, 25, 18,20,10));
            writer.WriteGreeting(new DateTime(2023, 11, 25, 08,15,10));
            writer.WriteGreeting();

            writer = new GreetingWriter(new PrettyWriter());
            writer.WriteGreeting(new DateTime(2023, 11, 25, 08, 15, 10));

            writer = new GreetingWriter(new MessageBoxWriter());
            writer.WriteGreeting(new DateTime(2023, 11, 25, 15, 30, 0));
        }
    }
}