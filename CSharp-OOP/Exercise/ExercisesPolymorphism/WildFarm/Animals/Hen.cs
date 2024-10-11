using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animals
{
    class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override double GainWeight => 0.35;

        public override IReadOnlyCollection<Type> PreferableFoods => new HashSet<Type>() { typeof(Vegetable), typeof(Meat), typeof(Seeds), typeof(Fruit) };
        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
