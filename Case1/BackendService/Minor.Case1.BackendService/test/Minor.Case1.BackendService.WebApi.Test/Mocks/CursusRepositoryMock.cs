using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Minor.Case1.BackendService.Entities;
using Minor.Case1.BackendService.DAL.DAL;
using Minor.Case1.BackendService.DAL.DatabaseContexts;

namespace Minor.Case1.BackendService.WebApi.Test.Mocks
{
    public class InschrijvingRepositoryMock
        : InschrijvingenRepository
    {
        public int TimesCalled { get; set; }
        public InschrijvingRepositoryMock(DatabaseContext context) : base(context)
        {
        }

        public InschrijvingRepositoryMock() : base(new DatabaseContext())
        {

        }

        public override IEnumerable<Inschrijving> FindBy(Expression<Func<Inschrijving, bool>> filter)
        {
            TimesCalled++;
            return null;
        }

        protected override DbSet<Inschrijving> GetDbSet()
        {
            return _context.Inschrijvingen;
        }
        public override Inschrijving Find(int[] id)
        {
            TimesCalled++;
            return null;
        }

        public override int Insert(Inschrijving item)
        {
            TimesCalled++;
            return 0;
        }

        public override IEnumerable<Inschrijving> FindAll()
        {
            TimesCalled++;
            return null;
        }
    }
}