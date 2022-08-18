using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("gogo");
            list.Add("Nasko");
            list.Add("chocho");
            list.Add("Pepi");

            Console.WriteLine(list.RandomString());
        }
    }
}
