using FastAPI.Domain;

namespace Sample.Domain.Administration.Users
{
    public interface IUserDomainService : IDomainService<User>
    {
    }
}
