using BaristaBuddyMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Services
{
    public interface IStoreService
    {
        Task<List<Store>> GetAllStores();
        Task<Store> GetOneStore(int id);
        Task<Store> AddStore(Store store);
        Task<Store> UpdateStore(int id, Store store);
        Task DeleteStore(int id, Store store);
    }
}