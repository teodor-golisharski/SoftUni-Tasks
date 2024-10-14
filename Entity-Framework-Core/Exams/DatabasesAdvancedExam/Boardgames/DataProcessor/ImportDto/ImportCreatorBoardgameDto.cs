using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportCreatorBoardgameDto
    {
        [XmlElement("Name")]
        [MinLength(10)]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; } = null!;

        [Range(1, 10)]
        [XmlElement("Rating")]
        public double Rating { get; set; }

        [Range(2018, 2023)]
        [XmlElement("YearPublished")]
        public int YearPublished { get; set; }

        [Range(0, 4)]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("Mechanics")]
        public string Mechanics { get; set; } = null!;
    }
}
