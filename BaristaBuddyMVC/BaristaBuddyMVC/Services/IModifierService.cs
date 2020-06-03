using BaristaBuddyMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Controllers
{
    public interface IModifierService
    {
        public Task<List<StoreModifier>> GetAllStoreModifiers();
    }
}