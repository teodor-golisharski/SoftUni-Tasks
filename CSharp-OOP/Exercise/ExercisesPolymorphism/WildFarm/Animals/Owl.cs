using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animals
{
    class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override double GainWeight => 0.25;

        public override IReadOnlyCollection<Type> PreferableFoods => new HashSet<Type>() { typeof(Meat) };
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
