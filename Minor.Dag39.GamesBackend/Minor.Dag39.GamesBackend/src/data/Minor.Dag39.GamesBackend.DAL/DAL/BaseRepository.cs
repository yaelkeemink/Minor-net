﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Minor.Dag39.GamesBackend.DAL.DAL
{
     public abstract class BaseRepository<Entity, Key, Context>
    : IRepository<Entity, Key>,
        IDisposable
        where Context : DbContext
        where Entity : class
    {
        protected Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }
        protected abstract DbSet<Entity> GetDbSet();
        protected abstract Key GetKeyFrom(Entity item);

        public virtual IEnumerable<Entity> FindBy(Expression<Func<Entity, bool>> filter)
        {
            return GetDbSet().Where(filter);
        }

        public virtual Entity Find(Key id)
        {
            return GetDbSet().Single(a => GetKeyFrom(a).Equals(id));
        }

        public virtual IEnumerable<Entity> FindAll()
        {
            return GetDbSet();
        }

        public virtual int Insert(Entity item)
        {
            _context.Add(item);
            return _context.SaveChanges();
        }

        public virtual int Update(Entity item)
        {
            _context.Update(item);
            return _context.SaveChanges();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}