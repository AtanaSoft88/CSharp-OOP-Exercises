using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class Hero
    {
        protected Hero(string nameHero, int powerOfHero,string type)
        {
            NameHero = nameHero;
            PowerOfHero = powerOfHero;
            TypeHero = type;
        }
       
        public string NameHero { get;}        
        public int PowerOfHero { get;}
        public string TypeHero { get;}

        public abstract string CastAbility();
        
    }
}
