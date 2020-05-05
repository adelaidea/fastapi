using FastAPI.Application.Abstraction.Service.Common;
using Sample.Application.Boundaries.Models.Administration.Users;
using Sample.Domain.Administration.Users;

namespace Sample.Application.Boundaries.Services
{
    public interface IUserApplicationService : ICrudApplicationService<User, UserAddModel, UserUpdateModel>
    {
    }
}
