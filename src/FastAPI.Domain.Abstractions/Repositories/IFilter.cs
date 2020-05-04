using System;
using System.Linq;
using System.Linq.Expressions;

namespace FastAPI.Domain.Abstractions.Repositories
{
    public interface IFilter<TEntity> where TEntity : class
    {
        void AddCriteria(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> GetQuery(IQueryable<TEntity> query);
    }
}
