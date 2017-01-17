using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Minor.Case1.BackendService.WebApi.Errors;
using Minor.Case1.BackendService.DAL.DAL;
using Minor.Case1.BackendService.Entities;

namespace Minor.Case1.BackendService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CursusController : Controller
    {
        private IRepository<Cursus, string> _repo;

        public CursusController(IRepository<Cursus, string> repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        [SwaggerOperation("GetAllCursusen")]
        [ProducesResponseType(typeof(Cursus), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.FindAll());

            }
            catch (Exception)
            {
                var error = new ErrorMessage(ErrorTypes.Unknown , "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //[SwaggerOperation("GetByID")]
        //[ProducesResponseType(typeof(Cursus), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        //public IActionResult Get(string code)
        //{
        //    try
        //    {
        //        return Ok(_repo.Find(code));

        //    }
        //    catch (ArgumentNullException){
        //        var error = new ErrorMessage(ErrorTypes.NotFound, "Object not found");
        //        return NotFound(error);
        //    }
        //    catch (Exception)
        //    {
        //        var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
        //        return BadRequest(error);
        //    }
        //}

        // POST api/values
        [HttpPost]        
        [SwaggerOperation("PostCursusen")]
        [ProducesResponseType(typeof(Inschrijving), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]Cursus value)
        {
            if(!ModelState.IsValid)
            {
                var error = new ErrorMessage(ErrorTypes.BadRequest, "Modelstate invalid");
                return BadRequest(error);
            }
                    
            try
            {
                return Ok(_repo.Insert(value));
            }
            catch (DbUpdateException)
            {
                var error = new ErrorMessage(ErrorTypes.DuplicateKey, "This key already exist");
                return BadRequest(error);
            }
            catch (Exception)
            {
                var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
                return NotFound(error);
            }
        }

        //// PUT api/values/5
        //[HttpPut]
        //[SwaggerOperation("Update")]
        //[ProducesResponseType(typeof(Cursus), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        //public IActionResult Put([FromBody]Cursus value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var error = new ErrorMessage(ErrorTypes.BadRequest, "Modelstate invalid");
        //        return BadRequest(error);
        //    }

        //    try
        //    {
        //        return Ok(_repo.Update(value));

        //    }
        //    catch (DbUpdateException)
        //    {
        //        var error = new ErrorMessage(ErrorTypes.NotFound, "This object does not exist");
        //        return NotFound(error);
        //    }
        //    catch (Exception)
        //    {
        //        var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
        //        return BadRequest(error);
        //    }
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //[SwaggerOperation("Delete")]
        //[ProducesResponseType(typeof(Cursus), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        //public IActionResult Delete(string code)
        //{       
        //    try
        //    {
        //        return Ok(_repo.Delete(code));

        //    }
        //    catch (DbUpdateException)
        //    {
        //        var error = new ErrorMessage(ErrorTypes.NotFound, "Object not found");
        //        return NotFound(error);
        //    }
        //    catch (Exception)
        //    {
        //        var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
        //        return BadRequest(error);
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
