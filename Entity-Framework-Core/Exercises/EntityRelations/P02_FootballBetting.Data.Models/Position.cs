﻿using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }

        [Key]
        public int PositionId { get; set; }

        [MaxLength(ValidationConstants.PositionNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Player> Players { get; set; }
    }
}
