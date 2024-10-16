using System.ComponentModel.DataAnnotations;

namespace TaskboardApp.Data.Models
{
    public class Board
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TaskboardApp.Data.DataConstants.Board.BoardMaxName)]
        public string Name { get; set; } = null!;

        public IEnumerable<Task> Tasks { get; set; } 
            = new List<Task>();
    }
}