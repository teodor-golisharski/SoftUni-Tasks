using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.HomeGames = new HashSet<Game>();
            
            this.AwayGames = new HashSet<Game>();

            this.Players = new HashSet<Player>();
        }

        [Key]
        public int TeamId { get; set; }

        [MaxLength(ValidationConstants.TeamNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ValidationConstants.TeamLogoUrlMaxLength)]
        public string? LogoUrl { get; set; } 

        [MaxLength(ValidationConstants.TeamInitialsMaxLength)]
        public string Initials { get; set; } = null!;

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public virtual Color PrimaryKitColor { get; set; } = null!;

        public int SecondaryKitColorId { get; set; }

        public virtual Color SecondaryKitColor { get; set; } = null!;

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }

        public virtual Town Town { get; set; } = null!;
    
        public virtual ICollection<Game> HomeGames { get; set; }
        public virtual ICollection<Game> AwayGames { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}