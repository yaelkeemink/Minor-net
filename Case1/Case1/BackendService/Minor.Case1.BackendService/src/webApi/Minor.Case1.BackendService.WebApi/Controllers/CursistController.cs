using Microsoft.AspNetCore.Mvc;
using Minor.Case1.BackendService.DAL.DAL;
using Minor.Case1.BackendService.Entities;
using Minor.Case1.BackendService.WebApi.Errors;
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
    public class CursistController
    : Controller
    {
        private IRepository<Cursist, int> _repo;

        public CursistController(IRepository<Cursist, int> repo)
        {
            _repo = repo;
        }          

        // POST api/values
        [HttpPost]
        [SwaggerOperation("PostCursist")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]Cursist cursist)
        {
            if (!ModelState.IsValid)
            {
                var error = new ErrorMessage(ErrorTypes.BadRequest, "Modelstate invalid");
                return BadRequest(error);
            }

            try
            {
                return Ok(_repo.Insert(cursist));
            }
            catch (Exception)
            {
                var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
                return NotFound(error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}

