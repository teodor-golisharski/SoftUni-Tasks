using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
        }

        public override int Power { get { return 100; } }
    }
}
