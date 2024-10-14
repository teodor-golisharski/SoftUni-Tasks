using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Coach
    {
        public Coach()
        {
            this.Footballers= new HashSet<Footballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        public string Nationality { get; set; } = null!;

        public virtual ICollection<Footballer> Footballers { get; set; }
    }
}
