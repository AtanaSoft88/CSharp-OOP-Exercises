using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGames
{
    public abstract class Warrior : IFighter
    {
        protected Warrior(int hp, int damage, int defence)
        {
            Hp = hp;
            Damage = damage;
            Defence = defence;
        }

        public int Hp { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }

        public string Attack(IFighter enemyFighter)
        {
            bool isEnemyDead = false;
            var randCriticalDmg = new Random().Next(0, 100);
            var currentDmg = (int)(0.3 * this.Damage) + randCriticalDmg;
            if (enemyFighter.Defence - currentDmg > 0)
            {
                enemyFighter.Defence -= currentDmg;
                return $"{this.GetType().Name} attacked with force: {currentDmg} and {enemyFighter.GetType().Name} defence decreased to: {enemyFighter.Defence}";
            }
            else
            {
                enemyFighter.Hp -= (currentDmg - enemyFighter.Defence);
                enemyFighter.Defence = 0;
                if (enemyFighter.Hp < 0)
                {
                    enemyFighter.Hp = 0;
                    isEnemyDead = true;
                }
                if (isEnemyDead)
                {
                    return $"{this.GetType().Name} broke {enemyFighter.GetType().Name}'s defence to 0 and hp decreased to: {enemyFighter.Hp}";
                }
                
                return $"{this.GetType().Name} hit with {currentDmg} dmg -> {enemyFighter.GetType().Name} hp decreased to: {enemyFighter.Hp}";
            }
        }
        public abstract string SpecialAttack(IFighter enemyFighter);

    }
}
