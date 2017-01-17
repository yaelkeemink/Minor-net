﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minor.Case1.BackendService.Entities;
using Minor.Case1.BackendService.DAL.DatabaseContexts;

namespace Minor.Case1.BackendService.DAL.DAL
{
    public class InschrijvingenRepository
        : BaseRepository<Inschrijving, int[], DatabaseContext>
    {
        public InschrijvingenRepository(DatabaseContext context) : base(context)
        {
        }

        protected override DbSet<Inschrijving> GetDbSet()
        {
            return _context.Inschrijvingen;
        }

        protected override int[] GetKeyFrom(Inschrijving item)
        {
            return new int[] { item.CursistId, item.CursusInstantieId };
        }

        public override IEnumerable<Inschrijving> FindBy(Expression<Func<Inschrijving, bool>> filter)
        {
            return GetDbSet().Include(instantie => instantie.Instantie).Include(inschrijving => inschrijving.Cursist).Where(filter);
        }
    }
}