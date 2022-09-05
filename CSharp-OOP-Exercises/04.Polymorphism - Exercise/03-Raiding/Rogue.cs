using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : DamageDealer
    {
        private const int powerRogue = 80;

        public Rogue(string nameHero,string type)
            : base(nameHero, powerRogue, type)
        {
        }

        public override string CastAbility()
        {

            return base.CastAbility();

        }
    }
}
