using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction2
{
    public class Octopus : SeaAnimal
    {
        private int maxHealthOctopus = 350;
        private int oxygenCapacity;
        private int additionalOxygen;
        private List<int> octopusMinHealthReached = new List<int>();

        public Octopus(string name, int health, int oxygenCapacity, int additionalOxygen)
        {
            this.Name = name;
            this.Health = health;
            this.OxygenCapacity = oxygenCapacity;
            this.AdditionalOxygen = additionalOxygen;
        }

        public override string Name { get; protected set; }
        public override int Health { get; protected set; }
        public override int MaxHealth 
        { 
            get => this.maxHealthOctopus;
            protected set { }
        }

        public override int OxygenCapacity 
        {
            get => oxygenCapacity;
            protected set 
            {
                if (value < 0)
                {
                    value = 0;
                }
                oxygenCapacity = value;
            }
        }
        public int AdditionalOxygen 
        {   
            get => this.additionalOxygen;
            private set 
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.additionalOxygen = value;
            }
        }
        public override void Eat(int foodPoints)
        {
            if (base.CanEat(foodPoints) == true)
            {
                this.Health += foodPoints;
                this.OxygenCapacity -= foodPoints;
                if (this.OxygenCapacity <= 0)
                {
                    base.isAlive = false;
                }
                if (this.Health > MaxHealth)
                {
                    this.Health = MaxHealth;
                    this.OxygenCapacity += 10;
                }
                
            }
            else
            {
                this.Health = MaxHealth;
                if (this.OxygenCapacity - foodPoints >= 0)
                {
                    this.OxygenCapacity -= foodPoints;
                }
                else
                {
                    base.isAlive = false;
                }
            }
            octopusMinHealthReached.Add(this.Health);

        }

        public override void GetSick()
        {
            if (this.Health - 70 >=0)
            {
                this.Health -= 70;
            }
            else
            {
                this.Health = 0;
            }
            this.OxygenCapacity += this.additionalOxygen;
            if (this.OxygenCapacity <=0 || this.Health == 0)
            {
                base.isAlive = false;
            }
            octopusMinHealthReached.Add(this.Health);
        }

        public override string ToString()
        {
            return $"{base.ToString()}\r\n--> Also Minimum health reached was: {this.octopusMinHealthReached.OrderBy(x => x).First()}";
        }
    }
}
