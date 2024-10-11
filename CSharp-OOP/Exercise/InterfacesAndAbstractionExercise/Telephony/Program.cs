using System;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            ICallable calling = null;
            foreach (var item in numbers)
            {
                if(item.Length == 7)
                {
                    calling = new StationaryPhone();
                    Console.WriteLine(calling.Calling(item));
                }
                else if(item.Length == 10)
                {
                    calling = new Smartphone();
                    Console.WriteLine(calling.Calling(item));
                }
                else
                {
                    Console.WriteLine(Validator.InvalidNumber);
                }
            }

            string[] urls = Console.ReadLine().Split();
            IBrowsable browsing = null;
            foreach (var item in urls)
            {
                browsing = new Smartphone();
                Console.WriteLine(browsing.Browsing(item));
            }

        }
    }
}
