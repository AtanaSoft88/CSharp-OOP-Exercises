using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : Healer
    {
        private const int powerPaladin = 100;

        public Paladin(string nameHero, string type) 
            : base(nameHero, powerPaladin, type)
        {
        }

        public override string CastAbility()
        {
            
            return base.CastAbility();

        }
    }
}
