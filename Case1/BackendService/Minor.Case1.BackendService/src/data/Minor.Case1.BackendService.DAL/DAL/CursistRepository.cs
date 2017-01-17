using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minor.Case1.BackendService.Entities;
using Minor.Case1.BackendService.DAL.DatabaseContexts;

namespace Minor.Case1.BackendService.DAL.DAL
{
    public class CursistRepository
        : BaseRepository<Cursist, int, DatabaseContext>
    {
        public CursistRepository(DatabaseContext context) : base(context)
        {
        }

        protected override DbSet<Cursist> GetDbSet()
        {
            return _context.Cursisten;
        }

        protected override int GetKeyFrom(Cursist item)
        {
            return item.Id;
        }
    }
}