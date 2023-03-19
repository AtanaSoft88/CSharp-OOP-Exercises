using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction2
{
    public class Shark : SeaAnimal
    {
        private int maxHealth = 500;
        private int oxygenCapacity;
        private List<int> sharkMaxHealthReached = new List<int>();  
        public Shark(string name , int health, int oxygenCapacity)
        {
            this.Name = name;
            this.Health = health;
            this.OxygenCapacity = oxygenCapacity;
        }
        public override string Name { get; protected set; }
        public override int Health { get ; protected set ; }

        public override int OxygenCapacity 
        {
            get => this.oxygenCapacity;
            protected set
            {
                if (value < 0)
                {
                    value = 0; 
                }
                this.oxygenCapacity = value;
            }
        }
        public override int MaxHealth {
            get => maxHealth;
            protected set { }
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
            sharkMaxHealthReached.Add(this.Health);
        }

        public override void GetSick()
        {
            if (this.Health - 50 <= 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= 50;
            }
            if (this.Health == 0)
            {
                sharkMaxHealthReached.Add(this.Health);
                base.isAlive = false;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\r\n--> Also maximum health reached was: {this.sharkMaxHealthReached.OrderByDescending(x=>x).First()}";
        }
    }
}
