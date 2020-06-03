using BaristaBuddyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetAllItems(int storeId);
        Task<Item> GetOneItem(int id, int storeId);
        Task<Item> AddItem(Item item, int storeId);
        Task<Item> UpdateItems(int id, Item item, int storeId);
        Task DeleteItem(int id, int storeId);

    }
}
