using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskboardApp.Data.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TaskboardApp.Data.DataConstants.Task.TaskMaxTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(TaskboardApp.Data.DataConstants.Task.TaskMaxDescription)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public int BoardId { get; set; }
        public Board? Board { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;
        public virtual IdentityUser Owner { get; set; } = null!;
    }
}
