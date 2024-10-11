using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;
using System.Linq;

namespace WildFarm.Animals
{
    abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract double GainWeight { get; }
        
        public abstract IReadOnlyCollection<Type> PreferableFoods { get; } 

        public void Eat(WildFarm.Food.Food food)
        {
            if (!this.PreferableFoods.Any(dt => food.GetType().Name == dt.Name))
            {
                throw new Exception($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * this.GainWeight;
            this.FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();
    }
}
