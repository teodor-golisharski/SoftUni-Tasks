using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : IBrowsable, ICallable
    {

        public string Browsing(string url)
        {
            if (Validator.IsUrlIsValid(url))
            {
                return $"Browsing: {url}!";
            }
            return Validator.InvalidUrl;

        }

        public string Calling(string number)
        {
            if (Validator.IsNumberIsValid(number))
            {
                return $"Calling... {number}";
            }

            return Validator.InvalidNumber;
        }
    }
}
