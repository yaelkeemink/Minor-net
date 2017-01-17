using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minor.Case1.BackendService.DAL.DAL;
using Minor.Case1.BackendService.Entities;
using Minor.Case1.BackendService.WebApi.Helpers;
using Minor.Case1.BackendService.WebApi.Models;
using Swashbuckle.SwaggerGen.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Minor.Case1.BackendService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CursusInstantieController
        : Controller
    {
        private IRepository<CursusInstantie, int> _repo;

        public CursusInstantieController(IRepository<CursusInstantie, int> repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        [SwaggerOperation("GetCursusInstantiesVanEenBepaaldeWeek")]
        [ProducesResponseType(typeof(IEnumerable<CursusInstantie>), (int)HttpStatusCode.OK)]
        public IActionResult Get([FromBody]DateModel model)
        {

            DateModel bereik = DateHelper.GetWeekBereik(model.Jaar, model.Week);
            return Ok(_repo.FindBy(a => a.StartDatum >= bereik.StartDatum && a.StartDatum <= bereik.EindDatum));
        }

        // POST api/values
        [HttpPost]
        [SwaggerOperation("PostCursusInstanties")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody]IEnumerable<CursusInstantie> values)
        {
            return Ok(_repo.InsertRange(values));
        }

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }

    }
}
