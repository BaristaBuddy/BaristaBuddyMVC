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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
