using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Calling(string number)
        {
            if (Validator.IsNumberIsValid(number))
            {
                return $"Dialing... {number}";
            }

            return Validator.InvalidNumber;
        }
    }
}
