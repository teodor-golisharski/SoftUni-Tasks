using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();
            List<string> list = new List<string>() { "1", "2", "3" };
            stackOfStrings.AddRange(list);
            Console.WriteLine(stackOfStrings.IsEmpty());
        }
    }
}
