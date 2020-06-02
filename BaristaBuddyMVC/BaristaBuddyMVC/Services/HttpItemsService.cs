using BaristaBuddyMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaristaBuddyMVC.Services
{
    public interface HttpItemsService
    {
        Task<Item> AddItem(Item item);
        Task DeleteItem(int id);
        Task<List<Item>> GetAllItems();
        Task<Item> GetOneItem(int id);
        Task<Item> UpdateItems(int id, Item item);
    }
}