﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Minor.Dag19.Monumenten.Data.DAL
{
    public interface IRepository<TEntity, TKey> 
        : IDisposable
    {
    IEnumerable<TEntity> FindAll();

    IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

    TEntity Find(TKey id);

    void Insert(TEntity item);

    void InsertRange(IEnumerable<TEntity> items);

    void Update(TEntity item);

    void UpdateRange(IEnumerable<TEntity> items);

    void Delete(TKey item);
    }
}
