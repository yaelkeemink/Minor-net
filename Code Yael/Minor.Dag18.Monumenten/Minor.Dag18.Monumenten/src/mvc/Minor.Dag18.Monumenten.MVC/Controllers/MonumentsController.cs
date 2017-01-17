using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minor.Dag18.Monumenten.MVC.Agents;

using Minor.Dag18.Monumenten.MVC.Models;

namespace Minor.Dag18.Monumenten.MVC.Controllers
{
    public class MonumentsController : Controller
    {
        private IMonumentsAgent _fakeMonumentsAgent;

        public MonumentsController(IMonumentsAgent fakeMonumentsAgent)
        {
            _fakeMonumentsAgent = fakeMonumentsAgent;
        }

        public IActionResult Index()
        {
            var model = _fakeMonumentsAgent.Monuments;
            return View(model);
        }

        public IActionResult Add(Monument model)
        {
            _fakeMonumentsAgent.AddMonument(model);
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {            
            return View(_fakeMonumentsAgent.Monuments);
        }

        public IActionResult Remove(string name)
        {
            _fakeMonumentsAgent.Remove(name);
            return RedirectToAction("Index");
        }
    }
}
