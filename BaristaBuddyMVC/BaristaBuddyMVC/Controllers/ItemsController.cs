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
        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;

        }
        // GET: Items
        [Route("Stores/{storeId}/Items")]
        public async Task<ActionResult<List<Item>>> Index(int storeId)
        {
            var items = await itemService.GetAllItems(storeId);
            return View(items);
        }

        // GET: Items/Details/5
        [Route("Stores/{storeId}/Items")]
        public async Task<ActionResult<Item>> Details(int id, int storeId)
        {
            var item = await itemService.GetOneItem(id, storeId);
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Item>> Create(Item item, int storeId)
        {
            try
            {
                // TODO: Add insert logic here
                await itemService.AddItem(item, storeId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Edit/5
        public async Task<ActionResult<Item>> Edit(int id, int storeId)
        {
            var item = await itemService.GetOneItem(id, storeId);
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Item>> Edit(int id,Item item,int storeId)
        {
            try
            {
                // TODO: Add update logic here
                await itemService.UpdateItems(id, item, storeId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Delete/5
        public async Task<ActionResult<Item>> Delete(int id, int storeId)
        {
            var item = await itemService.GetOneItem(id, storeId);
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Item item, int storeId)
        {
            try
            {
                // TODO: Add delete logic here
                await itemService.DeleteItem(id, storeId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}