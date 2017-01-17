using Minor.Dag39.GamesBackend.Entities;
using System;

namespace Minor.Dag39.GamesBackend.WebApi.Events
{
    public class GameEndedEvent
    {
        public GameEndedEvent(Room room)
        {
            Room = room;
            EndTime = DateTime.UtcNow;
        }
        public DateTime EndTime { get; set; }
        public Room Room { get; set; }
    }
}
