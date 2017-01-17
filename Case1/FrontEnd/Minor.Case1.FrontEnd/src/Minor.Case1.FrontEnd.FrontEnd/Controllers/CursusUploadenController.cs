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
        private ICursusInstantieService _agent;
        public CursusUploadenController()
        {
            _agent = new CursusInstantieService();
            _agent.BaseUri = new Uri(" http://localhost:11380/");
        }

        [Route("/CAS_YK/CASsite/CursusUploaden/Index")]
        public IActionResult Index()
        {
            return View();
        }
        // GET: CursusUploaden
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            var parserModel = FileParser.Parse(file);
            if (!parserModel.ErrorMesage.Any())
            {
                int aantalGeupload = (int)_agent.PostCursusInstanties(parserModel.Instanties);
                return View(new UploadResultViewModel()
                {
                    AantalGeupload = aantalGeupload,
                    AantalDuplicaten = parserModel.Instanties.Count - aantalGeupload,
                });
            }
            else
            {
                return RedirectToAction("Error", parserModel);
            }
        }

        [Route("/CAS_YK/CASsite/CursusUploaden/Error")]
        public ActionResult Error(FileParserViewModel model)
        {
            return View(model);
        } 
    }
}