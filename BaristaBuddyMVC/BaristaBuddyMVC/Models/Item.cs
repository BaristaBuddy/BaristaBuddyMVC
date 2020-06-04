using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Models
{
    public class Item
    {
        [JsonPropertyName("itemId")] 
        public int Id
        {
            get; set;
        }
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
        [JsonPropertyName("storeId")]
        public int StoreId { get; set; }


        public List<ItemModifier> ItemModifiers { get; set; }


    }
}
