﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaristaBuddyMVC.Controllers
{
    public class ModifiersController : Controller
    {
        // GET: Modifiers
        public ActionResult Index()
        {
            return View();
        }

        // GET: Modifiers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Modifiers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modifiers/Create
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

        // GET: Modifiers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Modifiers/Edit/5
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

        // GET: Modifiers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Modifiers/Delete/5
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
