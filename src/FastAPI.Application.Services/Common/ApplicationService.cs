using AutoMapper;
using FastAPI.Application.Abstraction.Service;
using FastAPI.Application.Models;
using FastAPI.Domain.Abstractions.Repositories;
using FastAPI.Domain.Core;

namespace FastAPI.Application.Services.Common
{
    public class ApplicationService<T> : IApplicationService<T> where T : class
    {
        private readonly IRepository<T> repository;
        private readonly IMapper mapper;

        public ApplicationService(IRepository<T> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public ServiceResult<TModel> GetById<TModel,TKey>(TKey key)
        {
            var entity = this.repository.Get(key);
            return new ServiceResult<TModel>(this.mapper.Map<TModel>(entity));            
        }

    }
}
