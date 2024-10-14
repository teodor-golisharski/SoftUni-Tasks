using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.Data.Models
{
    public class TeamFootballer
    {
        [Required]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; } = null!;

        [Required]
        public int FootballerId  { get; set; }

        public virtual Footballer Footballer { get; set; } = null!;
    }
}
