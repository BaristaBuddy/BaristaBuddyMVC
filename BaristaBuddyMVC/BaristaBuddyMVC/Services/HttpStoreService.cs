﻿using BaristaBuddyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Services
{
    public class HttpStoreService : IStoreService
    {
        private readonly HttpClient client;

        public HttpStoreService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<List<Store>> GetAllStores()
        {
            var responseStream = await client.GetStreamAsync("Stores");

            List<Store> result = await JsonSerializer.DeserializeAsync<List<Store>>(responseStream);
            return result;
        }

        public async Task<Store> AddStore(Store store)
        {
            using (var content = new StringContent(JsonSerializer.Serialize(store), System.Text.Encoding.UTF8, "application/json"))
            {
                var response = await client.PostAsync("Stores", content);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var responseStream = response.Content.ReadAsStreamAsync().Result;
                    Store result = await JsonSerializer.DeserializeAsync<Store>(responseStream);
                    return result;
                }

                throw new Exception($"Failed to POST data: ({response.StatusCode})");
            }
        }

         public async Task DeleteStore(int id)
        {
            var response = await client.DeleteAsync($"Stores/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Store> GetOneStore(int id)
        {
            var responseStream = await client.GetStreamAsync($"Stores/{id}");
            Store result = await JsonSerializer.DeserializeAsync<Store>(responseStream);
            return result;
        }

        public async Task<Store> UpdateStore(int id, Store store)
        {
            using (var content = new StringContent(JsonSerializer.Serialize(store), System.Text.Encoding.UTF8, "application/json"))
            {
                var response = await client.PutAsync($"Stores/{id}", content);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return store;
                }

                var errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to POST data: ({response.StatusCode})");
            }
        }
    }
}
