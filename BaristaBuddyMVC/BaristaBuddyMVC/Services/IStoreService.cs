using BaristaBuddyMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Services
{
    public interface IStoreService
    {
        Task<List<Store>> GetAllStores();
    }
}