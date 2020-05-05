using FastAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FastAPI.Infra.DataAccess.Filter
{
    public class Filter<TEntity> : IFilter<TEntity> where TEntity : class
    {
        private Queue<Expression<Func<TEntity, bool>>> Expressions;

        public Filter()
        {
            this.Expressions = new Queue<Expression<Func<TEntity, bool>>>();
        }

        public void AddCriteria(Expression<Func<TEntity, bool>> expression)
        {
            this.Expressions.Enqueue(expression);
        }

        public IQueryable<TEntity> GetQuery(IQueryable<TEntity> query)
        {
            if (Expressions != null)
            {
                foreach (Expression<Func<TEntity, bool>> expression in Expressions)
                {
                    query = query.Where(expression);
                }
            }

            return query;
        }

    }
}
