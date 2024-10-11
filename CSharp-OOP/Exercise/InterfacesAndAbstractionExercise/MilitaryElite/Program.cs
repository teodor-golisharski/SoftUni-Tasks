using MilitaryElite.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            var privates = new Dictionary<string, Private>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];
                string id = tokens[1];
                string firstName = tokens[2];
                string lastName = tokens[3];

                Corps corps;

                switch (type)
                {
                    case "Private":
                        var @private = new Private(id, firstName, lastName, decimal.Parse(tokens[4]));
                        privates.Add(id, @private);
                        Console.WriteLine(@private.ToString());
                        break;

                    case "LieutenantGeneral":
                        var lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, decimal.Parse(tokens[4]));

                        if (tokens.Length >= 5)
                        {
                            for (int i = 5; i < tokens.Length; i++)
                            {
                                string privateId = tokens[i];
                                @private = privates[privateId];

                                lieutenantGeneral.Privates.Add(@private);
                            }
                        }
                        Console.WriteLine(lieutenantGeneral);
                        break;

                    case "Engineer":
                        if (Enum.TryParse(tokens[5], out corps))
                        {
                            Engineer engineer = new Engineer(id, firstName, lastName, decimal.Parse(tokens[4]), corps);
                            if (tokens.Length >= 6)
                            {
                                for (int i = 6; i < tokens.Length; i += 2)
                                {
                                    var repairPartName = tokens[i];
                                    var repairHours = int.Parse(tokens[i + 1]);

                                    var repair = new Repair(repairPartName, repairHours);
                                    engineer.Repairs.Add(repair);
                                }
                            }
                            Console.WriteLine(engineer.ToString());
                        }
                        break;

                    case "Commando":
                        if (Enum.TryParse(tokens[5], out corps))
                        {
                            var commando = new Commando(id, firstName, lastName, decimal.Parse(tokens[4]), corps);
                            
                            if(tokens.Length >= 6)
                            {
                                for (int i = 6; i < tokens.Length; i+=2)
                                {
                                    if (Enum.TryParse(tokens[i+1], out MissionState missionState))
                                    {
                                        var missionName = tokens[i];
                                        var mission = new Mission(missionName, missionState);
                                        commando.Missions.Add(mission);
                                    }
                                }
                            }
                            Console.WriteLine(commando.ToString());
                        }
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(tokens[4]);

                        var spy = new Spy(id, firstName, lastName, codeNumber);
                        Console.WriteLine(spy);
                        break;

                    default:
                        throw new ArgumentException("Invalid Type of Soldier!");
                        
                }
            }
        }
    }

}
