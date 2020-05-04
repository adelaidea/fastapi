using AutoMapper;
using FastAPI.Application.Abstraction.Service.Common;
using FastAPI.Application.Models;
using FastAPI.Domain.Abstractions.Repositories;
using FastAPI.Domain.Abstractions.Services;
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

        public async Task<ServiceResult<TModel>> AddAsync<TModel>(TAddModel model, CancellationToken cancellationToken)
        {
            var entity = this.mapper.Map<TEntity>(model);

            using(var transaction = new TransactionScope())
            {
                entity = await this.domainService.AddAsync(entity);
                transaction.Complete();
            }

            return new ServiceResult<TModel>(this.mapper.Map<TModel>(entity));
        }
    }
}
