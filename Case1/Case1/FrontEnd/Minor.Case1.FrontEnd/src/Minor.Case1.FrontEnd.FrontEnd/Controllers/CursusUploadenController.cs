using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Minor.Case1.FrontEnd.FrontEnd.Agents;
using Minor.Case1.FrontEnd.FrontEnd.Agents.Models;
using Minor.Case1.FrontEnd.FrontEnd.ViewModels;
using Minor.Case1.FrontEnd.FrontEnd.Helpers;
using Microsoft.AspNetCore.Routing;

namespace Minor.Case1.FrontEnd.FrontEnd.Controllers
{
    public class CursusUploadenController : Controller
    {
        private ICursusInstantieService agent;
        public CursusUploadenController()
        {
            agent = new CursusInstantieService();
            agent.BaseUri = new Uri(" http://localhost:11380/");
        }

        private List<CursusInstantie> Parse(IFormFile file)
        {
            var cursusInstanties = new List<CursusInstantie>();
            if (file.Length > 0)
            {
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    while (streamReader.Peek() != -1)
                    {
                        var titelLine = streamReader.ReadLine().Split(':');
                        var cursusCodeLine = streamReader.ReadLine().Split(':');
                        var duurLine = streamReader.ReadLine().Replace(" ", "").Split(':');
                        var startdatumLine = streamReader.ReadLine().Split(':');
                        var legeLine = streamReader.ReadLine();
                        string[] startdatum = null;
                        if (startdatumLine.Count() == 2)
                        {
                            startdatum = startdatumLine[1].Replace(" ", "").Split('/');
                        }
                        if (titelLine[0] == "Titel" &&
                            cursusCodeLine[0] == "Cursuscode" &&
                            duurLine[0] == "Duur" &&
                            startdatumLine[0] == "Startdatum" &&
                            !legeLine.Any() &&
                            startdatum[0].Length <= 2 &&
                            duurLine[1].Length > 2)
                        {
                            cursusInstanties.Add(new CursusInstantie()
                            {
                                CursusId = cursusCodeLine[1],
                                StartDatum = new DateTime(int.Parse(startdatum[2]), int.Parse(startdatum[1]), int.Parse(startdatum[0])),
                                Cursus = new Cursus()
                                {
                                    Code = cursusCodeLine[1],
                                    Dagen = int.Parse(duurLine[1].ElementAt(0).ToString()),
                                    Titel = titelLine[1],
                                }
                            });
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                return cursusInstanties;
            }
            return null;
        }
        public IActionResult Index()
        {
            return View();
        }
        // GET: CursusUploaden
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            var instanties = Parse(file);
            if (instanties != null)
            {
                int aantalGeupload = (int)agent.PostCursusInstanties(instanties);
                return View(new UploadResultViewModel()
                {
                    AantalGeupload = aantalGeupload,
                    AantalDuplicaten = instanties.Count - aantalGeupload,
                });
            }
            else
            {
                return RedirectToAction("Error");
            }
        }



        public ActionResult Error()
        {     
            return View();
        }

        // GET: CursusUploaden/Details/5
        public ActionResult Details(int? weekNummer, int? jaar)
        {
            int jaartal = jaar ?? DateTime.Now.Year;
            int week = weekNummer ?? DateHelper.GetWeekNummer(DateTime.Now);
            var instanties = agent.GetCursusInstantiesVanEenBepaaldeWeek(new DateModel()
            {
                Jaar = jaartal,
                Week =week,
            });
            return View(new CursusInstantieDetailsViewModel((IEnumerable<CursusInstantie>)instanties)
            {
                Jaar = jaartal,
                WeekNummer = week,
            });            
        }

        // GET: CursusUploaden/Create
        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult WeekVerder(int? weekNummer, int? jaar)
        {
            weekNummer++;
            if (weekNummer == 54)
            {
                jaar++;
                weekNummer = 1;
            }
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "CursusUploaden", action = "Details", weekNummer = weekNummer + 1, jaar = jaar }));
        }

        public ActionResult WeekTerug(int? weekNummer, int? jaar)
        {
            weekNummer--;
            if(weekNummer == 0)
            {
                jaar --;
                weekNummer = 53;
            }
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "CursusUploaden", action = "Details", weekNummer = weekNummer, jaar = jaar }));
        }
    }
}