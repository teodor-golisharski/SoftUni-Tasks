using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(ExceptionMessages.NameCannotBeNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public void AddPLayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePLayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            if (player == null)
            {
                throw new Exception(string.Format(ExceptionMessages.MissingPlayer, name, Name));
            }
            players.Remove(player);
        }

        public double Rating 
        { 
            get 
            { 
                if(players.Count == 0)
                {
                    return 0;
                }
                return Math.Round(players.Average(x => x.Stats.Average)); 
            } 
        }
    }
}
