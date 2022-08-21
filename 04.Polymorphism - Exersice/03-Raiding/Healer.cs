using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class Healer : Hero
    {
        protected Healer(string nameHero, int powerOfHero, string type) 
            : base(nameHero, powerOfHero, type)
        {
        }
        public override string CastAbility()
        {
            return $"{base.TypeHero} - {this.NameHero} healed for {this.PowerOfHero}";
        }
    }
}
