using System.Text.Json.Serialization;

namespace ParcelLocker.Models
{
    public class AddParcelDTO
    {
        [JsonPropertyName("WeightGrams")]
        public int WeightGrams { get; set; }
        public Address Destination { get; set; }
    }

}