using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction2
{
    public abstract class SeaAnimal
    {
        public abstract string Name { get; protected set; }
        public abstract int Health { get; protected set; }
        public abstract int MaxHealth { get; protected set; }

        public bool isAlive = true;
        public virtual int OxygenCapacity { get; protected set; }

        public abstract void Eat(int foodPoints);

        public abstract void GetSick();
        protected bool CanEat(int points) 
        {
            return (this.Health + points) < MaxHealth;
        }
        public override string ToString()
        {
            return $"# {this.Name} - current Oxygen : [{this.OxygenCapacity}] with remaining Health : [{this.Health}]";
        }
    }
}
