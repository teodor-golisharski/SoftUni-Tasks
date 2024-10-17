using System.ComponentModel.DataAnnotations;

namespace Homies.Models.ViewModels
{
    public class AllEventViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public string Organiser { get; set; } = null!;
    }
}
