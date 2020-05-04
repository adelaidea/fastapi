using FastAPI.Domain.Abstractions.Repositories;
using FastAPI.Domain.Abstractions.Services;
using FastAPI.Domain.Core.Exceptions;
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
            string[] errors;

            if (this.IsValid(entity, out errors))
            {
                entity = await this.repository.AddAsync(entity, cancellationToken);
                return entity;
            }

            //TO DO: Implement Domain Exceptions
            throw new DomainException(errors);
        }


        public abstract bool IsValid(T entity, out string[] errors);
    }
}
