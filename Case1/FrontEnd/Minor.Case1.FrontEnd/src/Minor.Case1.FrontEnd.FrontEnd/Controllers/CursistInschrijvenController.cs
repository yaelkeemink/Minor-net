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
        private ICursusInstantieService _agent;

        public CursistInschrijvenController()
        {
            _agent = new CursusInstantieService();
            _agent.BaseUri = new Uri("http://localhost:11380/");
        }
        // GET: CursusInstantie
        [Route("/CAS_YK/CASsite/CursistInschrijven/Index")]
        public ActionResult Index(int id)
        {
            return View(new Inschrijving()
            {
                CursusInstantieId = id,
                CursistId = 0,
            });
        }

        // POST: CursistInschrijven/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/CAS_YK/CASsite/CursistInschrijven/Create")]
        public ActionResult Create(Inschrijving inschrijving)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _agent.PostInschrijving(inschrijving);
                    return RedirectToAction("Ingeschreven");
                }
                return RedirectToAction("Index", inschrijving);
            }
            catch(Exception)
            {
                return View();
            }
        }

        [Route("/CAS_YK/CASsite/CursistInschrijven/Ingeschreven")]
        public ActionResult Ingeschreven(Inschrijving inschrijving)
        {
            return View(inschrijving);
        }
    }
}