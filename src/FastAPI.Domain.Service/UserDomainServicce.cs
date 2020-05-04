using FastAPI.Domain.Abstractions.Repositories;
using FastAPI.Domain.Abstractions.Services;
using FastAPI.Domain.Entities;

namespace FastAPI.Domain.Services
{
    public class UserDomainService : DomainService<User> , IUserDomainService
    {
        public UserDomainService(IRepository<User> repository) : base(repository)
        {
        }

        public override bool IsValid(User entity)
        {
            return true;
        }
    }
}
