using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType("User")]
    public class ImportUserDto
    {
        [XmlElement(ElementName = "firstName")]
        public string FirstName { get; set; } = null!;

        [XmlElement(ElementName = "lastName")]
        public string LastName { get; set; } = null!;

        [XmlElement(ElementName = "age")]
        public int Age { get; set; }
    }
}
