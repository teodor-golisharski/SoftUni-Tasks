using System;
using System.Linq;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split().ToArray();
            string[] input2 = Console.ReadLine().Split().ToArray();
            foreach (string item2 in input2)
            {
                foreach (string item1 in input1)
                {
                    if (item2 == item1)
                    {
                        Console.Write(item2 + " ");
                    }
                }
            }
        }
    }
}
