using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Minor.Dag39.GamesBackend.DAL.DAL
{
    public interface IRepository<TEntity, TKey> 
        : IDisposable
    {
    IEnumerable<TEntity> FindAll();

    IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

    TEntity Find(TKey id);

    int Insert(TEntity item);

    int Update(TEntity item);
    }
}
