using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [MaxLength(ValidationConstants.ResourceNameMaxLength)]
        public string Name { get; set; } = null!;

        public string Url { get; set; } = null!;

        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }

        public virtual Course? Course { get; set; }
    }
}
