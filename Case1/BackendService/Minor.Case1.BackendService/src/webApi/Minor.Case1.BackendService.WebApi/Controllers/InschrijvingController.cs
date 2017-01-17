using Microsoft.AspNetCore.Mvc;
using Minor.Case1.BackendService.DAL.DAL;
using Minor.Case1.BackendService.Entities;
using Swashbuckle.SwaggerGen.Annotations;
using System.Collections.Generic;
using System.Net;

namespace Minor.Case1.BackendService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class InschrijvingController
    : Controller
    {
        private IRepository<Inschrijving, int[]> _repo;

        public InschrijvingController(IRepository<Inschrijving, int[]> repo)
        {
            _repo = repo;
        }

        // GET api/values/5
        [HttpGet]
        [SwaggerOperation("GetInschrijvingenByCursusInstantieId")]
        [ProducesResponseType(typeof(IEnumerable<Inschrijving>), (int)HttpStatusCode.OK)]
        public IActionResult Get([FromBody]int id)
        {
            return Ok(_repo.FindBy(inschrijving => inschrijving.CursusInstantieId == id));
        }

        // POST api/values
        [HttpPost]
        [SwaggerOperation("PostInschrijving")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody]Inschrijving inschrijving)
        {
            return Ok(_repo.Insert(inschrijving));
        }

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}

