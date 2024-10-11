using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animals
{
    class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        public override double GainWeight => 0.4;

        public override IReadOnlyCollection<Type> PreferableFoods => new HashSet<Type>() { typeof(Meat) };
        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
