using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animals
{
    class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override double GainWeight => 0.3;

        public override IReadOnlyCollection<Type> PreferableFoods => new HashSet<Type>() {typeof(Vegetable), typeof(Meat) };

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
