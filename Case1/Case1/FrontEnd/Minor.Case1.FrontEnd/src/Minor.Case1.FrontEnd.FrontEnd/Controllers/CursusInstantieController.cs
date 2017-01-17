using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minor.Case1.FrontEnd.FrontEnd.Agents;
using Minor.Case1.FrontEnd.FrontEnd.Agents.Models;

namespace Minor.Case1.FrontEnd.FrontEnd.Controllers
{
    public class CursusInstantieController : Controller
    {
        private ICursusInstantieService agent;
        public CursusInstantieController()
        {
            agent = new CursusInstantieService();
            agent.BaseUri = new Uri(" http://localhost:11380/");
        }
        // GET: CursusInstantie
        public ActionResult Index(int id)
        {
            return View(id);
        }

        // GET: CursusInstantie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CursusInstantie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CursusInstantie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CursusInstantie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CursusInstantie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CursusInstantie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CursusInstantie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}