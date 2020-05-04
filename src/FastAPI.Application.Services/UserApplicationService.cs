using AutoMapper;
using FastAPI.Application.Abstraction.Service.Administration;
using FastAPI.Application.Models.Models.User;
using FastAPI.Application.Services.Common;
using FastAPI.Domain.Abstractions.Repositories;
using FastAPI.Domain.Abstractions.Services;
using FastAPI.Domain.Entities;

namespace FastAPI.Application.Services
{
    public class UserApplicationService : CrudApplicationService<User, UserModel>, IUserApplicationService
    {
        public UserApplicationService(IRepository<User> repository, IMapper mapper, IUserDomainService domainService) : base(repository, mapper, domainService)
        {

        }
    }
}
