using System;
using System.Collections.Generic;
using System.Linq;

namespace Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            for (int i = 0; i < n; i++)
            {
                string[] s = Console.ReadLine().Split('-');
                string creator = s[0];
                string teamName = s[1];
                bool teamExistance = teams.Select(x => x.TeamName).Contains(teamName);
                bool creatorExistance = teams.Any(x => x.Creator == creator);
                if (teamExistance == false && creatorExistance == false)
                {
                    Team currentTeam = new Team(teamName, creator);
                    teams.Add(currentTeam);
                    Console.WriteLine($"Team {currentTeam.TeamName} has been created by {currentTeam.Creator}!");
                }
                else if(teamExistance)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (creatorExistance)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
            }
            string[] input = Console.ReadLine().Split("->");
            while (input[0] != "end of assignment")
            {
                string requestingPerson = input[0];
                string requestedTeam = input[1];
                bool teamExist = teams.Any(x => x.TeamName == requestedTeam);
                bool cheating = teams.Any(x => x.Creator == requestingPerson);
                bool alreadyMemeber = teams.Any(x => x.Members.Contains(requestingPerson));
                
                if (teamExist && cheating == false && alreadyMemeber == false)
                {
                    int teamIndex = teams.FindIndex(x => x.TeamName == requestedTeam);
                    teams[teamIndex].Members.Add(requestingPerson);
                }
                else if (teamExist == false)
                {
                    Console.WriteLine($"Team {requestedTeam} does not exist!");
                }
                else if (alreadyMemeber || cheating)
                {
                    Console.WriteLine($"Member {requestingPerson} cannot join team {requestedTeam}!");
                }
                input = Console.ReadLine().Split("->");
            }
            List<Team> valid = teams.Where(x => x.Members.Count > 0).OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).ToList();
            List<Team> disband = teams.Where(x => x.Members.Count == 0).OrderBy(x => x.TeamName).ToList();
            foreach (var item in valid)
            {
                Console.WriteLine(item.TeamName);
                Console.WriteLine("- "+item.Creator);
                item.Members.Sort();
                Console.WriteLine(string.Join(Environment.NewLine, item.Members.Select(x => "-- "+ x)));
            }
            Console.WriteLine("Teams to disband:");
            foreach (var item in disband)
            {
                Console.WriteLine(item.TeamName);
            }
        }
    }
    class Team
    {
        public Team(string name, string creator)
        {
            TeamName = name;

            Creator = creator;

            Members = new List<string>();

        }
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}
