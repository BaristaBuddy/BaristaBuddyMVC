using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Models
{
    public class EditItemViewModel
    {
        [JsonPropertyName("name")]
        public string Name
        {
            get; set;
        }
        [JsonPropertyName("ingredients")]
        public string Ingredients
        {
            get; set;
        }
        [JsonPropertyName("itemImageUrl")]
        public string ItemImageUrl
        {
            get; set;
        }
        [JsonPropertyName("price")]
        public decimal Price
        {
            get; set;
        }

        public List<EditItemModifier> ItemModifiers { get; set; }
    }

    public class EditItemModifier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Selected { get; set; }

        public decimal? AdditionalCost { get; set; }
    }
}
