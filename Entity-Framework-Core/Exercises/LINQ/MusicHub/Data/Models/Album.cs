using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }


        [MaxLength(40)]
        public string Name { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public decimal Price => Songs.Sum(x => x.Price);

        public int? ProducerId { get; set; }
        
        public virtual Producer? Producer { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
