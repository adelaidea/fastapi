using AutoMapper;
using FastAPI.Application.Models;
using FastAPI.Domain.Core;

namespace FastAPI.Application.Abstraction.Service
{
    public interface IApplicationService<T> where T : class
    {
        IMapper mapper;
        ServiceResult<TModel> GetById<TModel, TKey>(TKey key);
    }
}
