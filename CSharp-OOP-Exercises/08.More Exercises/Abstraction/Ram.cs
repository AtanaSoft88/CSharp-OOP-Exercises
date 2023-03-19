using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public class Ram : ComputerComponent
    {
        private decimal price;
        public Ram(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        
        public override string Name { get; protected set; }
        public sealed override decimal Price
        {
            get => this.price;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.price = value;
            }
        }

        public override void RepairExpenses()
        {
            this.Price -= 50;
            if (this.Price < 0)
            {
                this.Price = 0;
            }
        }

        public override void UnexpectedExpenses() // marked as virtual in parent class
        {
            var rand = new Random().Next(1, 10);
            this.Price -= rand;
        }
    }
}
