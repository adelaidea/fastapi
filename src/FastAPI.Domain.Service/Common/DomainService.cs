using FastAPI.Domain.Abstractions.Repositories;
using FastAPI.Domain.Abstractions.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FastAPI.Domain.Services
{
    public abstract class DomainService<T> : IDomainService<T> where T : class
    {
        private readonly IRepository<T> repository;

        public DomainService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            if (this.IsValid(entity))
            {
                entity = await this.repository.AddAsync(entity, cancellationToken);
            }

            //TO DO: Implement Domain Exceptions
            throw new Exception("Invalid Data");
        }


        public abstract bool IsValid(T entity);
    }
}
