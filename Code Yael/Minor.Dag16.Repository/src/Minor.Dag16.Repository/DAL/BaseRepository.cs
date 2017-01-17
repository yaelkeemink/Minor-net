using Microsoft.EntityFrameworkCore;
using Minor.Dag16.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag16.Repository.DAL
{
    public abstract class BaseRepository<T, K, C> 
        : IRepository<T, K>
        where C : DbContext 
        where T : class
    {
        protected C _context;

        public BaseRepository(C context)
        {
            _context = context;
        }
        protected abstract DbSet<T> GetDbSet();
        protected abstract K GetKeyFrom(T item);
        
        public virtual T Find(K id)
        {
            return GetDbSet().Single(a => GetKeyFrom(a).Equals(id));
        }

        public virtual IEnumerable<T> FindAll()
        {
            return GetDbSet();
        }

        public abstract IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> filter);

        public virtual void Insert(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public virtual void InsertRange(IEnumerable<T> items)
        {
            _context.AddRange(items);            
            _context.SaveChanges();
        }

        public virtual void Update(T item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<T> items)
        {
            _context.UpdateRange(items);
            _context.SaveChanges();
        }

        public virtual void UpdateSave(T item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        public virtual void Delete(T item)
        {
            var oldItem = Find(GetKeyFrom(item));
            _context.Remove(oldItem);
            _context.SaveChanges();
        }

        public virtual void DeleteRange(IEnumerable<T> items)
        {
            _context.RemoveRange(items);
            _context.SaveChanges();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
