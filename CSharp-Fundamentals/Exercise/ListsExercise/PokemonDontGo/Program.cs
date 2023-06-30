using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distance = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            int sum = 0;
            while (distance.Count != 0)
            {
                int n = int.Parse(input);
                int num = 0;
                if (n < 0)
                {
                    num = distance[0];
                    distance.RemoveAt(0);
                    distance.Insert(0, distance[distance.Count - 1]);
                }
                else if (n > distance.Count - 1)
                {
                    num = distance[distance.Count - 1];
                    distance.RemoveAt(distance.Count - 1);
                    distance.Insert(distance.Count, distance[0]);
                }
                else
                {
                    num = distance[n];
                    distance.RemoveAt(n);
                    
                }
                sum += num;
                for (int i = 0; i < distance.Count; i++)
                {
                    if(distance[i]<=num)
                    {
                        distance[i] += num;
                    }
                    else if(distance[i]>num)
                    {
                        distance[i] -= num;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(sum);
        }
    }
}
