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
    }
}
