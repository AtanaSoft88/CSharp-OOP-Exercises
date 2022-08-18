using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {

        private const int nameMinLength = 1;
        private const int nameMaxLength = 15;
        private const int MaxTopping = 10;
        private const int MinTopping = 0;
        private string name;
        private Dough dough;
        private List<Topping> toppings;        
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < nameMinLength || value.Length > nameMaxLength)
                {
                    throw new ArgumentException($"Pizza name should be between {nameMinLength} and {nameMaxLength} symbols.");
                }
                this.name = value;
            }
        }

        public void AddTopping(Topping topping) 
        {
            if (this.toppings.Count < 0 || toppings.Count > MaxTopping)
            {
               
                throw new InvalidOperationException($"Number of toppings should be in range [{MinTopping}..{MaxTopping}].");
            }
            
            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            return this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories());
        }


    }
}
