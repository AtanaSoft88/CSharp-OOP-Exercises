using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGames
{
    public class Archer : Warrior
    {
        public Archer() 
            : base(1000, 170, 180)
        {
        }
        public override string SpecialAttack(IFighter enemyFighter)
        {
            var increase = (int)(0.2 * enemyFighter.Defence);
            this.Defence += increase;
            if (this.Defence <= 0 || increase <= 0)
            {
                return $"Defence already reached 0.";
            }
            return $"{this.GetType().Name} has increased defence by {increase}, Total defence: {this.Defence}";
        }
    }
}
