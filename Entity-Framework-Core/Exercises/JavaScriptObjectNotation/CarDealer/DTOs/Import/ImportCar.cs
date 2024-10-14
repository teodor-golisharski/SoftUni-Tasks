using Newtonsoft.Json;

namespace CarDealer.DTOs.Import
{
    public class ImportCar
    {

        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;

        [JsonProperty("traveledDistance")]
        public long TraveledDistance { get; set; }
        public HashSet<int> PartsId { get; set; }
    }
}
