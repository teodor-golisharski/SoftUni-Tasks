using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportJsonSellerDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [JsonProperty("Address")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Address { get; set; } = null!;

        [JsonProperty("Country")]
        [Required]
        public string Country { get; set; } = null!;

        [JsonProperty("Website")]
        [Required]
        [RegularExpression(@"^w{3}.([\d\w-]{1,}).com")]
        public string Website { get; set; }

        [JsonProperty("Boardgames")]
        public int[] Boardgames { get; set; }

    }
}
