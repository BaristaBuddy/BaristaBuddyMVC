
using BaristaBuddyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Services
{
    public class HttpModifierService : IModifierService
    {

        private readonly HttpClient client;
       
       public HttpModifierService(HttpClient client)
        {
            this.client = client;

        }

      

    
        public async Task<StoreModifier> AddStoreModifier(StoreModifier storeModifier, int storeId)
        {
            using (var content = new StringContent(JsonSerializer.Serialize(storeModifier),
                System.Text.Encoding.UTF8, "application/Json"))
            {
                var response = await client.PostAsync($"Stores/{storeId}/Modifiers", content);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var responseStream = response.Content.ReadAsStreamAsync().Result;

                    StoreModifier result = await JsonSerializer.DeserializeAsync<StoreModifier>(responseStream);

                    return result;

                }

                throw new Exception($"failed to post data: ({response.StatusCode})");

            }
        }

        public async Task DeleteStoreModifier(int id, int storeId)
        {
            var response = await client.DeleteAsync($"Stores/{storeId}/Modifiers/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<StoreModifier>> GetAllStoreModifiers(int storeId)
        {
            var responseStream = await client.GetStreamAsync($"Stores/{storeId}/Modifiers");
            List<StoreModifier> result = await JsonSerializer.DeserializeAsync<List<StoreModifier>>(responseStream);
            return result;
        }

        public async Task<StoreModifier> GetOneStoreModifier(int id, int storeId)
        {
            var responseStream = await client.GetStreamAsync($"stores/{storeId}/Modifiers/{id}");
            StoreModifier result = await JsonSerializer.DeserializeAsync<StoreModifier>(responseStream);
            return result;
        }

        public async Task<StoreModifier> UpdateStoreModifier(int id, StoreModifier storeModifier, int storeId)
        {
            using (var content = new StringContent(JsonSerializer.Serialize(storeModifier), System.Text.Encoding.UTF8, "Application/Json"))
            {
                var response = await client.PutAsync($"Stores/{storeId}/modifiers/{id}", content);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return storeModifier;
                }

                var errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"failed to post data: ({ response.StatusCode})");
            }
        }
    }
}