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
    public class StoresController : Controller
    {
        private readonly IStoreService storeService;

        public StoresController(IStoreService storeService)
        {
            this.storeService = storeService;
        }

        // GET: Stores
        public async Task<ActionResult<List<Store>>> Index()
        {
            var stores = await storeService.GetAllStores();
            return View(stores.OrderBy(s => s.Name));
        }

        // GET: Stores/Details/5
        public async Task<ActionResult<Store>> Details(int id)
        {
            var store = await storeService.GetOneStore(id);
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Store>> Create(Store store)
        {
            try
            {
                await storeService.AddStore(store);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Stores/Edit/5
        public async Task<ActionResult<Store>> Edit(int id)
        {
            var store = await storeService.GetOneStore(id);
            return View(store);
        }

        // POST: Stores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Store>> Edit(int id, Store store)
        {
            try
            {
                await storeService.UpdateStore(id, store);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Stores/Delete/5
        public async Task<ActionResult<Store>> Delete(int id)
        {
            var store = await storeService.GetOneStore(id);
            return View(store);
        }

        // POST: StoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Store store)
        {
            try
            {
                await storeService.DeleteStore(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
