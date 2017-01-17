using Minor.Dag39.GamesBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag39.GamesBackend.WebApi.Events
{
    public class GameCreatedEvent
    {
        public GameCreatedEvent(Room room)
        {
            Room = room;
        }
        public Room Room { get; set; }
    }
}
