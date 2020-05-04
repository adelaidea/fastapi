using System.Threading;
using System.Threading.Tasks;

namespace FastAPI.Domain.Abstractions.Services
{
    public interface IDomainService<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);

        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
