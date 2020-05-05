using FastAPI.Application.Abstraction.Service.Common;
using FastAPI.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FastAPI.Sample.Controllers.Common
{
    [ApiController]
    [Route("[controller]")]
    public class CrudController<TEntity, TKey, TAddModel, TUpdateModel, TReadModel> : Controller where TEntity : class
    {
        private readonly ICrudApplicationService<TEntity, TAddModel, TUpdateModel> applicationService;

        public CrudController(ICrudApplicationService<TEntity, TAddModel, TUpdateModel> applicationService)
        {
            this.applicationService = applicationService;
        }

        
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(TKey id, CancellationToken cancellationToken)
        {
            return Resolve(this.applicationService.GetById<TReadModel, TKey>(id));
        }


        [HttpPost("create")]
        public virtual async Task<IActionResult> AddAsync(TAddModel model, CancellationToken cancellationToken)
        {
            return Resolve(await this.applicationService.AddAsync<TReadModel>(model, cancellationToken));
        }


        [HttpPut("update")]
        public virtual async Task<IActionResult> UpdateAsync(TUpdateModel model, CancellationToken cancellationToken)
        {
            return Resolve(await this.applicationService.UpdateAsync<TReadModel>(model, cancellationToken));
        }

        [HttpDelete("delete")]
        public virtual async Task<IActionResult> DeleteAsync(TKey key, CancellationToken cancellationToken)
        {
            return Resolve(await this.applicationService.DeleteAsync(key));
        }


        protected IActionResult Resolve<TModel>(ServiceResult<TModel> result)
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

        protected IActionResult Resolve(ServiceResult result)
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