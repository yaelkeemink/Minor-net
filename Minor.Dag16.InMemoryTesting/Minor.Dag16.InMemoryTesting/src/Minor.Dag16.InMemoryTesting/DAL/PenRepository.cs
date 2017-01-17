using Minor.Dag16.InMemoryTesting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Minor.Dag16.InMemoryTesting.DAL
{
    public class PenRepository
        : IRepository<Pen, int>,
         IDisposable
    {
        protected PenContext context;

        public PenRepository()
        {
            context = new PenContext();
        }

        public PenRepository(DbContextOptions options)
        {
            context = new PenContext(options);
        }

        public void Delete(int id)
        {
            var item = Find(id);
            context.Remove(item);
            context.SaveChanges();
        }        

        public Pen Find(int id)
        {
            return context.Pens.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Pen> FindAll()
        {
            return context.Pens;
        }

        public IEnumerable<Pen> FindBy(Expression<Func<Pen, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Pen item)
        {
            context.Add(item);
            context.SaveChanges();
        }

        public void Update(Pen item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Count()
        {
            return FindAll().Count();
        }
    }
}
