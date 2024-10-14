using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportCoachesDto
    {
        [StringLength(40, MinimumLength = 2)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("Nationality")]
        public string Nationality { get; set; } = null!;

        [XmlArray("Footballers")]
        public ImportFootballersDto[] Footballers { get; set; } = null!;
    }
}
