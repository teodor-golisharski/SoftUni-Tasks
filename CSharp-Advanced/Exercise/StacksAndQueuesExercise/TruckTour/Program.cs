using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<PetrolPump> pumps = new Queue<PetrolPump>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int liters = arr[0];
                int distance = arr[1];
                PetrolPump tempPump = new PetrolPump(liters, distance);
                pumps.Enqueue(tempPump);
            }
            bool flag = false;
            for (int i = 0; i < n; i++)
            {
                int fuel = 0;
                foreach (var item in pumps)
                {
                    fuel += item.Liters;
                    fuel -= item.Distance;
                    if (fuel < 0)
                    {
                        flag = false; break;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                if(flag)
                {
                    Console.WriteLine(i);
                    return;
                }
                PetrolPump temp = pumps.Dequeue();
                pumps.Enqueue(temp);
            }
        }
    }
    class PetrolPump
    {
        public PetrolPump(int liters, int distance)
        {
            this.Liters = liters;
            this.Distance = distance;
        }
        public int Liters { get; set; }
        public int Distance { get; set; }
    }
}
