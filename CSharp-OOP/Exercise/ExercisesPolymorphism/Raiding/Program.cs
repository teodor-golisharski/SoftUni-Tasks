using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> list = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                BaseHero hero;

                string name = Console.ReadLine();
                string type = Console.ReadLine();

                switch (type)
                {
                    case "Druid":
                        hero = new Druid(name);
                        break;

                    case "Paladin":
                        hero = new Paladin(name);
                        break;

                    case "Rogue":
                        hero = new Rogue(name);
                        break;

                    case "Warrior":
                        hero = new Warrior(name);
                        break;

                    default:
                        Console.WriteLine("Invalid hero!");
                        i--;
                        continue;
                }
                list.Add(hero);
            }
            int boss = int.Parse(Console.ReadLine());

            foreach (var item in list)
            {
                Console.WriteLine(item.CastAbility());
                boss-=item.Power;
            }

            if(boss > 0)
            {
                Console.WriteLine("Defeat...");
                
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}
