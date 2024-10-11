using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animals
{
    class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        public override double GainWeight => 1;

        public override IReadOnlyCollection<Type> PreferableFoods => new HashSet<Type>() { typeof(Meat) };
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
