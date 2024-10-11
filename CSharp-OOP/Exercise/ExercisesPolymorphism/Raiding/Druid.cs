using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
        }

        public override int Power { get{ return 80; } }
    }
}
