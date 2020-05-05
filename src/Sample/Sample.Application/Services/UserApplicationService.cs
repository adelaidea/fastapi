using AutoMapper;
using FastAPI.Application.Services.Common;
using FastAPI.Domain;
using Sample.Domain.Administration.Users;
using Sample.Application.Boundaries.Models.Administration.Users;
using Sample.Application.Boundaries.Services;

namespace Sample.Application.Services
{
    public class UserApplicationService : CrudApplicationService<User, UserAddModel, UserUpdateModel>, IUserApplicationService
    {
        public UserApplicationService(IRepository<User> repository, IMapper mapper, IUserDomainService domainService) : base(repository, mapper, domainService)
        {

        }
    }
}
