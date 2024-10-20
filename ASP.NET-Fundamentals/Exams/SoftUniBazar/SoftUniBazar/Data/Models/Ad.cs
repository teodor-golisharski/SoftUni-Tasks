namespace SoftUniBazar.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SoftUniBazar.Common.EntityValidationConstants.Ad;
    public class Ad
    {
        public Ad()
        {
            this.AdsBuyer = new HashSet<AdBuyer>();        
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(OwnerId))]
        public virtual IdentityUser Owner { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        public ICollection<AdBuyer> AdsBuyer { get; set; } 
    }
}
