using System.Threading;
using System.Threading.Tasks;

namespace FastAPI.Domain
{
    public interface IDomainService<T>
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);

        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);

        Task DeleteAsync(params object[] id);
    }
}
