using BaristaBuddyMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Services
{
    public interface IModifierService
    {
        public Task<List<StoreModifier>> GetAllStoreModifiers();
        public Task<StoreModifier> GetOneStoreModifier(int id);
    }
}