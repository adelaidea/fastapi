using AutoMapper;
using FastAPI.Application.Models;

namespace FastAPI.Application.Abstraction.Service
{
    public interface IApplicationService<T> where T : class
    {       
        ServiceResult<TModel> GetById<TModel, TKey>(TKey key);
    }
}
