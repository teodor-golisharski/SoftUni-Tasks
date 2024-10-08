using System;
using System.Collections.Generic;

namespace HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
            int n = int.Parse(Console.ReadLine());
            string name;
            int hp, mp;
            for (int i = 0; i < n; i++)
            {
                string[] heroStats = Console.ReadLine().Split();
                name = heroStats[0];
                hp = int.Parse(heroStats[1]);
                mp = int.Parse(heroStats[2]);
                dict.Add(name, new List<int>());
                dict[name].Add(hp);
                dict[name].Add(mp);
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split(" - ");
                string mainCommand = tokens[0];
                string heroName = tokens[1];
                switch (mainCommand)
                {
                    case "CastSpell":
                        int mpNeeded = int.Parse(tokens[2]);
                        string spellName = tokens[3];
                        foreach (var item in dict)
                        {
                            if (item.Key == heroName)
                            {
                                int a = item.Value[1];
                                if (a >= mpNeeded)
                                {
                                    item.Value[1] = a - mpNeeded;
                                    Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {item.Value[1]} MP!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                                    break;
                                }
                            }
                        }
                        break;

                    case "TakeDamage":
                        int damage = int.Parse(tokens[2]);
                        string attacker = tokens[3];
                        foreach (var item in dict)
                        {
                            if (item.Key == heroName)
                            {
                                if (item.Value[0] > damage)
                                {
                                    item.Value[0] -= damage;
                                    Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {item.Value[0]} HP left!");
                                    break;
                                }
                                else
                                {
                                    item.Value[0] = 0;
                                    Console.WriteLine($"{heroName} has been killed by {attacker}!");
                                    break;
                                }
                            }
                        }
                        break;

                    case "Recharge":
                        int amount = int.Parse(tokens[2]);
                        int recovered = 0;
                        foreach (var item in dict)
                        {
                            if (item.Key == heroName)
                            {
                                if (item.Value[1] + amount > 200)
                                {
                                    recovered = 200 - item.Value[1];
                                    item.Value[1] = 200;
                                }
                                else
                                {
                                    item.Value[1] += amount;
                                    recovered = amount;
                                }
                                Console.WriteLine($"{heroName} recharged for {recovered} MP!");
                                break;
                            }
                        }
                        break;

                    case "Heal":
                        int healAmount = int.Parse(tokens[2]);
                        int recoveredHeal = 0;
                        foreach (var item in dict)
                        {
                            if (item.Key == heroName)
                            {
                                if (item.Value[0] + healAmount > 100)
                                {
                                    recoveredHeal = 100 - item.Value[0];
                                    item.Value[0] = 100;
                                }
                                else
                                {
                                    item.Value[0] += healAmount;
                                    recoveredHeal = healAmount;
                                }
                                Console.WriteLine($"{heroName} healed for {recoveredHeal} HP!");
                                break;
                            }
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            foreach (var item in dict)
            {
                if (item.Value[0] > 0)
                {
                    Console.WriteLine(item.Key);
                    Console.WriteLine($"  HP: {item.Value[0]}");
                    Console.WriteLine($"  MP: {item.Value[1]}");
                }
            }
        }
    }
}
