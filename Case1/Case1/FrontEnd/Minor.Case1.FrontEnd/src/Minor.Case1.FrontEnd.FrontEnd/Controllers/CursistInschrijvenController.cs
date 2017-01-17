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
    public class CursistInschrijvenController : Controller
    {
        private ICursusInstantieService agent;
        public CursistInschrijvenController()
        {
            agent = new CursusInstantieService();
            agent.BaseUri = new Uri("http://localhost:11380/");
        }
        // GET: CursusInstantie
        public ActionResult Index(int id)
        {
            return View(new Inschrijving()
            {
                CursusInstantieId = id
            });
        }

        // POST: CursistInschrijven/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inschrijving inschrijving)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    agent.PostInschrijving(inschrijving);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", inschrijving);
            }
            catch
            {
                return View();
            }
        } 
    }
}