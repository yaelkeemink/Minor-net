using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minor.Case1.FrontEnd.FrontEnd.Agents;
using Minor.Case1.FrontEnd.FrontEnd.Agents.Models;
using Minor.Case1.FrontEnd.FrontEnd.Helpers;
using Minor.Case1.FrontEnd.FrontEnd.ViewModels;
using Microsoft.AspNetCore.Routing;

namespace Minor.Case1.FrontEnd.FrontEnd.Controllers
{
    public class CursusInstantieController : Controller
    {
        private ICursusInstantieService _agent;
        public CursusInstantieController()
        {
            _agent = new CursusInstantieService();
            _agent.BaseUri = new Uri(" http://localhost:11380/");
        }
        // GET: CursusUploaden/Details/5
        [Route("/CAS_YK/CASsite/CursusInstantie/Index")]
        public ActionResult Index(int? weekNummer, int? jaar)
        {
            int jaartal = jaar ?? DateTime.Now.Year;
            int week = weekNummer ?? DateHelper.GetWeekNummer(DateTime.Now);
            var instanties = _agent.GetCursusInstantiesVanEenBepaaldeWeek(new DateModel()
            {
                Jaar = jaartal,
                Week = week,
            });
            return View(new CursusInstantieDetailsViewModel((IEnumerable<CursusInstantie>)instanties)
            {
                Jaar = jaartal,
                WeekNummer = week,
            });
        }
        [Route("/CAS_YK/CASsite/CursusInstantie/WeekVerder")]
        public ActionResult WeekVerder(int? weekNummer, int? jaar)
        {
            weekNummer++;
            if (weekNummer >= 54)
            {
                jaar++;
                weekNummer = 1;
            }
            return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "CursusInstantie", action = "Index", weekNummer = weekNummer, jaar = jaar }));
        }

        [Route("/CAS_YK/CASsite/CursusInstantie/WeekTerug")]
        public ActionResult WeekTerug(int? weekNummer, int? jaar)
        {
            weekNummer--;
            if (weekNummer <= 0)
            {
                jaar--;
                weekNummer = 53;
            }
            return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "CursusInstantie", action = "Index", weekNummer = weekNummer, jaar = jaar }));
        }

        [Route("/CAS_YK/CASsite/CursusInstantie/Inschrijvingen")]
        public IActionResult Inschrijvingen(int id)
        {
            
            return View(new InschrijvingenViewModel()
            {
                Inschrijvingen = (IList<Inschrijving>)_agent.GetInschrijvingenByCursusInstantieId(id),
                InstantieId = id
            });
        }
    }
}