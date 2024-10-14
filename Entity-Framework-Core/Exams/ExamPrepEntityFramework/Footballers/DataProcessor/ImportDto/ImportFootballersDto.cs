using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootballersDto
    {
        [StringLength(40, MinimumLength = 2)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; } = null!;

        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; } = null!;

        [XmlElement("BestSkillType")]
        [Range(0, 4)]
        public int BestSkillType { get; set; }

        [XmlElement("PositionType")]
        [Range(0, 3)]
        public int PositionType { get; set; }

    }
}
