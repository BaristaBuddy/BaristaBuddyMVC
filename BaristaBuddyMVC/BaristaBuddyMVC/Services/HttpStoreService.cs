using BaristaBuddyMVC.Models;
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
            throw new NotImplementedException();
        }

         public async Task DeleteStore(int id, Store store)
        {
            throw new NotImplementedException();
        }

        public async Task<Store> GetOneStore(int id)
        {
            var responseStream = await client.GetStreamAsync($"Stores/{id}");
            Store result = await JsonSerializer.DeserializeAsync<Store>(responseStream);
            return result;
        }

        public async Task<Store> UpdateStore(int id, Store store)
        {
            throw new NotImplementedException();
        }
    }
}
