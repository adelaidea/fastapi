using FastAPI.Domain;

namespace Sample.Domain.Administration.Users
{
    public class UserDomainService : DomainService<User>, IUserDomainService
    {
        public UserDomainService(IRepository<User> repository) : base(repository)
        {
        }

        protected override bool IsValid(User entity, out string[] errors)
        {
            errors = new string[] { };
            return true;
        }
    }
}
