using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    abstract class BaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
        public abstract int Power { get; }
        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
