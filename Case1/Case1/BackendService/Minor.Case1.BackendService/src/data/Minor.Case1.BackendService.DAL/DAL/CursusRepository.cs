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
    public class CursusRepository
        : BaseRepository<Cursus, string, DatabaseContext>
    {
        public CursusRepository(DatabaseContext context) : base(context)
        {
        }

        protected override DbSet<Cursus> GetDbSet()
        {
            return _context.Cursussen;
        }

        protected override string GetKeyFrom(Cursus item)
        {
            return item.Code;
        }
    }
}