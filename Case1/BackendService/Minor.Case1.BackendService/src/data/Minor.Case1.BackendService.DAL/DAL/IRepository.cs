using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Minor.Case1.BackendService.DAL.DAL
{
    public interface IRepository<TEntity, TKey>
        : IDisposable
    {
        IEnumerable<TEntity> FindAll();

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

        TEntity Find(TKey id);

        int Insert(TEntity item);

        int InsertRange(IEnumerable<TEntity> items);

        int Count();
    }
}
