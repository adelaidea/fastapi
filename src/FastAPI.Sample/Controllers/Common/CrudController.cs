using FastAPI.Application.Abstraction.Service;
using FastAPI.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FastAPI.Sample.Controllers.Common
{
    public class CrudController<TEntity, TKey, TModel, TReadModel> : Controller where TEntity : class
    {
        private readonly IApplicationService<TEntity> applicationService;

        public CrudController(IApplicationService<TEntity> applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get(TKey key, CancellationToken cancellationToken)
        {
            return Ok(this.applicationService.GetById<TModel,TKey>(key));
        }
    }
}