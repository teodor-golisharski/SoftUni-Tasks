using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral
    {
        public ICollection<Private> Privates { get; set; }
    }
}
