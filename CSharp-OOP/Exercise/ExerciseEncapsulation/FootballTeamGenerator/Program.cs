using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split(';');
                string mainCommand = tokens[0];
                string teamName = tokens[1];

                try
                {
                    switch (mainCommand)
                    {
                        case "Team":
                            Team team = new Team(teamName);
                            teams.Add(team);
                            break;

                        case "Add":
                            Team joiningTeam = teams.FirstOrDefault(x => x.Name == teamName);

                            if (joiningTeam == null)
                            {
                                throw new Exception(string.Format(ExceptionMessages.MissingTeam, teamName));
                            }

                            string playerName = tokens[2];
                            int endurance = int.Parse(tokens[3]);
                            int sprint = int.Parse(tokens[4]);
                            int dribble = int.Parse(tokens[5]);
                            int passing = int.Parse(tokens[6]);
                            int shooting = int.Parse(tokens[7]);

                            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);

                            Player player = new Player(playerName, stats);

                            joiningTeam.AddPLayer(player);
                            break;

                        case "Remove":
                            Team removingTeam = teams.FirstOrDefault(x => x.Name == teamName);

                            if (removingTeam == null)
                            {
                                throw new Exception(string.Format(ExceptionMessages.MissingTeam, teamName));
                            }

                            string removedPlayerName = tokens[2];
                            
                            removingTeam.RemovePLayer(removedPlayerName);

                            break;

                        case "Rating":
                            Team teamToRate = teams.FirstOrDefault(x => x.Name == teamName);

                            if (teamToRate == null)
                            {
                                throw new Exception(string.Format(ExceptionMessages.MissingTeam, teamName));
                            }
                            else
                            {
                                Console.WriteLine($"{teamToRate.Name} - {teamToRate.Rating}");
                            }
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine();
            }
        }
    }
}
