using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        private string name;
        private readonly Dough dough;
        private readonly List<Topping> toppings;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public int ToppingsCount
        {
            get
            {
                return toppings.Count;
            }
        }
        public double TotalCalories { get { return TotalCalc(); } }

        private double TotalCalc()
        {
            double total = dough.TotalCalories;
            foreach (var item in toppings)
            {
                total += item.TotalCalories;
            }
            return total;
        }
        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
            if (this.toppings.Count > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
        }
    }
}
