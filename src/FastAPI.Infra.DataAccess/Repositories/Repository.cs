using FastAPI.Domain.Abstractions.Repositories;
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

    }
}
