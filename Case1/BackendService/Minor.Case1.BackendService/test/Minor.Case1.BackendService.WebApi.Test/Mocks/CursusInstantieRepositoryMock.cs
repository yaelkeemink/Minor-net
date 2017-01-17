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
    public class CursusInstantieRepositoryMock
        : CursusInstantieRepository
    {
        public int TimesCalled { get; set; }
        public CursusInstantieRepositoryMock(DatabaseContext context) : base(context)
        {
        }

        public CursusInstantieRepositoryMock() : base(new DatabaseContext())
        {

        }

        public override IEnumerable<CursusInstantie> FindBy(Expression<Func<CursusInstantie, bool>> filter)
        {
            TimesCalled++;
            return null;
        }

        protected override DbSet<CursusInstantie> GetDbSet()
        {
            return _context.CursusInstanties;
        }
        public override CursusInstantie Find(int code)
        {
            TimesCalled++;
            return null;
        }
        protected override int GetKeyFrom(CursusInstantie item)
        {
            return item.Id; ;
        }

        public override int InsertRange(IEnumerable<CursusInstantie> item)
        {
            TimesCalled++;
            return TimesCalled;
        }

        public override IEnumerable<CursusInstantie> FindAll()
        {
            TimesCalled++;
            return null;
        }
    }
}