using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : DamageDealer
    {
        private const int powerWarrior = 100;

        public Warrior(string nameHero,string type)
            : base(nameHero, powerWarrior, type)
        {
        }

        public override string CastAbility()
        {
            return base.CastAbility();

        }
    }
}
