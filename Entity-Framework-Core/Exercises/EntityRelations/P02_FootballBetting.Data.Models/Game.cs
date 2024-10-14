using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
            this.Bets= new HashSet<Bet>();
        }

        [Key]
        public int GameId { get; set; }

        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; } = null!;


        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; } = null!;
        
        
        public byte HomeTeamGoals { get; set; }
        public byte AwayTeamGoals { get; set; }
        
        public DateTime DateTime { get; set; }

        public double HomeTeamBetRate { get; set; }
        public double AwayTeamBetRate { get; set; }
        public double DrawBetRate { get; set; }

        [MaxLength(ValidationConstants.GameResultMaxLength)]
        public string? Result { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; } = null!;

        public virtual ICollection<Bet> Bets { get; set; } = null!;
    }
}
