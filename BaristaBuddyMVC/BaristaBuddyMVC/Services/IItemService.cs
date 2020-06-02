using BaristaBuddyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetAllItems();
        Task<Item> GetOneItem(int id);
        Task<Item> AddItem(Item item);
        Task<Item> UpdateItems(int id, Item item);
        Task DeleteItem(int id);

    }
}
