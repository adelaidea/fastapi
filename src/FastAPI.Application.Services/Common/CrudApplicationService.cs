using AutoMapper;
using FastAPI.Application.Abstraction.Service.Common;
using FastAPI.Application.Models;
using FastAPI.Domain.Abstractions.Repositories;
using FastAPI.Domain.Abstractions.Services;
using FastAPI.Domain.Core.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace FastAPI.Application.Services.Common
{
    public class CrudApplicationService<TEntity, TAddModel> : ApplicationService<TEntity>, ICrudApplicationService<TEntity, TAddModel>
        where TEntity : class
    {

        private readonly IDomainService<TEntity> domainService;
        private readonly IMapper mapper;
        public CrudApplicationService(IRepository<TEntity> repository, IMapper mapper, IDomainService<TEntity> domainService) : base(repository, mapper)
        {
            this.domainService = domainService;
            this.mapper = mapper;
        }

        public virtual async Task<ServiceResult<TModel>> AddAsync<TModel>(TAddModel model, CancellationToken cancellationToken)
        {
            var entity = this.mapper.Map<TEntity>(model);
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    entity = await this.domainService.AddAsync(entity, cancellationToken);
                    transaction.Complete();
                }
                return new ServiceResult<TModel>(this.mapper.Map<TModel>(entity));

            }
            catch (DomainException domainException)
            {
                return new ServiceResult<TModel>(domainException.Errors);
            }
            catch(Exception exception)
            {
                return new ServiceResult<TModel>(exception.Message);
            }
        }
    }
}
