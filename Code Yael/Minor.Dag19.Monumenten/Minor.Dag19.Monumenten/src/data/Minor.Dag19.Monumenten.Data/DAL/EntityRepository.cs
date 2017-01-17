using Minor.Dag19.Monumenten.Data.DatabseContexts;
using Minor.Dag19.Monumenten.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Minor.Dag19.Monumenten.Data.DAL
{
    public class EntityRepository
        : BaseRepository<Entity, int, DatabaseContext>
    {
        public EntityRepository(DatabaseContext context) : base(context)
        {
        }

        protected override DbSet<Entity> GetDbSet()
        {
            return _context.Entities;
        }

        protected override int GetKeyFrom(Entity item)
        {
            return item.Id;
        }        
    }
}
