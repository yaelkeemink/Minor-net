using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minor.Dag19.Monumenten.Data.DAL;
using Minor.Dag19.Monumenten.Data.Entities.Entities;
using Minor.Dag19.Monumenten.Data.DatabseContexts;

namespace Minor.Dag19.Monumenten.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MonumentsController : Controller
    {
        private IRepository<Monument, int> repo;

        public MonumentsController(IRepository<Monument, int> repo)
        {
            this.repo = repo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Monument> Get()
        {
            return repo.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Monument Get(int id)
        {
            return repo.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Monument monument)
        {
            repo.Insert(monument);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Monument monument)
        {
            repo.Update(monument);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Delete(id);
        }

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
