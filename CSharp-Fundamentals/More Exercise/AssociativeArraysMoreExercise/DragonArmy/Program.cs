using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dragon> dragonsLog = new List<Dragon>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string type = input[0];
                string name = input[1];

                //damage
                double damage = 45;
                if (input[2] != "null" && double.Parse(input[2]) >= 0)
                {
                    damage = double.Parse(input[2]);
                }

                //health
                double health = 250;
                if (input[3] != "null" && double.Parse(input[3]) >= 0)
                {
                    health = double.Parse(input[3]);
                }

                //armor
                double armor = 10;
                if (input[4] != "null" && double.Parse(input[4]) >= 0)
                {
                    armor = double.Parse(input[4]);
                }

                Dragon dragon = new Dragon(name, type, damage, health, armor);
                Dragon existingDragon = dragonsLog.SingleOrDefault(x => x.Name == dragon.Name && x.Type == dragon.Type);
                if(existingDragon != null)
                {
                    existingDragon.Damage = dragon.Damage;
                    existingDragon.Health = dragon.Health;
                    existingDragon.Armor = dragon.Armor;
                }
                else
                {
                    dragonsLog.Add(dragon);
                }
            }
            var grouped = dragonsLog.GroupBy(x => x.Type);
            foreach (var item in grouped)
            {
                Console.WriteLine($"{item.Key}::({item.Average(x => x.Damage):f2}/{item.Average(x => x.Health):f2}/{item.Average(x => x.Armor):f2})");
                foreach (var dragon in item.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }
    class Dragon
    {
        public Dragon(string name, string type, double damage, double health, double armor)
        {
            Name = name;
            Type = type;
            Damage = damage;
            Health = health;
            Armor = armor;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public double Damage { get; set; }
        public double Health { get; set; }
        public double Armor { get; set; }
    }
}
