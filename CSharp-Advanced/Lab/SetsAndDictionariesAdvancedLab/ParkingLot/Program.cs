using System;
using System.Collections.Generic;

namespace ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            string[] input = Console.ReadLine().Split(", ");
            while (input[0] != "END")
            {
                string command = input[0];
                if(command == "IN")
                {
                    set.Add(input[1]);
                }
                else if(command == "OUT")
                {
                    set.Remove(input[1]);
                }
                input = Console.ReadLine().Split(", ");
            }
            if(set.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, set));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
