using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minor.Dag39.GamesBackend.DAL.DatabaseContexts;
using Minor.Dag39.GamesBackend.Entities;

namespace Minor.Dag39.GamesBackend.DAL.DAL
{
    public class GameRepository
        : BaseRepository<Room, int, DatabaseContext>
    {
        private DbContextOptions _options;

        public GameRepository(DatabaseContext context) : base(context)
        {
        }

        protected override DbSet<Room> GetDbSet()
        {
            return _context.Games;
        }

        protected override int GetKeyFrom(Room item)
        {
            return item.Id;
        }
    }
}