using FastAPI.Application.Abstraction.Service.Common;
using FastAPI.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FastAPI.Sample.Controllers.Common
{
    public class CrudController<TEntity, TKey, TModel, TReadModel> : Controller where TEntity : class
    {
        private readonly ICrudApplicationService<TEntity, TModel> applicationService;

        public CrudController(ICrudApplicationService<TEntity, TModel> applicationService)
        {
            this.applicationService = applicationService;
        }

        
        [HttpGet]
        public virtual async Task<IActionResult> Get(TKey key, CancellationToken cancellationToken)
        {
            return Resolve(this.applicationService.GetById<TModel,TKey>(key));
        }


        [HttpPost]
        public virtual async Task<IActionResult> AddAsync(TModel model, CancellationToken cancellationToken)
        {
            return Resolve(await this.applicationService.AddAsync<TModel>(model, cancellationToken));
        }


        public IActionResult Resolve<TModel>(ServiceResult<TModel> result)
        {
            if (result.Errors?.Any() == true)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}