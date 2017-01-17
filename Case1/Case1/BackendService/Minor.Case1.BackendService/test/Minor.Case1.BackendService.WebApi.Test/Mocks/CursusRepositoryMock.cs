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
    public class CursusRepositoryMock
        : CursusRepository
    {
        public int TimesCalled { get; set; }
        public CursusRepositoryMock(DatabaseContext context) : base(context)
        {
        }

        public CursusRepositoryMock() : base(new DatabaseContext())
        {
           
        }

        public override IEnumerable<Inschrijving> FindBy(Expression<Func<Inschrijving, bool>> filter)
        {
            throw new NotImplementedException();
        }

        protected override DbSet<Inschrijving> GetDbSet()
        {
            return _context.Cursussen;
        }
        public override Inschrijving Find(string code)
        {
            TimesCalled++;
            return null;
        }
        protected override string GetKeyFrom(Inschrijving item)
        {        
            return item.Code; ;
        }

        public override int Count()
        {
            TimesCalled++;
            return TimesCalled;
        }

        public override int Insert(Inschrijving item)
        {
            TimesCalled++;
            return TimesCalled;
        }

        public override int Update(Inschrijving item)
        {
            TimesCalled++;
            return TimesCalled;
        }
        public override int Delete(string code)
        {
            TimesCalled++;
            return TimesCalled;
        }
        public override IEnumerable<Inschrijving> FindAll()
        {
            TimesCalled++;
            return null;
        }
    }
}