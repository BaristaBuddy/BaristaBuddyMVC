using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaristaBuddyMVC.Models;
using BaristaBuddyMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaBuddyMVC.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemService itemService;
        private readonly IModifierService modifierService;
        
        public ItemsController(IItemService itemService,IModifierService modifierService)
        {
            this.itemService = itemService;
            this.modifierService = modifierService;


        }
        // GET: Items
        [Route("Stores/{storeId}/Items")]
        public async Task<ActionResult<List<Item>>> Index(int storeId)
        {
            var items = await itemService.GetAllItems(storeId);
            return View(items);
        }

        // GET: Items/Details/5
        [Route("Stores/{storeId}/Items/Details/{id}")]
        public async Task<ActionResult<Item>> Details(int id, int storeId)
        {
            var item = await itemService.GetOneItem(id, storeId);
            return View(item);
        }

        // GET: Items/Create
        [Route("Stores/{storeId}/Items/Create")]
        public async Task<ActionResult> Create(int storeId)
        {
            var storeModifiers = await modifierService.GetAllStoreModifiers(storeId);
            var model = new EditItemViewModel  
            {
                ItemModifiers = storeModifiers
                
                        .Select(sm => new EditItemModifier
                        {
                            Id = sm.Id,
                           Name = sm.Name,
                        })
                        .ToList(),
            };
            return View(model);
        }

        // POST: Items/Create
        [Route("Stores/{storeId}/Items/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Item>> Create(EditItemViewModel itemModel, int storeId)
        {
            try
            {
                var item = new Item
                {
                    Name = itemModel.Name,
                    Ingredients = itemModel.Ingredients,
                    ItemImageUrl = itemModel.ItemImageUrl,
                    Price = itemModel.Price,
                    StoreId = storeId,
                    ItemModifiers = itemModel.ItemModifiers
                        .Where(modifier => modifier.Selected)
                        .Select(modifier => new ItemModifier
                        {
                            ModifierId = modifier.Id,
                            AdditionalCost = modifier.AdditionalCost ?? 0
                        })
                        .ToList()
                };
                await itemService.AddItem(item, storeId);

                return RedirectToAction(nameof(Index), new { storeId });
            }
            catch
            {
                return View(itemModel);
            }
        }

        // GET: Items/Edit/5
        [Route("Stores/{storeId}/Items/{id}/Edit")]
        public async Task<ActionResult<Item>> Edit(int id, int storeId)
        {
            var item = await itemService.GetOneItem(id, storeId);
            return View(item);
        }

        // POST: Items/Edit/5
        [Route("Stores/{storeId}/Items/{id}/Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Item>> Edit(int id,Item item,int storeId)
        {
            try
            {
                await itemService.UpdateItems(id, item, storeId);
                return RedirectToAction(nameof(Index), new { storeId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Delete/5
        [Route("Stores/{storeId}/Items/{id}/Delete/Success")]
        public async Task<ActionResult<Item>> Delete(int id, int storeId)
        {
            var item = await itemService.GetOneItem(id, storeId);
            return View(item);
        }

        // POST: Items/Delete/5
        [Route("Stores/{storeId}/Items/{id}/Delete/Success")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Item item, int storeId)
        {
            try
            {
                await itemService.DeleteItem(id, storeId);
                return RedirectToAction(nameof(Index), new { storeId });
            }
            catch
            {
                return View();
            }
        }
    }
}