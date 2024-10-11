using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ICallable
    {
        public abstract string Calling(string number);
    }
}
