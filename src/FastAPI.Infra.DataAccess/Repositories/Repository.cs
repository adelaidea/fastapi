using FastAPI.Domain.Abstractions.Repositories;
using FastAPI.Infra.DataAccess.Filter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FastAPI.Infra.DataAccess.Repositories
{
    /// <summary>
    /// Generic Repository Implementation
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly FastAPIContext dbCobtext;

        public Repository(FastAPIContext context)
        {
            this.dbCobtext = context;
        }


        public IFilter<T> CreateFilter()
        {
            return new Filter<T>();
        }


        public T Get(params object[] key)
        {
            return this.dbCobtext.Set<T>().Find(key);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await this.dbCobtext.Set<T>().AddAsync(entity, cancellationToken);
            await this.dbCobtext.SaveChangesAsync(cancellationToken);
            return entity;
        }


        public async Task<IList<T>> ListAsync(IFilter<T> filter, CancellationToken cancellationToken)
        {
            IQueryable<T> query = this.dbCobtext.Set<T>();
            query = filter.GetQuery(query);
            return await query.ToListAsync(cancellationToken);
        }

        public bool Any(IFilter<T> filter)
        {
            IQueryable<T> query = this.dbCobtext.Set<T>();
            query = filter.GetQuery(query);
            return query.Any();
        }
    }
}
