using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            try
            {                
                DateModel bereik = DateHelper.GetWeekBereik(model.Jaar, model.Week);
                return Ok(_repo.FindBy(a => a.StartDatum >= bereik.StartDatum && a.StartDatum <= bereik.EindDatum));
            }
            catch (Exception)
            {
                var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetByID")]
        [ProducesResponseType(typeof(CursusInstantie), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_repo.Find(id));

            }
            catch (ArgumentNullException)
            {
                var error = new ErrorMessage(ErrorTypes.NotFound, "Object not found");
                return NotFound(error);
            }
            catch (Exception)
            {
                var error = new ErrorMessage(ErrorTypes.Unknown, "Oops, something went wrong");
                return BadRequest(error);
            }
        }

        // POST api/values
        [HttpPost]
        [SwaggerOperation("PostCursusInstanties")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]IEnumerable<CursusInstantie> values)
        {
            if (!ModelState.IsValid)
            {
                var error = new ErrorMessage(ErrorTypes.BadRequest, "Modelstate invalid");
                return BadRequest(error);
            }

            try
            {
                return Ok(_repo.InsertRange(values));
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
        //[ProducesResponseType(typeof(CursusInstantie), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.NotFound)]
        //public IActionResult Put([FromBody]CursusInstantie value)
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

        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            base.Dispose(disposing);
        }
        
    }
}
