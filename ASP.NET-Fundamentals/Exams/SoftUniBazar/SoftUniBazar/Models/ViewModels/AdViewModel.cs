namespace SoftUniBazar.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static SoftUniBazar.Common.EntityValidationConstants.Ad;
    public class AdViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
