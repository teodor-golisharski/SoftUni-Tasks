using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> list = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            IBuyer buyer = null;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    buyer = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                }
                else if (input.Length == 3)
                {
                    buyer = new Rebel(input[0], int.Parse(input[1]), input[2]);
                }
                if (!list.Any(x => x.Name == buyer.Name))
                {
                    list.Add(buyer);
                }
            }

            string command = Console.ReadLine();
            
            while(command != "End")
            {
                if(list.Any(x => x.Name == command))
                {
                    list.Find(x => x.Name == command).BuyFood();
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(list.Sum(x => x.Food));
        }
    }
}
