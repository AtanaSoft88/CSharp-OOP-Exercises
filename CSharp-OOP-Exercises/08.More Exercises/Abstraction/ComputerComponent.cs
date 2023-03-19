using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public abstract class ComputerComponent : IAssembler
    {
        // if a method or property of abstract class is also abstract ->  sub-classes must implement it!
        public abstract decimal Price { get; protected set; }
        public abstract string Name { get; protected set; }
        public abstract void RepairExpenses();

        // if a method is virtual - it can be overriden in its sub-classes, but not mendatory to do so!
        public virtual void UnexpectedExpenses() { }

        // if a method is normal ( void / any return type) - it can be called in its sub-classes after instantiation!
        public void AddVAT() 
        {
            this.Price *= 1.20M;
        }
        public void PartsOrder(int partsOrdered)
        {
            this.Price *= partsOrdered;
        }

        public decimal SumPrice(IEnumerable<ComputerComponent> components)
        {
            decimal priceSum = 0M;
            foreach (var item in components)
            {
                priceSum += item.Price;
            }
            return priceSum;
        }
    }
}
