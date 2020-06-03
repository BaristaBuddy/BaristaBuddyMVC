
using BaristaBuddyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Services
{
    public class HttpModifierService : IModifierService
    {
        public Task<List<StoreModifier>> GetAllStoreModifiers()
        {
            throw new NotImplementedException();
        }

        public Task<StoreModifier> GetOneStoreModifier(int id)
        {
            throw new NotImplementedException();
        }
    }
}
