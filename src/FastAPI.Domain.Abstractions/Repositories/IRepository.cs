using System.Threading;
using System.Threading.Tasks;

namespace FastAPI.Domain.Abstractions.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(params object[] key);

        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    }
}
