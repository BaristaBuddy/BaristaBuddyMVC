using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaristaBuddyMVC.Models
{
    public class ItemModifier
    {
        [JsonPropertyName("modifierId")]
        public int ModifierId { get; set; }

        [JsonPropertyName("modifierName")]
        [Display(Name ="Available Modifier(s)")]
        public string ModifierName { get; set; }

        [JsonPropertyName("additionalCost")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name ="Upcharge")]
        public decimal AdditionalCost { get; set; }
    }
}