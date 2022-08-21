using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class DamageDealer : Hero
    {
        protected DamageDealer(string nameHero, int powerOfHero, string type) 
            : base(nameHero, powerOfHero, type)
        {
        }

        public override string CastAbility()
        {
           return $"{base.TypeHero} - {base.NameHero} hit for {base.PowerOfHero} damage";
        }
    }
}
