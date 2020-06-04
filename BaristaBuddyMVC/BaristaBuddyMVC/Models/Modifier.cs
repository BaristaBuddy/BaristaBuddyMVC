using System.Text.Json.Serialization;

namespace BaristaBuddyMVC.Models
{
    public class StoreModifier
    {
        [JsonPropertyName("modifierId")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("storeId")]
        public int StoreId { get; set; }
    }
}
