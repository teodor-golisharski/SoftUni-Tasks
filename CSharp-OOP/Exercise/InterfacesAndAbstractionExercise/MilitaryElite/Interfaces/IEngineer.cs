﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer
    {
        public ICollection<Repair> Repairs { get; }
    }
}
