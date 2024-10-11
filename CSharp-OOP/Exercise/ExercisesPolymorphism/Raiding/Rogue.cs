using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
        }

        public override int Power { get { return 80; } }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
