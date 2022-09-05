using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {            
            int lines = int.Parse(Console.ReadLine());            
            
            List<Hero> heroes = new List<Hero>();
            
            while (heroes.Count != lines)
            {
                string name = Console.ReadLine();
                string typeHero = Console.ReadLine();
                                
                Hero hero = null;
                if (typeHero == "Paladin")
                {
                    hero = new Paladin(name, typeHero);

                }
                else if (typeHero == "Druid")
                {
                    hero = new Druid(name, typeHero);
                }
                else if (typeHero == "Rogue")
                {
                    hero = new Rogue(name, typeHero);
                }
                else if (typeHero == "Warrior")
                {
                    hero = new Warrior(name, typeHero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }
                heroes.Add(hero);
            }
            int BossHealth = int.Parse(Console.ReadLine());            
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                
            }
            int sumPower = heroes.Sum(x => x.PowerOfHero);
            if (sumPower >= BossHealth)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
