using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero("pesho",5);
            hero.Level = 10;
            hero.Username = "Gogi";
            Console.WriteLine(hero);
        }
    }
}
