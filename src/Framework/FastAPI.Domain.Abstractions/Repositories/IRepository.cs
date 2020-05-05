using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FastAPI.Domain.Abstractions.Repositories
{
    public interface IRepository<T> 
    {
        T Get(params object[] key);
        IFilter<T> CreateFilter();
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<IList<T>> ListAsync(IFilter<T> filter, CancellationToken cancellationToken);
        Task DeleteAsync(params object[] id);
        bool Any(IFilter<T> filter);
    }
}
