using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Minor.Dag39.GamesBackend.DAL.DAL;
using EasyNetQ;
using Minor.Dag39.GamesBackend.WebApi.Events;
using Minor.Dag39.GamesBackend.Entities;

namespace Minor.Dag39.GamesBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private IRepository<Room, int> _repo;
        private IEventBus _bus;

        public RoomController(IRepository<Room, int> repo, IEventBus bus)
        {
            _repo = repo;
            _bus = bus;
        }

        // POST api/values
        [HttpPost]        
        [SwaggerOperation("Post")]
        [ProducesResponseType(typeof(Room), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Room), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]Room room)
        {
            if (ModelState.IsValid)
            {
                room.Running = true;
                _repo.Insert(room);
                var message = new Message<GameCreatedEvent>(new GameCreatedEvent(room));
                _bus.Bus.Publish(_bus.Exchange, room.Name, false, message);
                return Ok(room);
            }
            return BadRequest(room);
        }

        // PUT api/values/5
        [HttpPut]
        [SwaggerOperation("Update")]
        [ProducesResponseType(typeof(Room), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Room), (int)HttpStatusCode.BadRequest)]
        public IActionResult Put([FromBody]Room room)
        {
            if (ModelState.IsValid)
            {

                room.Winner = room.Players[new Random().Next(room.Players.Count - 1)];
                room.Running = false;                
                _repo.Update(room);
                _bus.Bus.Publish(_bus.Exchange, 
                                    room.Name, 
                                    false, 
                                    new Message<GameEndedEvent>(new GameEndedEvent(room)));

                return Ok(room);
            }
            return BadRequest(room);
        }
        protected override void Dispose(bool disposing)
        {
            _repo.Dispose();
            _bus.Dispose();
            base.Dispose(disposing);
        }
    }
}
