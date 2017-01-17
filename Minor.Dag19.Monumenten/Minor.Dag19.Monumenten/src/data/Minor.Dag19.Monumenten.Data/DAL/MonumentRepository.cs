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
    public class MonumentRepository
        : BaseRepository<Monument, int, DatabaseContext>,
        IDisposable
    {
        public MonumentRepository(DatabaseContext context) : base(context)
        {
        }

        public override IEnumerable<Monument> FindBy(Expression<Func<Monument, bool>> filter)
        {
            throw new NotImplementedException();
        }

        protected override DbSet<Monument> GetDbSet()
        {
            return _context.Monuments;
        }

        protected override int GetKeyFrom(Monument item)
        {
            return item.Id;
        }
    }
}
