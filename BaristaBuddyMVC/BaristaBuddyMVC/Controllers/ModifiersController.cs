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
    public class ModifiersController : Controller
    {
        private readonly IModifierService modifierService;

        public ModifiersController(IModifierService modifierService)
        {
            this.modifierService = modifierService;
        }

        // GET: Modifiers
        [Route("Stores/{storeId}/Modifiers")]
        public async Task<ActionResult<List<StoreModifier>>> Index(int storeId)
        {
            var storeModifiers = await modifierService.GetAllStoreModifiers(storeId);
            return View(storeModifiers.OrderBy(m => m.Name));
        }


        // GET: Modifiers/1/Details/5
        [Route("Stores/{storeId}/Modifiers/Details/{id}")]
        public async Task<ActionResult<StoreModifier>> Details(int id, int storeId)
        {
            var storeModifier = await modifierService.GetOneStoreModifier(id, storeId);
            return View(storeModifier);
        }

        // GET: Modifiers/Create
        [Route("Stores/{storeId}/Modifiers/Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modifiers/Create
        [Route("Stores/{storeId}/Modifiers/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<StoreModifier>> Create(StoreModifier modifier, int storeId)
        {
            try
            {
                // TODO: Add insert logic here
                await modifierService.AddStoreModifier(modifier, storeId);

                return RedirectToAction(nameof(Index), new { storeId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Modifiers/Edit/5
        [Route("Stores/{storeId}/Modifiers/{id}/Edit")]
        public async Task<ActionResult<StoreModifier>> Edit(int id, int storeId)
        {
            var modifier = await modifierService.GetOneStoreModifier(id, storeId);
            return View(modifier);
        }

        // POST: Modifiers/Edit/5
        [Route("Stores/{storeId}/Modifiers/{id}/Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<StoreModifier>> Edit(int id, StoreModifier modifier, int storeId)
        {
            try
            {
                await modifierService.UpdateStoreModifier(id, modifier, storeId);
                return RedirectToAction(nameof(Index), new { storeId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Modifiers/Delete/5
        [Route("Stores/{storeId}/Modifiers/{id}/Delete/Success")]
        public async Task<ActionResult<StoreModifier>> Delete(int id, int storeId)
        {
            var modifier = await modifierService.GetOneStoreModifier(id, storeId);
            return View(modifier);
        }

        // POST: Modifiers/Delete/5
        [Route("Stores/{storeId}/Modifiers/{id}/Delete/Success")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, StoreModifier modifier, int storeId)
        {
            try
            {
                await modifierService.DeleteStoreModifier(id, storeId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
