using BaristaBuddyMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Services
{
    public interface IModifierService
    {
        public Task<List<StoreModifier>> GetAllStoreModifiers(int storeId);
        public Task<StoreModifier> GetOneStoreModifier(int id, int storeId);
        public Task<StoreModifier> AddStoreModifier(StoreModifier modifier, int storeId);
        public Task<StoreModifier> UpdateStoreModifier(int id, StoreModifier modifier, int storeId);
        public Task DeleteStoreModifier(int id, int storeid);

    }
}