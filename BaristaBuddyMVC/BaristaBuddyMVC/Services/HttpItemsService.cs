using BaristaBuddyMVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System;

namespace BaristaBuddyMVC.Services
{
    public class HttpItemsService : IItemService
    {
        private readonly HttpClient client;
        public HttpItemsService(HttpClient client)
        {
            this.client = client;

        }

        public async Task<Item> AddItem(Item item)
        {
            using(var content = new StringContent(JsonSerializer.Serialize(item),
                System.Text.Encoding.UTF8, "application/Json"))
            {
                var response = await client.PostAsync("Stores", content);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var responseStream = response.Content.ReadAsStreamAsync().Result;

                    Item result = await JsonSerializer.DeserializeAsync<Item>(responseStream);

                    return result;

                }

                throw new Exception($"failed to post data: ({response.StatusCode})");

            }
        }

     

        public async Task DeleteItem(int id)
        {
            var response = await client.DeleteAsync($"Stores/Items/{id}");
            response.EnsureSuccessStatusCode();
        }

             public async Task<List<Item>> GetAllItems()
        {
            var responseStream = await client.GetStreamAsync("Stores/Items");
            List<Item> result = await JsonSerializer.DeserializeAsync<List<Item>>(responseStream);
            return result;
        }

            public async Task<Item> GetOneItem(int id)
        {
            var responseStream = await client.GetStreamAsync($"stores/Items/{id}");
            Item result = await JsonSerializer.DeserializeAsync<Item>(responseStream);
            return result;
        }

             public async Task<Item> UpdateItems(int id, Item item)
        {
            using (var content = new StringContent(JsonSerializer.Serialize(item), System.Text.Encoding.UTF8, "Application/Json"))
            {
                var response = await client.PutAsync($"items/{id}", content);
                if(response.StatusCode  == System.Net.HttpStatusCode.NoContent)
                {
                    return item;
                }

                var errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"failed to post data: ({ response.StatusCode})");
            }
        }
    }
}