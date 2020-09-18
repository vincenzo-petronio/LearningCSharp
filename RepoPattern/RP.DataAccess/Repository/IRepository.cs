using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RP.DataAccess.Repository
{
    /// <summary>
    /// Interface generica
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IRepository<TEntity, TKey>
        where TEntity : class, new()
        // where:   generic type constraint
        // new():   makes it possible to create an instance of a type parameter
    {
        Task<IQueryable<TEntity>> Queryable();

        Task<IEnumerable<TEntity>> SelectAllAsync();
        Task<TEntity> SelectByKeyAsync(TKey entity);
        Task InsertAsync(TEntity entity);
        //Task UpdateAsync(TEntity entity);
        //Task DeleteAsync(TKey entity);
    }
}
