using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
        }
        public override int Power { get { return 100; } }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
