using Minor.Dag19.Monumenten.Data.DAL;
using Minor.Dag19.Monumenten.Data.DatabseContexts;
using Minor.Dag19.Monumenten.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Minor.Dag19.Monumenten.WebApi.Test.Mocks
{
    public class RepositoryMock
        : MonumentRepository
    {
        private IList<Monument> _monuments;
        public int TimesCalled { get; set; }
        public RepositoryMock(DatabaseContext context) : base(context)
        {
        }

        public RepositoryMock() : base(new DatabaseContext())
        {
            _monuments = new List<Monument>();
            _monuments.Add(new Monument() { Id = 1, Location = "Utrecht", Name = "Dom" });
            _monuments.Add(new Monument() { Id = 2, Location = "Frankfurt", Name = "Eifeltoren" });
        }

        public override IEnumerable<Monument> FindBy(Expression<Func<Monument, bool>> filter)
        {
            throw new NotImplementedException();
        }

        protected override DbSet<Monument> GetDbSet()
        {
            return _context.Monuments;
        }
        public override Monument Find(int id)
        {
            return _monuments.Where(a => a.Id == id).First();
        }
        protected override int GetKeyFrom(Monument item)
        {
            return item.Id;
        }

        public int Count()
        {
            return FindAll().Count();
        }

        public override void Insert(Monument item)
        {
            TimesCalled++;
        }

        public override void Update(Monument item)
        {
            TimesCalled++;
        }
        public override void Delete(int id)
        {
            TimesCalled++;
        }
        public override IEnumerable<Monument> FindAll()
        {
            return _monuments;
        }
    }
}
