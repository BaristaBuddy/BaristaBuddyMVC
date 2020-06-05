using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Models
{
    public class Store
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [Display(Name = "Street Address")]
        [JsonPropertyName("streetAddress")]
        public string StreetAddress { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("zip")]
        public string Zip { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("websiteUrl")]
        [Display(Name = "Website")]
        public string WebsiteUrl { get; set; }
        [JsonPropertyName("storeImageUrl")]
        [Display(Name="Image URL")]
        public string StoreImageUrl { get; set; }
    }
}
