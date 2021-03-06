﻿using FastAPI.Domain.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace FastAPI.Domain
{
    public abstract class DomainService<T> : IDomainService<T> where T : class
    {
        private readonly IRepository<T> repository;
        protected DomainService(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
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
        public virtual async Task DeleteAsync(params object[] id)
        {
            await this.repository.DeleteAsync(id);
        }
        public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            string[] errors;

            if (this.IsValid(entity, out errors))
            {
                entity = await this.repository.UpdateAsync(entity, cancellationToken);
                return entity;
            }

            //TO DO: Implement Domain Exceptions
            throw new DomainException(errors);
        }
        protected abstract bool IsValid(T entity, out string[] errors);
    }
}
