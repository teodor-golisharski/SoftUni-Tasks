﻿using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PlayerNameMaxLength)]
        public string Name { get; set; } = null!;

        public int SquadNumber { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; } = null!;

        public int PositionId { get; set; }

        public virtual Position Position { get; set; } = null!;

        public bool IsInjured { get; set; }
        
        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
    }
}
