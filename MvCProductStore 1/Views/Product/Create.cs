using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvCProductStore_1.Views.Product
{
    public class Create : Controller
    {
        // GET: Create
        public ActionResult Index()
        {
            return View();
        }

        // GET: Create/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Create/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create/Create
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

        // GET: Create/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Create/Edit/5
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

        // GET: Create/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Create/Delete/5
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
