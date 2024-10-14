using MusicHub.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; } = null!; 
        
        //In EF <= 3.1 we use [Required] attribute
        //In EF >= 6.x everything is required and we add "?" to be nullable

        public TimeSpan Duration { get; set; }

        public DateTime CreatedOn { get; set; }

        public Genre Genre { get; set; }

        public int? AlbumId { get; set; }

        public virtual Album? Album { get; set; }

        public int WriterId { get; set; }

        public virtual Writer? Writer { get; set; }

        public decimal Price { get; set; }

        public ICollection<SongPerformer> SongPerformers { get; set; }
    }
}