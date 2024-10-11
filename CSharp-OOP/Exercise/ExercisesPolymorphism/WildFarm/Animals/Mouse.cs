using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animals
{
    class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        public override double GainWeight => 0.1;

        public override IReadOnlyCollection<Type> PreferableFoods => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };
        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
