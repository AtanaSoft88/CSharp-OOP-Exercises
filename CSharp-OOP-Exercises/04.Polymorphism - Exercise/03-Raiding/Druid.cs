using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : Healer
    {
        private const int powerDruid = 80;

        public Druid(string nameHero,string type)
            : base(nameHero, powerDruid, type)
        {
        }

        public override string CastAbility()
        {

            return base.CastAbility();
            
        }
    }
}
