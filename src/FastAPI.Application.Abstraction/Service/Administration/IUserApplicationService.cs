using FastAPI.Application.Abstraction.Service.Common;
using FastAPI.Application.Models.Models.User;
using FastAPI.Domain.Entities;

namespace FastAPI.Application.Abstraction.Service.Administration
{
    public interface IUserApplicationService : ICrudApplicationService<User, UserModel, UserUpdateModel>
    {
    }
}
