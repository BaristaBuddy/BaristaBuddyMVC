using BaristaBuddyMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Services
{
    internal interface IStoreService
    {
        Task<List<Store>> GetAllStores();
    }
}