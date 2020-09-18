using Microsoft.EntityFrameworkCore;
using RP.DataAccess.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RP.DataAccess.Repository
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, new()
    {
        private readonly RPContext context;
        private readonly DbSet<TEntity> dbSet;

        public Repository()
        {
        }

        public Repository(RPContext ctx)
        {
            this.context = ctx;
            this.dbSet = context.Set<TEntity>();
        }

        public Task InsertAsync(TEntity entity)
        {
            dbSet.Add(entity);
            return Task.CompletedTask;
        }

        public Task<IQueryable<TEntity>> Queryable()
        {
            return Task.FromResult(dbSet.AsQueryable());
        }

        public Task<IEnumerable<TEntity>> SelectAllAsync()
        {
            return Task.FromResult(dbSet.AsEnumerable());
        }

        public Task<TEntity> SelectByKeyAsync(TKey entity)
        {
            return Task.FromResult(dbSet.Find(entity));
        }
    }
}
