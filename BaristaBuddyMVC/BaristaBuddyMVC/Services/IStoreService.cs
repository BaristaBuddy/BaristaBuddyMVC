using BaristaBuddyMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Controllers
{
    internal interface IStoreService
    {
        Task<List<Store>> GetAllStores();
    }
}