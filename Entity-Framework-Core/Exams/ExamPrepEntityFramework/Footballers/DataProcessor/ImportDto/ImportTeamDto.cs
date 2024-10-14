using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [RegularExpression("@\"^[A-Za-z0-9\\s\\.\\-]{3,}$\"")]
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }


        [Required]
        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }
}
