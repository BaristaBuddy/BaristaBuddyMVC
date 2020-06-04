using System.Text.Json.Serialization;

namespace BaristaBuddyMVC.Models
{
    public class ItemModifier
    {
        [JsonPropertyName("modifierId")]
        public int ModifierId { get; set; }

        [JsonPropertyName("modifierName")]
        public string ModifierName { get; set; }

        [JsonPropertyName("additionalCost")]
        public decimal AdditionalCost { get; set; }
    }
}