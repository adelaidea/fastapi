using FastAPI.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace FastAPI.Application.Abstraction.Service.Common
{
    public interface ICrudApplicationService<TEntity, TAddModel, TUpdateModel> : IApplicationService<TEntity> where TEntity : class
    {
        Task<ServiceResult<TModel>> AddAsync<TModel>(TAddModel model, CancellationToken cancellationToken);

        Task<ServiceResult<TModel>> UpdateAsync<TModel>(TUpdateModel model, CancellationToken cancellationToken);
    }
}
